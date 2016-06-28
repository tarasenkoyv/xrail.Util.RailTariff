using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using xrail.ETRAN.Model;
using xrail.ETRAN.Model.Replies;
using xrail.Rater.Interface;

namespace xrail.Util.RailTariff
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class RaterServiceImpl : IRaterService
    {
        private readonly EtranRater _rater;
        private static readonly ILog _logger;

        static RaterServiceImpl()
        {
            _logger = LogManager.GetLogger(typeof(RaterServiceImpl));
        }

        public RaterServiceImpl()
        {
            _rater = new EtranRater();
        }

        public CalcTariffResponce GetCalcDue(CalcTariffRequest request)
        {
            try
            {
                var freightReq = request.Freights.FirstOrDefault();
                var freight = new InvoiceFreight();
                if (freightReq != null)
                {
                    freight = new InvoiceFreight() { Code = freightReq.Code, Weight = freightReq.Weight, GNGID = freightReq.GNGID };
                }

                var cars = new List<InvCarReply>();
                foreach (var car in request.Cars)
                {
                    var invCar = new InvCarReply()
                    {
                        TypeID = car.TypeID,
                        Number = car.Number,
                        WeightNet = car.WeightNet,
                        WeightAddDev = car.WeightAddDev,
                        AddDevWithGoods = car.AddDevWithGoods,
                        Tonnage = car.Tonnage,
                        Axles = car.Axles,
                        OwnerTypeID = car.OwnerTypeID
                    };
                    cars.Add(invCar);
                }

                var distances = new List<Distance>();
                for (int i = 0; i < request.Distances.Count; i++)
                {
                    var distReq = request.Distances[i];
                    var dist = new Distance(i)
                    {
                        StationCode = distReq.CodeStation
                    };
                    distances.Add(dist);
                }

                var getCalcReply = _rater.GetCalcDue(request.DateLoad.Value, request.SendKindID, request.SpeedID.Value, request.FromStationCode, request.ToStationCode, cars, freight, distances);
                var responce = new CalcTariffResponce(getCalcReply);
                return responce;
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("При расчете тарифа произошла ошибка: {0}.", ex.Message);
            }
            return null;
        }
    }
}

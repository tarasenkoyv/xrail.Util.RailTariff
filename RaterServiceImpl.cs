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
using System.IO;
using xrail.ETRAN.Requests;
using System.Xml.Serialization;
using xrail.ETRAN.Replies;

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
                    freight = new InvoiceFreight() { Code = freightReq.Code, Weight = freightReq.Weight, GNGCode = freightReq.CodeGNG };
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

                var getCalcReply = _rater.GetCalcDue(request.DateLoad.Value, request.SendKindID, request.SpeedID.Value, request.FromStationCode, request.FromCountryCode, request.ToStationCode, request.ToCountryCode, cars, freight, distances);
                var responce = new CalcTariffResponce(getCalcReply);
                return responce;
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("При расчете тарифа произошла ошибка: {0}.", ex.Message);
            }
            return null;
        }

        public CalcTariffResponce GetCalcDueXml(Stream xml)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(CalcTariffRequest));
                var request = (CalcTariffRequest)serializer.Deserialize(xml);

                if (request.FactorPriceList > 0)
                {
                    // Расчет по собственным вагонам.
                    foreach (var car in request.Cars)
                    {
                        car.OwnerTypeID = 1;
                    }
                    var resultOwn = GetCalcDue(request);

                    // Расчет по собственным вагонам.
                    foreach (var car in request.Cars)
                    {
                        car.OwnerTypeID = 3;
                    }

                    var resultAll = GetCalcDue(request);
                    foreach (var due in resultAll.Dues)
                    {
                        var amountOwn = resultOwn[due.CarNumber].Amount;
                        due.AmountOwn = amountOwn;
                        due.CostCarService = Math.Round(due.Amount * request.FactorPriceList, 2) - amountOwn;
                    }

                    return resultAll;
                }
                else
                {
                    return GetCalcDue(request);
                }
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("При расчете тарифа произошла ошибка: {0}.", ex.Message);
            }
            return null;
        }

        public CalcDistanceResponce GetCalcDistanceXml(Stream xml)
        {
            var serializer = new XmlSerializer(typeof(CalcDistanceRequest));
            var request = (CalcDistanceRequest)serializer.Deserialize(xml);
            return GetCalcDinstance(request);

        }

        public CalcDistanceResponce GetCalcDinstance(CalcDistanceRequest request)
        {
            try
            {
                var getCalcDistance = new GetCalcDistance();
                foreach(var distReq in request.Distances)
                {
                    var dist = new InvDistanceReply("distance");
                    dist.CodeStation = distReq.CodeStation;
                    dist.Sign = distReq.Sign;

                    getCalcDistance.Distances.Add(dist);
                }
                getCalcDistance.AddBoard = request.AddBoard;
                getCalcDistance.CalcType = request.CalcType;
                getCalcDistance.DetailLevel = request.DetailLevel;
                getCalcDistance.DistType = request.DistType;
                getCalcDistance.UseMod11 = request.UseMod11;

                var getCalcReply = _rater.GetCalcDistance(getCalcDistance);
                var responce = new CalcDistanceResponce(getCalcReply);
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

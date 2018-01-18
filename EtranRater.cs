using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xrail.ETRAN.Model;
using xrail.ETRAN.Model.Replies;
using xrail.ETRAN.Replies;
using xrail.ETRAN.Requests;
using xrail.Gateway.Interface;
using xrail.Gateway.Client;
using xrail.Info.Model;
using xrail.Model.Interface;

namespace xrail.Util.RailTariff
{
    public class EtranRater
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(RzdWebRater));

        public GetCalcDueReply GetCalcDue(DateTime dateReady, long sendKindID, long speedID, int fromStationCode, short fromCountryCode, int toStationCode, short toCountryCode, List<InvCarReply> cars, InvoiceFreight freight, List<Distance> distances)
        {
            try
            {
                using (var etranDbContext = new EtranDbContext())
                {
                    var user = EtranGatewayHelper.BaseUser;
                    var request = new GatewayRequest { Login = user.Login, Password = user.Password };

                    GatewayResponce responce;
                    string resultMessage = string.Empty;

                    var getCalcDue = new GetCalcDue();
                    getCalcDue.SendKindID = sendKindID;
                    getCalcDue.SpeedID = speedID;
                    getCalcDue.FromStationCode = fromStationCode;
                    getCalcDue.FromCountryCode = fromCountryCode;
                    getCalcDue.ToStationCode = toStationCode;
                    getCalcDue.ToCountryCode = toCountryCode;
                    getCalcDue.DateLoad = dateReady;

                    getCalcDue.Freights.Add(new InvoiceFreight() { Code = freight.Code, Weight = freight.Weight, GNGCode = freight.GNGCode });
                    getCalcDue.Cars.AddRange(cars);

                    var getCalcDistance = new GetCalcDistance();
                    getCalcDistance.Distances.Add(new InvDistanceReply("distance") { CodeStation = fromStationCode });
                    getCalcDistance.Distances.Add(new InvDistanceReply("distance") { CodeStation = toStationCode });

                    getCalcDue.Distances.AddRange(getCalcDistance.Distances);

                    request.Text = getCalcDue.GetXml();

                    var @return = EtranGatewayController.Instance.ExecuteRequest(out responce, out resultMessage, request);

                    if (@return)
                    {
                        return ReplyBase.Create<GetCalcDueReply>(responce.Content as string);
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("При расчете тарифа произошла ошибка: {0}.", ex.Message);
            }
            return null;
        }

        public GetCalcDueReply GetCalcDueCustom(Invoice invoice, EtranDbContext etranDbContext, InfoContext infoDbContext)
        {
            try
            {
                var user = EtranGatewayHelper.BaseUser;
                var request = new GatewayRequest { Login = user.Login, Password = user.Password };

                GatewayResponce responce;
                string resultMessage = string.Empty;

                var getCalcDue = new GetCalcDue();
                getCalcDue.CodeTariff = invoice.CodeTariff;
                getCalcDue.SendKindID = invoice.SendKindID.Value;
                getCalcDue.SpeedID = invoice.SpeedID.Value;
                //getCalcDue.FromCountryCode = invoice.FromCountryCode.Value;
                getCalcDue.FromStationCode = invoice.CodeStationFirstRZD > 0 ? invoice.CodeStationFirstRZD : invoice.CodeFromStation.Value;
                getCalcDue.ToStationCode = invoice.CodeStationLastRZD > 0 ? invoice.CodeStationLastRZD : invoice.CodeToStation.Value;
                getCalcDue.ToCountryCode = invoice.ToCountryCode.Value;

                getCalcDue.DateLoad = invoice.DateReady;

                getCalcDue.SenderID = invoice.SenderID;
                getCalcDue.PayerCode = invoice.PayerCode;
                getCalcDue.PayFormID = invoice.PayFormID ?? 0;
                getCalcDue.PayPlaceID = invoice.PayPlaceID ?? 0;

                #region Сведения об отправительском маршруте

                if(!string.IsNullOrEmpty(invoice.RouteTypeName))
                {
                    if(getCalcDue.SendKindID ==  1)
                    {
                        getCalcDue.PlanCarCount = 2;
                    }

                    getCalcDue.SendKindID = 5;
                }
                getCalcDue.SignRouteNumCirc = invoice.SignRouteNumCirc;
                getCalcDue.RouteName = invoice.RouteName;
                getCalcDue.RouteNumCirc = invoice.RouteNumCirc;
                getCalcDue.RouteTypeName = invoice.RouteTypeName;

                #endregion // Сведения об отправительском маршруте

                var invoiceFreight = invoice.Freights.First();
                getCalcDue.Freights.Add(new InvoiceFreight() { Code = invoiceFreight.Code, Weight = invoiceFreight.Weight, GNGCode = invoiceFreight.GNGCode });

                var cars = new List<InvCarReply>();
                foreach (var invCar in invoice.Cars)
                {
                    var carInfo = infoDbContext.InfoCars.Find(invCar.Number);
                    var car = new InvCarReply()
                    {
                        TypeID = (short)invCar.TypeID,
                        Number = invCar.Number,
                        WeightNet = invCar.WeightNet,
                        WeightAddDev = invCar.WeightAddDev,
                        AddDevWithGoods = invCar.AddDevWithGoods,
                        Tonnage = invCar.Tonnage,
                        Axles = invCar.Axles == 0 ? (byte)carInfo?.Axles : invCar.Axles,
                        OwnerTypeID = 1
                    };
                    cars.Add(car);
                }
                getCalcDue.Cars.AddRange(cars);

                if (!string.IsNullOrEmpty(invoice.RouteTypeName) && getCalcDue.Cars.Count == 1)
                {
                    var firstCar = getCalcDue.Cars.First();
                    var testCar = new InvCarReply()
                    {
                        TypeID = (short)firstCar.TypeID,
                        Number = 11111110,
                        WeightNet = firstCar.WeightNet,
                        WeightAddDev = firstCar.WeightAddDev,
                        AddDevWithGoods = firstCar.AddDevWithGoods,
                        Tonnage = firstCar.Tonnage,
                        Axles = (byte)firstCar.Axles,
                        OwnerTypeID = 1
                    };
                    getCalcDue.Cars.Add(testCar);
                }

                var getCalcDistance = new GetCalcDistance();
                foreach(var dist in invoice.Distances)
                {
                    var distReply = new InvDistanceReply("distance") { CodeStation = dist.CodeStation / 10, CarrierID = dist.CarrierID ?? 1 /* ОАО "РЖД" */ };
                    getCalcDistance.Distances.Add(distReply);
                }

                getCalcDue.Distances.AddRange(getCalcDistance.Distances);

                request.Text = getCalcDue.GetXml();

                var @return = EtranGatewayController.Instance.ExecuteRequest(out responce, out resultMessage, request);

                if (@return)
                {
                    return ReplyBase.Create<GetCalcDueReply>(responce.Content as string);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("При расчете тарифа произошла ошибка: {0}.", ex.Message);
            }
            return null;
        }

        public GetCalcDueReply GetCalcDueRZD(Invoice invoice, EtranDbContext etranDbContext, InfoContext infoDbContext)
        {
            try
            {
                var user = EtranGatewayHelper.BaseUser;
                var request = new GatewayRequest { Login = user.Login, Password = user.Password };

                GatewayResponce responce;
                string resultMessage = string.Empty;

                var getCalcDue = new GetCalcDue();
                getCalcDue.CodeTariff = invoice.CodeTariff;
                getCalcDue.SendKindID = invoice.SendKindID.Value;
                getCalcDue.SpeedID = invoice.SpeedID.Value;
                //getCalcDue.FromCountryCode = invoice.FromCountryCode.Value;
                getCalcDue.FromStationCode = invoice.CodeStationFirstRZD > 0 ? invoice.CodeStationFirstRZD : invoice.CodeFromStation.Value;
                getCalcDue.ToStationCode = invoice.CodeStationLastRZD > 0 ? invoice.CodeStationLastRZD : invoice.CodeToStation.Value;
                getCalcDue.ToCountryCode = invoice.ToCountryCode.Value;

                getCalcDue.DateLoad = invoice.DateReady;

                getCalcDue.SenderID = invoice.SenderID;
                getCalcDue.PayerCode = invoice.PayerCode;
                getCalcDue.PayFormID = invoice.PayFormID ?? 0;
                getCalcDue.PayPlaceID = invoice.PayPlaceID ?? 0;

                #region Сведения об отправительском маршруте

                if (!string.IsNullOrEmpty(invoice.RouteTypeName))
                {
                    if (getCalcDue.SendKindID == 1)
                    {
                        getCalcDue.PlanCarCount = 2;
                    }

                    getCalcDue.SendKindID = 5;
                }

                getCalcDue.SignRouteNumCirc = invoice.SignRouteNumCirc;
                getCalcDue.RouteName = invoice.RouteName;
                getCalcDue.RouteNumCirc = invoice.RouteNumCirc;
                getCalcDue.RouteTypeName = invoice.RouteTypeName;

                #endregion // Сведения об отправительском маршруте

                var invoiceFreight = invoice.Freights.First();
                getCalcDue.Freights.Add(new InvoiceFreight() { Code = invoiceFreight.Code, Weight = invoiceFreight.Weight, GNGCode = invoiceFreight.GNGCode });

                var cars = new List<InvCarReply>();
                foreach (var invCar in invoice.Cars)
                {
                    var carInfo = infoDbContext.InfoCars.Find(invCar.Number);
                    var car = new InvCarReply()
                    {
                        TypeID = (short)invCar.TypeID,
                        Number = invCar.Number,
                        WeightNet = invCar.WeightNet,
                        WeightAddDev = invCar.WeightAddDev,
                        AddDevWithGoods = invCar.AddDevWithGoods,
                        Tonnage = invCar.Tonnage,
                        Axles = invCar.Axles == 0 ? (byte)carInfo?.Axles : invCar.Axles,
                        OwnerTypeID = 3
                    };
                    cars.Add(car);
                }
                getCalcDue.Cars.AddRange(cars);

                if (!string.IsNullOrEmpty(invoice.RouteTypeName) && getCalcDue.Cars.Count == 1)
                {
                    var firstCar = getCalcDue.Cars.First();
                    var testCar = new InvCarReply()
                    {
                        TypeID = (short)firstCar.TypeID,
                        Number = 11111110,
                        WeightNet = firstCar.WeightNet,
                        WeightAddDev = firstCar.WeightAddDev,
                        AddDevWithGoods = firstCar.AddDevWithGoods,
                        Tonnage = firstCar.Tonnage,
                        Axles = (byte)firstCar.Axles,
                        OwnerTypeID = 3
                    };
                    getCalcDue.Cars.Add(testCar);
                }

                var getCalcDistance = new GetCalcDistance();
                foreach (var dist in invoice.Distances)
                {
                    var distReply = new InvDistanceReply("distance") { CodeStation = dist.CodeStation / 10, CarrierID = dist.CarrierID ?? 1 /* ОАО "РЖД" */ };
                    getCalcDistance.Distances.Add(distReply);
                }
                getCalcDue.Distances.AddRange(getCalcDistance.Distances);

                request.Text = getCalcDue.GetXml();

                bool? @return = EtranGatewayController.Instance.ExecuteRequest(out responce, out resultMessage, request);

                if (@return != null && @return.Value)
                {
                    return ReplyBase.Create<GetCalcDueReply>(responce.Content as string);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("При расчете тарифа произошла ошибка: {0}.", ex.Message);
            }
            return null;
        }

        public GetCalcDistanceReply GetCalcDistance(GetCalcDistance getCalcDistance)
        {
            try
            {
                using (var etranDbContext = new EtranDbContext())
                {
                    var user = EtranGatewayHelper.BaseUser;
                    var request = new GatewayRequest { Login = user.Login, Password = user.Password };

                    GatewayResponce responce;
                    string resultMessage = string.Empty;

                    request.Text = getCalcDistance.GetXml();

                    var @return = EtranGatewayController.Instance.ExecuteRequest(out responce, out resultMessage, request);

                    if (@return)
                    {
                        return ReplyBase.Create<GetCalcDistanceReply>(responce.Content as string);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("При расчете тарифного расстояния произошла ошибка: {0}.", ex.Message);
            }
            return null;
        }
    }
}

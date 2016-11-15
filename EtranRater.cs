﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xrail.ETRAN.Model;
using xrail.ETRAN.Model.Replies;
using xrail.ETRAN.Replies;
using xrail.ETRAN.Requests;
using xrail.Gateway;
using xrail.Info.Model;
using xrail.Model.Interface;
using xrail.Util.RailTariff.Helper;

namespace xrail.Util.RailTariff
{
    public class EtranRater
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(RzdWebRater));

        public GetCalcDueReply GetCalcDue(DateTime dateReady, long sendKindID, long speedID, int fromStationCode, short fromCountryCode, int toStationCode, short toCountryCode, List<InvCarReply> cars, InvoiceFreight freight, List<Distance> distances)
        {
            try
            {
                using (var client = new GatewayDirectClient())
                {
                    using (var etranDbContext = new EtranDbContext())
                    {
                        var user = etranDbContext.Users.Find(1);
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

                        bool? @return = EtranHelper.ExecuteRequest(out responce, out resultMessage, request, client, etranDbContext);

                        if(@return != null && @return.Value)
                        {
                            return ReplyBase.Create<GetCalcDueReply>(responce.Content as string);
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("При расчете тарифа произошла ошибка: {0}.", ex.Message);
            }
            return null;
        }

        public GetCalcDueReply GetCalcDueCustom(Invoice invoice, EtranDbContext etranDbContext, InfoContext infoDbContext, GatewayDirectClient client)
        {
            try
            {
                var user = etranDbContext.Users.Find(1);
                var request = new GatewayRequest { Login = user.Login, Password = user.Password };

                GatewayResponce responce;
                string resultMessage = string.Empty;

                var getCalcDue = new GetCalcDue();
                getCalcDue.CodeTariff = invoice.CodeTariff;
                getCalcDue.SendKindID = invoice.SendKindID.Value;
                getCalcDue.SpeedID = invoice.SpeedID.Value;
                //getCalcDue.FromCountryCode = invoice.FromCountryCode.Value;
                getCalcDue.FromStationCode = invoice.CodeStationFirstRZD;
                getCalcDue.ToStationCode = invoice.CodeStationLastRZD;
                getCalcDue.ToCountryCode = invoice.ToCountryCode.Value;

                getCalcDue.DateLoad = invoice.DateReady;
                
                var invoiceFreight = invoice.Freights.First();
                getCalcDue.Freights.Add(new InvoiceFreight() { Code = invoiceFreight.Code, Weight = invoiceFreight.Weight, GNGCode = invoiceFreight.GNGCode });

                var cars = new List<InvCarReply>();
                foreach (var invCar in invoice.Cars)
                {
                    var carInfo = infoDbContext.InfoCars.Find(invCar.Number);
                    var car = new InvCarReply()
                    {
                        TypeID = (short)carInfo.TypeID,
                        Number = invCar.Number,
                        WeightNet = invCar.WeightNet,
                        WeightAddDev = invCar.WeightAddDev,
                        AddDevWithGoods = invCar.AddDevWithGoods,
                        Tonnage = invCar.Tonnage,
                        Axles = (byte)carInfo.Axles,
                        OwnerTypeID = 1
                    };
                    cars.Add(car);
                }
                getCalcDue.Cars.AddRange(cars);

                var getCalcDistance = new GetCalcDistance();
                getCalcDistance.Distances.Add(new InvDistanceReply("distance") { CodeStation = invoice.CodeFromStation.Value });
                getCalcDistance.Distances.Add(new InvDistanceReply("distance") { CodeStation = invoice.CodeToStation.Value });

                getCalcDue.Distances.AddRange(getCalcDistance.Distances);

                request.Text = getCalcDue.GetXml();

                bool? @return = EtranHelper.ExecuteRequest(out responce, out resultMessage, request, client, etranDbContext);

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

        public GetCalcDueReply GetCalcDueRZD(Invoice invoice, EtranDbContext etranDbContext, InfoContext infoDbContext, GatewayDirectClient client)
        {
            try
            {
                var user = etranDbContext.Users.Find(1);
                var request = new GatewayRequest { Login = user.Login, Password = user.Password };

                GatewayResponce responce;
                string resultMessage = string.Empty;

                var getCalcDue = new GetCalcDue();
                getCalcDue.CodeTariff = invoice.CodeTariff;
                getCalcDue.SendKindID = invoice.SendKindID.Value;
                getCalcDue.SpeedID = invoice.SpeedID.Value;
                //getCalcDue.FromCountryCode = invoice.FromCountryCode.Value;
                getCalcDue.FromStationCode = invoice.CodeStationFirstRZD;
                getCalcDue.ToStationCode = invoice.CodeStationLastRZD;
                getCalcDue.ToCountryCode = invoice.ToCountryCode.Value;

                getCalcDue.DateLoad = invoice.DateReady;

                var invoiceFreight = invoice.Freights.First();
                getCalcDue.Freights.Add(new InvoiceFreight() { Code = invoiceFreight.Code, Weight = invoiceFreight.Weight, GNGCode = invoiceFreight.GNGCode });

                var cars = new List<InvCarReply>();
                foreach (var invCar in invoice.Cars)
                {
                    var carInfo = infoDbContext.InfoCars.Find(invCar.Number);
                    var car = new InvCarReply()
                    {
                        TypeID = (short)carInfo.TypeID,
                        Number = invCar.Number,
                        WeightNet = invCar.WeightNet,
                        WeightAddDev = invCar.WeightAddDev,
                        AddDevWithGoods = invCar.AddDevWithGoods,
                        Tonnage = invCar.Tonnage,
                        Axles = (byte)carInfo.Axles,
                        OwnerTypeID = 3
                    };
                    cars.Add(car);
                }
                getCalcDue.Cars.AddRange(cars);

                var getCalcDistance = new GetCalcDistance();
                getCalcDistance.Distances.Add(new InvDistanceReply("distance") { CodeStation = invoice.CodeFromStation.Value });
                getCalcDistance.Distances.Add(new InvDistanceReply("distance") { CodeStation = invoice.CodeToStation.Value });

                getCalcDue.Distances.AddRange(getCalcDistance.Distances);

                request.Text = getCalcDue.GetXml();

                bool? @return = EtranHelper.ExecuteRequest(out responce, out resultMessage, request, client, etranDbContext);

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
                using (var client = new GatewayDirectClient())
                {
                    using (var etranDbContext = new EtranDbContext())
                    {
                        var user = etranDbContext.Users.Find(1);
                        var request = new GatewayRequest { Login = user.Login, Password = user.Password };

                        GatewayResponce responce;
                        string resultMessage = string.Empty;

                        request.Text = getCalcDistance.GetXml();

                        bool? @return = EtranHelper.ExecuteRequest(out responce, out resultMessage, request, client, etranDbContext);

                        if (@return != null && @return.Value)
                        {
                            return ReplyBase.Create<GetCalcDistanceReply>(responce.Content as string);
                        }
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
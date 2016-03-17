using log4net;
using RailTariff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xrail.Util.RailTariff
{
    public static class RailTariffRater
    {
        private static ILog _logger;

        public static string[] ResultFieldNames =
        {   @"LandId",
            @"LandName",
            @"ShemaNo",
            @"Distance",
            @"Distance\Transit",
            @"Distance\Real",
            @"PeriodOfDelivery",
            @"BasePrice",
            @"BasePrice\NDS",
            @"BasePerT",
            @"BasePerT\NDS",
            @"BufferCarPrice",
            @"BufferCarPrice\NDS",
            @"LocomotivePrice",
            @"LocomotivePrice\NDS",
            @"WagonDieselElPrice",
            @"GuardPrice",
            @"GuardPrice\NDS",
            @"AddDues",
            @"AddDues\NDS",
            @"SoprPrice",
            @"SoprPrice\NDS",
            @"TotalPriceWoNDS",
            @"TotalPrice",
            @"NDS",
            @"PerT",
            @"PerTwoNDS",
            @"PerM3",
            @"PerM3woNDS",
            @"ABBR",
            @"CurrencyID"
        };

        static RailTariffRater()
        {
            _logger = LogManager.GetLogger(typeof(RailTariffRater));

        }
        public static Dictionary<Tuple<int, int>, int> GetDistance(List<Tuple<int, int>> stationPairs)
        {
            var result = new Dictionary<Tuple<int, int>, int>();
            try
            {
                foreach (var pair in stationPairs)
                {
                    try
                    {
                        var App = new Application();
                        App.Initialize("");

                        var doc = App.CreateDocument;

                        doc.Attributes.OnDate(new DateTime(2015, 01, 01));

                        var request = new Request()
                        {
                            FromStation = new RequestFromStation() { Code = pair.Item1.ToString("000000"), LandId = 0, LandIdSpecified = true },
                            ToStation = new RequestToStation() { Code = pair.Item2.ToString("000000"), LandId = 0, LandIdSpecified = true },
                        };
                        doc.Attributes.FromStation(request.FromStation.Code, request.FromStation.LandId);
                        doc.Attributes.ToStation(request.ToStation.Code, request.ToStation.LandId);
                        
                        (doc as IDocumentControl).DoCalcDistance();
                        
                        int distance = 0;
                        int.TryParse(Convert.ToString(doc.Result.Value[ResultFieldNames[3]]), out distance);
                        result.Add(pair, distance);
                    }
                    catch (Exception ex)
                    {
                        _logger.ErrorFormat("При расчете расстояния между станциями с кодами {0} и {1} произошла ошибка: {2}.",
                                            pair.Item1.ToString("000000"), pair.Item2.ToString("000000"), ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("При расчете расстояний произошла ошибка: {0}.", ex.Message);
            }

            return result;
        }


    }
}

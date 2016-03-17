using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using xrail.Info.Model.Entities;

namespace xrail.Util.RailTariff
{
    public class RzdWebRater
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(RzdWebRater));

        public CalcDueResults GetCalcDue(DateTime dateReady, long dispKindID, long sendKindID, long speedID, List<Wag> cars, Freight freight, List<Distance> distances)
        {
            try
            {
                var builder = new CalcDuePostDataBuilder(dateReady, dispKindID, sendKindID, speedID, cars, freight, distances);
                var postData = builder.GetPostData();
                var byteArray = Encoding.UTF8.GetBytes(postData);
                WebRequest request = WebRequest.Create("http://rpp.rzd.ru/Rzd/CalcPP");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();

                Stream responceStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responceStream);
                string responseData = reader.ReadToEnd();
                reader.Close();
                responceStream.Close();
                response.Close();

                return PostDataBase.Deserialize(responseData, typeof(CalcDueResults)) as CalcDueResults;
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("При расчете тарифа произошла ошибка: {0}.", ex.Message);
            }
            return null;
        }

        public Distances GetCalcDistance(InfoUniqueStation fromStation, InfoUniqueStation toStation)
        {
            try
            {
                WebRequest request = WebRequest.Create("http://rpp.rzd.ru/Rzd/CalcPP");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                var calcDistanceBuilder = new CalcDistancePostDataBuilder() { FromCountryCode = fromStation.StCnID,
                                                                              ToCountryCode = toStation.StCnID,
                                                                              FromStationCode = fromStation.StCode,
                                                                              ToStationCode = toStation.StCode
                };
                var postData = calcDistanceBuilder.GetPostData();
                var byteArray = Encoding.UTF8.GetBytes(postData);

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();

                Stream responceStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responceStream);
                string responseData = reader.ReadToEnd();
                reader.Close();
                responceStream.Close();
                response.Close();

                return PostDataBase.Deserialize(responseData, typeof(Distances)) as Distances;
            }
            catch(Exception ex)
            {
                _logger.ErrorFormat("При расчете тарифного расстояния произошла ошибка: {0}.", ex.Message);
            }
            return null;
        }
    }
}

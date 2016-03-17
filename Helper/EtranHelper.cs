using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xrail.ETRAN.Model;
using xrail.Gateway;
using xrail.Logging.Model.Entities;

namespace xrail.Util.RailTariff.Helper
{
    public static class  EtranHelper
    {
        private static readonly ILog _logger;
        static EtranHelper()
        {
            _logger = LogManager.GetLogger(typeof(EtranHelper));
        }

        /// <summary>
        /// Количество попыток загрузить данные с сервера АС ЭТРАН в случае внутренней ошибки.
        /// </summary> 
        public const int DefaultTriesBeforeFail = 20;

        public static bool? ExecuteRequest(out GatewayResponce responce, out string resultMessage, GatewayRequest request, IGateway client, EtranDbContext etranDbContext)
        {
            bool? @return = null;
            responce = null;
            string errorText = string.Empty;
            resultMessage = string.Empty;
            for (int tries = 1; @return == null && tries <= DefaultTriesBeforeFail; tries++)
            {
                responce = client.GetBlock(request);
                @return = true;
                if (responce.State != GatewayResponce.States.OK)
                {
                    if (responce.State == GatewayResponce.States.EtranError)
                    {
                        @return = null;
                        //Ошибка на стороне АС ЭТРАН.
                        var etranError = responce.Content as EtranError;
                        etranDbContext.ErrorLog.Add(new Error(etranError, request.Text));
                        etranDbContext.SaveChanges();
                        errorText = string.Format("В ходе выполнения запроса:\n {0}\nпроизошла ошибка: {1}\nответ: {2}.",
                                                  request.Text, etranError.Message, (responce.Content ?? "").ToString());
                        _logger.Error(errorText);

                        if (etranError.Code == EtranError.Codes.QueryErrorCheckingData
                           || etranError.Code == EtranError.Codes.QueryErrorSyntax
                           || etranError.Code == EtranError.Codes.QueryUnknownTag
                           || etranError.Code == EtranError.Codes.QueryUnknownType
                           || etranError.Status == EtranError.Statuses.StoppedForSomeTimeError)
                        {
                            @return = false;
                        }
                    }
                    else
                    {
                        //Ошибка передачи данных в АС ЭТРАН.
                        errorText = string.Format("В ходе выполнения запроса:\n {0}\nпроизошла ошибка: {1}\n'{2}'.",
                                                  request.Text, responce.State, (responce.Content ?? "").ToString());
                        _logger.Error(errorText);
                        @return = false;
                    }
                }
                else
                {
                    resultMessage = responce.Content as string;
                }
            }
            if (@return != true)
            {
                resultMessage = errorText;
                _logger.ErrorFormat(errorText);
                return false;
            }
            return @return;
        }

    }
}

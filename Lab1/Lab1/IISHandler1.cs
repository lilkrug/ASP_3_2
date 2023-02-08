using System;
using System.Web;

namespace Lab1
{
    public class IISHandler1 : IHttpHandler
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Члены IHttpHandler

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //разместите здесь вашу реализацию обработчика.
            HttpRequest req = context.Request;
            HttpResponse res = context.Response;
            var ParmA = req["parmA"];
            var ParmB = req["parmB"];
            res.AddHeader("Content-Type", "text/plain");
            res.Write($"--- Метод GET ---\nparmA = {ParmA} \nparmB = {ParmB}");
        }

        #endregion
    }
}

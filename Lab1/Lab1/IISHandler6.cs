using System;
using System.Web;

namespace Lab1
{
    public class IISHandler6 : IHttpHandler
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

            res.AddHeader("Content-Type", "text/plain");


            if (req.HttpMethod == "GET")
            {
                res.ContentType = "text/html";
                res.WriteFile("form6.html");
            }
            else if (req.HttpMethod == "POST")
            {
                var x = int.Parse(req.Form["x"]);
                var y = int.Parse(req.Form["y"]);
                var mult2 = x * y;
                res.Write($"<h1>{x} * {y} = {mult2}</h1>");
            }
        }

        #endregion
    }
}

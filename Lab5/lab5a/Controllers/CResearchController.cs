using System.IO;
using System.Web.Mvc;

namespace lab5a.Controllers
{
    public class CResearchController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public string C01()
        {
            string body;
            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                body = reader.ReadToEnd();
            }
            string parametrs = null;
            foreach (var el in Request.QueryString.AllKeys)
            {
                parametrs += el + " ";
                parametrs += Request.QueryString.Get(el) + " ";
            }
            return (Request.HttpMethod == "POST" ? $"body: {body}; " : "") + $"headers: {Request.Headers.ToString()}; " + $"method: {Request.HttpMethod}; " + $"uri: {Request.Url.AbsoluteUri}; " + $"params: {parametrs}; ";
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public string C02()
        {
            string body;

            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                body = reader.ReadToEnd();
            }

            return (Request.HttpMethod == "POST" ? $"body: {body}; " : "") + $"headers: {Request.Headers.ToString()};" + $"status: {HttpContext.Response.StatusCode.ToString()}";
        }
    }
}
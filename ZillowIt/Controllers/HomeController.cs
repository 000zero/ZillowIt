using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

using System.Xml.Serialization;

namespace ZillowIt.Controllers
{
    public class HomeController : Controller
    {
        private const string _uri = "http://www.zillow.com/webservice/GetSearchResults.htm?zws-id=X1-ZWz1dyb53fdhjf_6jziz";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ResultsView()
        {
            // store the GET params
            string address = this.Request.QueryString["address"];
            string citystatezip = this.Request.QueryString["citystatezip"];

            // URL Encode before making request
            var uri = String.Format("{0}&address={1}&citystatezip={2}", _uri, HttpUtility.UrlEncode(address), HttpUtility.UrlEncode(citystatezip));
            
            // make the call to the Zillow API
            var request = System.Net.WebRequest.Create(uri);
            var stream = request.GetResponse().GetResponseStream();
            var response = new System.IO.StreamReader(stream).ReadToEnd();

            // create the serializer for the Zillow Results XML
            var ser = new XmlSerializer(typeof(ZillowIt.Models.ZillowResults));

            // deserialize the response XML
            ZillowIt.Models.ZillowResults results;
            using (var rdr = new System.IO.StringReader(response))
                results = (ZillowIt.Models.ZillowResults)ser.Deserialize(rdr);

            // render the partial view with the Zillow results
            return PartialView("~/Views/Home/_SearchResults.cshtml", results);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
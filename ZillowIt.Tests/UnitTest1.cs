using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Xml.Serialization;

namespace ZillowIt.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string xml = "<SearchResults:searchresults xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:SearchResults=\"http://www.zillow.com/static/xsd/SearchResults.xsd\" xsi:schemaLocation=\"http://www.zillow.com/static/xsd/SearchResults.xsd http://www.zillowstatic.com/vstatic/1e34236/static/xsd/SearchResults.xsd\"><request><address>15748 Firethorn Rd</address><citystatezip>Fontana, CA</citystatezip></request><message><text>Request successfully processed</text><code>0</code></message><response><results><result><zpid>17284412</zpid><links><homedetails>http://www.zillow.com/homedetails/15748-Firethorn-Rd-Fontana-CA-92337/17284412_zpid/</homedetails><graphsanddata>http://www.zillow.com/homedetails/15748-Firethorn-Rd-Fontana-CA-92337/17284412_zpid/#charts-and-data</graphsanddata><mapthishome>http://www.zillow.com/homes/17284412_zpid/</mapthishome><comparables>http://www.zillow.com/homes/comps/17284412_zpid/</comparables></links><address><street>15748 Firethorn Rd</street><zipcode>92337</zipcode><city>Fontana</city><state>CA</state><latitude>34.043906</latitude><longitude>-117.461289</longitude></address><zestimate><amount currency=\"USD\">324560</amount><last-updated>01/27/2015</last-updated><oneWeekChange deprecated=\"true\"/><valueChange duration=\"30\" currency=\"USD\">2025</valueChange><valuationRange><low currency=\"USD\">308332</low><high currency=\"USD\">340788</high></valuationRange><percentile>0</percentile></zestimate><localRealEstate><region id=\"24741\" type=\"city\" name=\"Fontana\"><zindexValue>305,900</zindexValue><links><overview>http://www.zillow.com/local-info/CA-Fontana/r_24741/</overview><forSaleByOwner>http://www.zillow.com/fontana-ca/fsbo/</forSaleByOwner><forSale>http://www.zillow.com/fontana-ca/</forSale></links></region></localRealEstate></result></results></response></SearchResults:searchresults>";

            var xmldoc = new XmlDocument();
            using (var rdr = new System.IO.StringReader(xml))
            {
                xmldoc.Load(rdr);
            }
            

            XmlSerializer ser = new XmlSerializer(typeof(ZillowIt.Models.ZillowResults));

            try
            {
                using (var rdr = new System.IO.StringReader(xml))
                {
                    var result = (ZillowIt.Models.ZillowResults)ser.Deserialize(rdr);
                }
            }
             catch (Exception ex)
            {

            }
        }
    }
}

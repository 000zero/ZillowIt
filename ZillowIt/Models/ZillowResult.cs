using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ZillowIt.Models
{
    [XmlRoot(ElementName = "searchresults", Namespace = "http://www.zillow.com/static/xsd/SearchResults.xsd")]
    public class ZillowResults
    {
        [XmlElement(ElementName="request", Form=XmlSchemaForm.Unqualified)]
        public ZillowRequest Request { get; set; }
        [XmlElement(ElementName = "message", Form = XmlSchemaForm.Unqualified)]
        public ZillowMessage Message { get; set; }
        [XmlElement(ElementName = "response", Form = XmlSchemaForm.Unqualified)]
        public ZillowResponse Response { get; set; }
    }

    /// <summary>
    /// The Zillow request associated with the API result
    /// </summary>
    public class ZillowRequest
    {
        [XmlElement(ElementName = "address", Form = XmlSchemaForm.Unqualified)]
        public string Address { get; set; }
        [XmlElement(ElementName = "citystatezip", Form = XmlSchemaForm.Unqualified)]
        public string CityStateZip { get; set; }
    }

    /// <summary>
    /// Zillow API message response status
    /// </summary>
    public class ZillowMessage
    {
        [XmlElement(ElementName = "text", Form = XmlSchemaForm.Unqualified)]
        public string Text { get; set; }
        [XmlElement(ElementName = "code", Form = XmlSchemaForm.Unqualified)]
        public int Code { get; set; }
    }

    //[XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.zillow.com/static/xsd/SearchResults.xsd")]
    public class ZillowResponse
    {
        [XmlArray("results", Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("result", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public ZillowResult[] Results { get; set; }
    }

    public class ZillowResult
    {
        [XmlElement(ElementName = "zpid", Form = XmlSchemaForm.Unqualified)]
        public long ZillowId { get; set; }
        [XmlElement(ElementName = "links", Form = XmlSchemaForm.Unqualified)]
        public ZillowResultsLinks Links { get; set; }
        [XmlElement(ElementName = "address", Form = XmlSchemaForm.Unqualified)]
        public ZillowAddress Address { get; set; }
        [XmlElement(ElementName = "zestimate", Form = XmlSchemaForm.Unqualified)]
        public ZillowEstimate Estimate { get; set; }
        [XmlArray("localRealEstate", Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("region", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public ZillowRegion[] LocalRealEstate { get; set; }
    }

    public class ZillowResultsLinks
    {
        [XmlElement(ElementName = "homedetails", Form = XmlSchemaForm.Unqualified)]
        public string HomeDetails { get; set; }
        [XmlElement(ElementName = "graphsanddata", Form = XmlSchemaForm.Unqualified)]
        public string GraphsAndData { get; set; }
        [XmlElement(ElementName = "mapthishome", Form = XmlSchemaForm.Unqualified)]
        public string MapThisHome { get; set; }
        [XmlElement(ElementName = "comparables", Form = XmlSchemaForm.Unqualified)]
        public string Comparables { get; set; }
    }

    public class ZillowAddress
    {
        [XmlElement(ElementName = "street", Form = XmlSchemaForm.Unqualified)]
        public string Street { get; set; }
        [XmlElement(ElementName = "zipcode", Form = XmlSchemaForm.Unqualified)]
        public string ZipCode { get; set; }
        [XmlElement(ElementName = "city", Form = XmlSchemaForm.Unqualified)]
        public string City { get; set; }
        [XmlElement(ElementName = "state", Form = XmlSchemaForm.Unqualified)]
        public string State { get; set; }
        [XmlElement(ElementName = "latitude", Form = XmlSchemaForm.Unqualified)]
        public float Latitude { get; set; }
        [XmlElement(ElementName = "longitude", Form = XmlSchemaForm.Unqualified)]
        public float Longitude { get; set; }
    }

    public class ZillowEstimate
    {
        [XmlIgnore]
        public int Amount { get; set; }
        [ XmlElement(ElementName = "amount", Form = XmlSchemaForm.Unqualified)]
        public string AmountAsText 
        { 
            get { return Amount.ToString(); }
            set { Amount = !String.IsNullOrEmpty(value) ? int.Parse(value) : 0; }
        }
        [XmlElement(ElementName = "last-updated", Form = XmlSchemaForm.Unqualified)]
        public string LastUpdate { get; set; }
        [XmlElement(ElementName = "valueChange", Form = XmlSchemaForm.Unqualified)]
        public ZillowValueChange ValueChange { get; set; }
        [XmlElement(ElementName = "valuationRange", Form = XmlSchemaForm.Unqualified)]
        public ZillowValuationRange ValuationRange { get; set; }
        [XmlElement(ElementName = "percentile", Form = XmlSchemaForm.Unqualified)]
        public int Percentile { get; set; }
    }

    public class ZillowValueChange
    {
        [XmlAttribute("duration", Form = XmlSchemaForm.Unqualified)]
        public int Duration { get; set; }
        [XmlAttribute("currency", Form = XmlSchemaForm.Unqualified)]
        public string Currency { get; set; }
        [XmlText]
        public int Value { get; set; }
    }

    public class ZillowValuationRange
    {
        [XmlElement(ElementName = "low", Form = XmlSchemaForm.Unqualified)]
        public ZillowValuationRangePoint Low { get; set; }
        [XmlElement(ElementName = "high", Form = XmlSchemaForm.Unqualified)]
        public ZillowValuationRangePoint High { get; set; }
    }

    public class ZillowValuationRangePoint
    {
        [XmlAttribute("currency")]
        public string Currency { get; set; }
        [XmlText]
        public int Value { get; set; }
    }

    public class ZillowRegion
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "zindexValue", Form = XmlSchemaForm.Unqualified)]
        public string ZIndexValue { get; set; }
        [XmlElement(ElementName = "zindexOneYearChange", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ZIndexOneYearChange { get; set; }
        [XmlElement(ElementName = "links", Form = XmlSchemaForm.Unqualified)]
        public ZillowRegionLinks Links { get; set; }
    }

    public class ZillowRegionLinks
    {
        [XmlElement(ElementName = "overview", Form = XmlSchemaForm.Unqualified)]
        public string Overview { get; set; }
        [XmlElement(ElementName = "forsalebyowner", Form = XmlSchemaForm.Unqualified)]
        public string ForSaleByOwner { get; set; }
        [XmlElement(ElementName = "forsale", Form = XmlSchemaForm.Unqualified)]
        public string ForSale { get; set; }
    }
}
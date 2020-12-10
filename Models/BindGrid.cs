using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Newtonsoft.Json;

namespace BindingGrid.Models
{
    public class BindGrid
    {
        
    }

    public class Value
    {
        [JsonProperty("COUNTRYNAME")]
        string COUNTRYNAME;
        [JsonProperty("REGIONNAME")]
        string REGIONNAME;
        [JsonProperty("SECTOR")]
        string SECTOR;
        [JsonProperty("SUBSECTOR")]
        string SUBSECTOR;
        [JsonProperty("QUESTIONMAPPINGID")]
        int QUESTIONMAPPINGID;
    }

    public class OData
    {
        [JsonProperty("odata.metadata")]
        public string Metadata { get; set; }
        public List<Value> Value { get; set; }
    }
}

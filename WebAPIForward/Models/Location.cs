using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIForward.Models
{
    public class Location
    {
        public string disposition { get; set; }
        public string name { get; set; }
        public string exposure { get; set; }
        public string domain { get; set; }
        public string ele { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }

    }
}
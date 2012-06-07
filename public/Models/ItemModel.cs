using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace publicWeb.Models
{
    public class ItemModel
    {
        public long _lastChange { get; set; }
        public string name { get; set; }
        public string category { get; set; }

        public bool dirty { get; set; }
        public bool deleted { get; set; }
        public string id { get; set; }




        public string de { get; set; }
    }
}
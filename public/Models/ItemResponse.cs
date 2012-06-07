using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace publicWeb.Models
{
    public class ItemResponse
    {

        public ItemResponse()
        {
            now = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        public long now { get; set; }
        public List<ItemModel> updates { get; set; }
    }
}
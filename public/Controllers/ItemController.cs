using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using publicWeb.Models;

namespace publicWeb.Controllers
{
    public class ItemController : ApiController
    {
        private static List<ItemModel> _items = new List<ItemModel>
                                             {
                                                 //new ItemModel
                                                 //    {
                                                 //        id = "abc123",
                                                 //        name = "test1",
                                                 //        category = "testc",
                                                 //        _lastChange = 1000,
                                                 //        deleted = false
                                                 //    }

                                             };

        // GET /api/itemapi
        public ItemResponse Get(int? since)
        {
            var epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            var items = (from t in _items where t._lastChange > epoch select t);
            return new ItemResponse {updates = _items, now = epoch};
        }

        // POST /api/item
        public ItemResponse Post(IEnumerable<ItemModel> updates)
        {
            var epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            foreach (var itemModel in updates)
            {

                var item = (from t in _items where t.id == itemModel.id select t).FirstOrDefault();
                if(item == null)
                {
                    itemModel._lastChange = epoch;
                    _items.Add(itemModel);
                }
                else
                {
                    if (itemModel._lastChange > item._lastChange)
                    {
                        item._lastChange = epoch;
                        item.name = string.IsNullOrEmpty(itemModel.name) ? item.name : itemModel.name;
                        item.category = string.IsNullOrEmpty(itemModel.category) ? item.category : itemModel.category;
                        item.deleted = itemModel.deleted;
                    }
                }
            }
            var items = (from t in _items where t._lastChange > epoch select t);
            return new ItemResponse { updates = items.ToList(), now = epoch };
        }
        
        public ItemResponse Post(string test)
        {
            return new ItemResponse { updates = _items.ToList(), now = -1 };
        }

        // PUT /api/item/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/item/5
        public void Delete(int id)
        {
        }
    }
}

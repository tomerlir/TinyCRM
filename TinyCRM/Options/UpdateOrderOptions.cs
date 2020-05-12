using System;
using System.Collections.Generic;

namespace TinyCRM.Options
{
    public class UpdateOrderOptions
    {
        public int? OrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public List<int> ProductIds { get; set; }

        public UpdateOrderOptions()
        {
            ProductIds = new List<int>();
        }
    }
}

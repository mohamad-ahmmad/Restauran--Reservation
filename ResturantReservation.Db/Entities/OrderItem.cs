﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantReservation.Db.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int MenuItemId { get; set; }
        
        public MenuItem MenuItem { get; set; }

        public int Quantity { get; set; }  
    }

}

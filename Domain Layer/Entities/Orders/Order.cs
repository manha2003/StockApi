﻿using DomainLayer.Entities.Stocks;
using DomainLayer.Entities.Users;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Orders
{

    public class Order
    {
        public Guid Id { get; set; }


        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid StockId { get; set; }
        public Stock Stock { get; set; }

       
        public OrderType Type { get; set; }        
        public OrderStatus Status { get; set; }     

        public decimal Quantity { get; set; }      
        public decimal Price { get; set; }          

        public DateTime CreatedAt { get; set; }     
       
    }
}

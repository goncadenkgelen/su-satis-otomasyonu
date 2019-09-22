﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuSatisOtomasyonu.Model
{
    class OrderModel
    {
        public int orderID { get; set; }
        public int CustomerID { get; set; }
        public string status { get; set; }
        public Nullable<int> price { get; set; }

        public Customer Customer { get; set; }
    }
}
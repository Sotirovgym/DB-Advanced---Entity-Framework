﻿using System;
using System.Collections.Generic;

namespace P03_SalesDatabase.Data.Models
{
    public class Sale
    {
        public int SaleId { get; set; }

        public DateTime Date { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int SoreId { get; set; }

        public Store Store { get; set; }

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.TransactionDTOs
{
    public class TransactionDTOs
    {
        public int Id { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? ShippingAddress { get; set; }
        public float? TotalAmount { get; set; }
        public int? Quantity { get; set; }
        public string? Note { get; set; }
    }
}

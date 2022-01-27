﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manav_Otomasyonu.Entities
{
  public  class Customers
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
    }
}

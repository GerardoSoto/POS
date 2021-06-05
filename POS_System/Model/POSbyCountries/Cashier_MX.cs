using POS_System.Contracts;
using POS_System.Model;
using POS_System.Services;
using System;
using System.Collections.Generic;

namespace POS_System.Model
{
    public class Cashier_MX : Cashier
    {
        public Cashier_MX(string currency)
            : base( new decimal[] { 500.00m, 200.00m, 100.00m, 50.00m, 20.00m, 10.00m, 5.00m, 2.00m, 1.00m, 0.50m, 0.20m, 0.10m, 0.05m }, currency)
        {

        }
    }
}

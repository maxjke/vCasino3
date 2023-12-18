﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class Balance : Entity
    {
        public Balance(double amount)
        {
            Amount = amount;
        }

        private double Amount {  get; set; }

        public void setAmount(double x)
        {
            this.Amount = x;
        }
        public double getAmount() 
        {
            return this.Amount;
        }
    }
}

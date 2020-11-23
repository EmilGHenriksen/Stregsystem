using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    public class SeasonalProduct : Product
    {
        public SeasonalProduct(int id, string name, decimal price, bool active, bool canBeBoughtOnCredit, DateTime seasonStartDate, DateTime seasonEndDate) : base(id, name, price, active, canBeBoughtOnCredit)
        {

        }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
    }
}

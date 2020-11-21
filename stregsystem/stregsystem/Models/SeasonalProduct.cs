using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    public class SeasonalProduct : Product
    {
        public SeasonalProduct(int id, DateTime seasonStartDate, DateTime seasonEndDate) : base(id)
        {

        }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
    }
}

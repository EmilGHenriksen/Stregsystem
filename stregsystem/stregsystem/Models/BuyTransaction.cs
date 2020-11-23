using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    class BuyTransaction : Transaction
    {
        public BuyTransaction(User user) : base(user)
        {

        }
        public decimal PriceAmount { get; set; }

        public override void Execute()
        {

        }


        /*
         * Skal indeholde "tale om et køb,
         * beløb, bruger, produkt, hvornår købet blev foretaget, og transaktionens id"
         */
        public override string ToString()
        {
           throw new NotImplementedException();
        }
    }
}

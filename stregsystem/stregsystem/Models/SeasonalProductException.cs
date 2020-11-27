using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    [Serializable]
    class SeasonalProductException : Exception
    {
        public SeasonalProductException()
        {

        }

        public SeasonalProductException(string message) : base(message)
        {

        }

        public SeasonalProductException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

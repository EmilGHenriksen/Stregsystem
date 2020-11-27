using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    [Serializable]
    class InsufficientCreditsException : Exception
    {
        public User User { get; }
        public Product Product { get; }

        public InsufficientCreditsException()
        {

        }

        public InsufficientCreditsException(string message) : base(message)
        {

        }

        public InsufficientCreditsException(string message, Exception inner) : base(message, inner)
        {

        }

        public InsufficientCreditsException(string message, User user, Product product) : base(message)
        {
            Product = product;
            User = user;
        }
    }
}

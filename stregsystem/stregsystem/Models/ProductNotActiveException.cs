using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    [Serializable]
    class ProductNotActiveException : Exception
    {
        public User User { get; }
        public Product Product { get; }
        public ProductNotActiveException()
        {

        }

        public ProductNotActiveException(string message) : base(message)
        {

        }
        public ProductNotActiveException(string message, Exception inner) : base(message, inner)
        {

        }

        public ProductNotActiveException(string message, User user, Product product) : base(message)
        {
            Product = product;
            User = user;
        }
    }
}

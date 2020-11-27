using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    [Serializable]
    class ProductDoesNotExistException : Exception
    {
        public Product Product { get; }
        public ProductDoesNotExistException()
        {

        }

        public ProductDoesNotExistException(string message) : base(message)
        {

        }
        public ProductDoesNotExistException(string message, Exception inner) : base(message, inner)
        {

        }

        public ProductDoesNotExistException(string message, Product product) : base(message)
        {
            Product = product;
        }
    }
}

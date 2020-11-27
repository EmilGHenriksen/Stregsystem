using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    [Serializable]
    class UserDoesNotExistException : Exception
    {
        public User User { get; }
        public UserDoesNotExistException()
        {

        }

        public UserDoesNotExistException(string message) : base(message)
        {

        }
        public UserDoesNotExistException(string message, Exception inner) : base(message, inner)
        {

        }

        public UserDoesNotExistException(string message, User user) : base(message)
        {
            User = user;
        }
    }
}

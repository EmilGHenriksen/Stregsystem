using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    class User : IComparable<User>
    {
        static int nextId = 0;
        public User(string firstName, string lastName, string username, string email)
        {
            id = nextId++;
            FirstName = firstName;
            LastName = lastName;
            UserName = username;
            Email = email;
        }
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Email;
        }
        public int CompareTo(User obj)
        {
            if (obj.id > id)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}

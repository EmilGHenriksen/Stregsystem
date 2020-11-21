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
            Id = nextId++;
            Firstname = firstName;
            Lastname = lastName;
            Username = username;
            Email = email;
        }
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }

        public override string ToString()
        {
            return Firstname + " " + Lastname + " " + Email;
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

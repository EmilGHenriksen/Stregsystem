﻿using System;
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
            Username = username;
            Email = email;
            if (firstName == null)
            {
                throw new ArgumentNullException("First name cannot be null");
            }
            else
                Firstname = firstName;
            if (lastName == null)
            {
                throw new ArgumentNullException("Last name cannot be null");
            }
            else
                Lastname = lastName;
        }
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }

        public override string ToString()
        {
            return Firstname + " " + Lastname + " (" + Email + ")";
        }
        public int CompareTo(User obj)
        {
            if (obj.Id > Id)
            {
                return 1;
            }
            else
            {
                return -1;
            }

        }
        // TODO: Gethashcode
    }
}

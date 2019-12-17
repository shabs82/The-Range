using System;
using System.Collections.Generic;
using System.Text;
using TheRange.Core.Entity;




namespace TheRange.Core.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsAdmin { get; set; }
    }
}

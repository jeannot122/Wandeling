using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WandelApp.Models
{
    public class User
    {
        [PrimaryKey]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string UserCatogory { get; set; }


    }
}

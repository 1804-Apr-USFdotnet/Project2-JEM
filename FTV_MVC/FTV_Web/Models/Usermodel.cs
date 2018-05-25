using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FTV_Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string InGameName { get; set; }

        public bool Admin { get; set; }
    }
}
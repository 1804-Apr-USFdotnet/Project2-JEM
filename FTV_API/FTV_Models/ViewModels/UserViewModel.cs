using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FTV.DAL.Models;

namespace FTV.DAL.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string InGameName { get; set; }
    }
}
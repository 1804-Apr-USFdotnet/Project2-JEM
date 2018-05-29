using System.Collections.Generic;
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
        
        public string Password { get; set; }

        public bool Admin { get; set; }

        public ICollection<FollowedPlayerViewModel> FollowedPlayers { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
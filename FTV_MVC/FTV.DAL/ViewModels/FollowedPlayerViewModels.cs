using System.ComponentModel.DataAnnotations;

namespace FTV.DAL.ViewModels
{
    public class FollowedPlayerViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string InGameName { get; set; }
        public int UserId { get; set; }
    }
}

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

    public class CreateFollowedPlayerViewModel
    {
        [StringLength(400, MinimumLength = 10, ErrorMessage = "Character limit of 400 reached")]
        [DataType(DataType.MultilineText)]
        public string InGameName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTV.DAL.Models
{
    [Table("Followed Player", Schema = "FTV")]
    public class FollowedPlayer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Followed Player's in game name is required")]
        public string InGameName { get; set; }


        [ScaffoldColumn(false)] public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
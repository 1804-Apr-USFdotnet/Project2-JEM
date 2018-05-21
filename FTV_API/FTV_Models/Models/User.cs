using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Web.Http.Results;

namespace FTV.DAL.Models
{
    [Table("User", Schema = "FTV")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        //[Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

       // [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(64, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 64 characters.")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Email Address is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public string InGameName { get; set; }

        public virtual ICollection<FollowedPlayer> FollowedPlayers { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        //DateTime
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
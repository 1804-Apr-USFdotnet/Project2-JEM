using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTV.DAL.Models
{
    [Table("Comment", Schema = "FTV")]
    public class Comment
    {
        //Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [StringLength(400, MinimumLength = 10, ErrorMessage = "Character limit of 400 reached")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        //Foreign Key
        [Required] public int UserId { get; set; }

        public virtual User User { get; set; }

        //DateTime
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
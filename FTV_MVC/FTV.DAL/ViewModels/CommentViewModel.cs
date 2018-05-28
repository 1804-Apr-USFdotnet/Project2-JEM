using System;
using System.ComponentModel.DataAnnotations;

namespace FTV.DAL.ViewModels
{
    public class CommentViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Body { get; set; }

        public virtual int UserId { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }

    public class EditCommentViewModel
    {
        [StringLength(400, MinimumLength = 10, ErrorMessage = "Character limit of 400 reached")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }

    public class CreateCommentViewModel
    {
        [StringLength(400, MinimumLength = 10, ErrorMessage = "Character limit of 400 reached")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [ScaffoldColumn(false)]
        public int UserId { get; set; }
    }
}

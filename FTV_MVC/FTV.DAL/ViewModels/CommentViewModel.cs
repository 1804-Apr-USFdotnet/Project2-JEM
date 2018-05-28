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
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Body { get; set; }

    }
}

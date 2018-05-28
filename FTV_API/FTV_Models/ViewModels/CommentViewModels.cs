using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FTV.DAL.Models;

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
        public string Body { get; set; }
    }

    public class CreateCommentViewModel
    {
        [StringLength(400, MinimumLength = 10, ErrorMessage = "Character limit of 400 reached")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public int UserId { get; set; }
    }
}
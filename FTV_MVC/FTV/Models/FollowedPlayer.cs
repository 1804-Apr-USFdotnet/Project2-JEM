using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FTV.Models
{
    public class FollowedPlayer
    {
        public int id { get; set; }

        [Required]
        public string InGameName { get; set; }


        public int FollowerId { get; set; }
    }
}
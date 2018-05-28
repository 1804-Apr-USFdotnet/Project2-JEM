using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTV.DAL.Models;

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

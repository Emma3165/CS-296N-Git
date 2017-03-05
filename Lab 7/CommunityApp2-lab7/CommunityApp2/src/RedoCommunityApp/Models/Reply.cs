using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedoCommunityApp.Models
{
    public class Reply
    {
        public int ReplyID { get; set; }

        [Display(Name = "Reply Text")]
        public string Body { get; set; }
    }
}

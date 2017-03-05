using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eugene.Models
{
    public class Reply
    {
        public int ReplyID { get; set; }
        public string Subject { get; set; }

        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; }

    }
}

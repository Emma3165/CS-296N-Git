using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eugene.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public int Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Member From { get; set; }
        public string Topic { get; set; }
    }
}

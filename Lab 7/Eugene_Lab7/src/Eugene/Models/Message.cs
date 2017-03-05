using System;
using System.Collections.Generic;
using Eugene.Models;
using System.Threading.Tasks;

namespace Eugene.Models
{ 
    public class Message
    {
        public int MessageID { get; set; }
        public int Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        //private List<Member> members = new List<Member>();

        //public List<Member> Members { get { return Members; } }
        public DateTime Date { get; set; }
        public Member From { get; set; }
        public string Topic { get; set; }
    }
}

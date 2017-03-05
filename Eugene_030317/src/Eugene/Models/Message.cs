using System;
using System.Collections.Generic;
using Eugene.Models;
using System.Threading.Tasks;

namespace Eugene.Models
{ 
    public class Message
    {

        private Member member = new Member();
        private List<Reply> replies = new List<Reply>();
       

        public int MessageID { get; set; }
        public int Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

       

        public List<Reply> Replies { get { return replies; } }
        public DateTime Date { get; set; }
        public Member From { get; set; }
        public string Topic { get; set; }
    }
}

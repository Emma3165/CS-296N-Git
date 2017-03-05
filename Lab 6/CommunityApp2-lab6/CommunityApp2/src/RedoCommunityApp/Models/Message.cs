using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedoCommunityApp.Models
{
    public class Message
    {
        private Member member = new Member();
        public int MessageID { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public DateTime Date { get; set; }

        public Member From { get { return member; } set { member = value; } }

        public string Topic { get; set; }


    }

}

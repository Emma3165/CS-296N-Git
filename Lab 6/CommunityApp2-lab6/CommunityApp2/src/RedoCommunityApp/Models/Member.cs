using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedoCommunityApp.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            Member memberObj = obj as Member;
            if (memberObj == null)
                return false;
            else
                return Name == memberObj.Name && Email == memberObj.Email;
        }

    }
}

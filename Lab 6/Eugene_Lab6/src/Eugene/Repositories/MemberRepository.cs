using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eugene.Models;

namespace Eugene.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public List<Member> GetAllMemberAlphabetic()
        {
            var members = new List<Member>();
            members.Add(new Models.Member() { Name = "Paul Jones", Email = "pjones@gmail.com" });
            members.Add(new Models.Member() { Name = "Sandra Bullock", Email = "sbullock@gmail.com" });
            members.Add(new Models.Member() { Name = "Sean Banks", Email = "sbanks@gmail.com" });
            return members;
        }

        public List<Member> GetMemberByEmail()
        {
            throw new NotImplementedException();
        }

        public List<Member> GetMembersByMessage()
        {
            throw new NotImplementedException();
        }
        public Member CanChangeMemberEmail()
        {
            throw new NotImplementedException();
        }

    }
}

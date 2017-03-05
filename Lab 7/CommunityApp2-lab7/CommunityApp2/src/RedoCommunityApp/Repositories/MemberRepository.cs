using RedoCommunityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RedoCommunityApp.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private ApplicationDBContext context;

        public MemberRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Member> GetAllMembers()
        {
            return context.Members;
            
        }

        public Member GetMemberByEmail(string email)
        {
            List<Member> members = new List<Member>();

            members.Add(new Member()
            {
                Name = "John Doe",
                Email = "jdoe@fake.com"

            });



            members.Add(new Member()
            {
                Name = "Jane Doe",
                Email = "jadoe@fake.com"

            });

            foreach (var m in members)
            {
                if (m.Email == email)
                    return m;
                

            }
            return null;

        }
    }
}

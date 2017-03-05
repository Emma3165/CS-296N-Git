using RedoCommunityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RedoCommunityApp.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public List<Member> GetAllMembers()
        {
            List<Member> members = new List<Member>();

            members.Add(new Member()
            {
                Name = "John Smith",
                Email = "jsmith@fake.com"

            });

         

            members.Add(new Member()
            {
                Name = "Jane Smith",
                Email = "jasmith@fake.com"

            });


            return members;

            
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

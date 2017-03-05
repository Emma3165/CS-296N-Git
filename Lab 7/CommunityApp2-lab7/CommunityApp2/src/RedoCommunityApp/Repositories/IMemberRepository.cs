using RedoCommunityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedoCommunityApp.Repositories
{
    public interface IMemberRepository
    {
        Member GetMemberByEmail(string email);
        IEnumerable<Member> GetAllMembers();

    }
}

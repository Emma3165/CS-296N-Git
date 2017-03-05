using CommunityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityApp.Repositories
{
    public interface IMemberRepository
    {
        Member GetMemberByEmail(string email);
        List<Member> GetAllMembers();

    }
}

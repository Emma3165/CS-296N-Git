using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eugene.Models;

namespace Eugene.Repositories
{
    public interface IMemberRepository
    {
        List<Member> GetAllMemberAlphabetic();
        List<Member> GetMembersByMessage();
        List<Member> GetMemberByEmail();
        Member CanChangeMemberEmail();

    }
}

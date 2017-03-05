using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PartyInvites.Models
{
    public static class Repository
    {

        private static List<GuestResponse> responses = new List<GuestResponse>();

        public static IEnumerable<GuestResponse> Responses
        {
            get { return responses; }
        }


        public static void AddResponse(GuestResponse response)
        {
            responses.Add(response);
        }
    }
}
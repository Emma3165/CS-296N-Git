using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Eugene.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            if (!context.Messages.Any())
            {

                Member member = new Member { Name = "Sandra Bullock" };
                context.Members.Add(member);
                context.Messages.Add(
                    new Message
                    {
                        Subject = "Event",
                        Body = "Fund raising for school supply",
                        Date = DateTime.Parse("2016/10/23"),
                        From = member,
                        Topic = "Fund raising",

                    }
                    );


                member = new Member { Name = "Sean Banks" };
                context.Members.Add(member);
                context.Messages.Add(
                new Message
                {
                    Subject = "Sale",
                    Body = "Community yard sale event for school trip",
                    Date = DateTime.Parse("2017/1/22"),
                    From = member,
                    Topic = "Yard sale",

                });

                member = new Member { Name = "Paul Jones" };
                context.Members.Add(member);
                context.Messages.Add(
                      new Message
                      {
                          Subject = "Sale",
                          Body = "Community art sale for veteran housing",
                          Date = DateTime.Parse("2016/12/10"),
                          From = member,
                          Topic = "Art sale",

                      });

                member = new Member { Name = "Sean Banks" };
                context.Members.Add(member);
                context.Messages.Add(
                       new Message
                       {
                           Subject = "Meeting",
                           Body = "City hall meeting",
                           Date = DateTime.Parse("2016/5/28"),
                           From = member,
                           Topic = "Neighborhood watch",
                       }
                    );
                context.SaveChanges();
            }
        }
    }
}

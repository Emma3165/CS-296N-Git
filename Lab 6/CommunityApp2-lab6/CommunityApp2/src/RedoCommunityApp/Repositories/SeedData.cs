using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedoCommunityApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace RedoCommunityApp.Repositories
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDBContext context = app.ApplicationServices.
                GetRequiredService<ApplicationDBContext>();

          if (!context.Messages.Any())
          {
                
                Member member = new Member
                {
                    Name = "Jane Doe",
                    Email = "jadoe@fake.com"
                };
                context.Members.Add(member);

                context.Messages.AddRange(
                 new Message
                 {
                     Subject = "Fun",
                     Date = DateTime.Parse("1/1/1937"),
                     Body = "Code is fun",
                     From = member,
                     Topic = "code"
                 }
                 );

                   member = new Member
                {
                    Name = "John Smith",
                    Email = "jsmith@fake.com"
                };
                context.Members.Add(member);

                context.Messages.AddRange(
                 new Message
                 {
                     Subject = "sql",
                     Date = DateTime.Parse("1/1/1937"),
                     Body = "sql is war",
                     From = member,
                     Topic = "database"
                 }
                 );

                 member = new Member
                {
                    Name = "Jane Smith",
                    Email = "jasmith@fake.com"
                };
                context.Members.Add(member);

                context.Messages.AddRange(
                 new Message
                 {
                     Subject = "fun",
                     Date = DateTime.Parse("1/1/1937"),
                     Body = "Database is fun",
                     From = member,
                     Topic = "database"
                 }
                 );

                context.Messages.AddRange(new Message
                {
                    Subject = "database fun",
                    Date = DateTime.Parse("1/1/1937"),
                    Body = "Database is fun if you want it to be",
                    From = member,
                    Topic = "database"
                }
                    );

                



           }
            context.SaveChanges();
        }

    }
}

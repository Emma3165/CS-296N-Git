using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Eugene.Models;

namespace Eugene.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170215212530_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Eugene.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("Date");

                    b.Property<string>("From");

                    b.Property<string>("Subject");

                    b.Property<string>("Topic");

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });
        }
    }
}

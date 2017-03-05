using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RedoCommunityApp.Repositories;

namespace RedoCommunityApp.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20170214184516_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RedoCommunityApp.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("MemberID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("RedoCommunityApp.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("FromMemberID");

                    b.Property<string>("Subject");

                    b.Property<string>("Topic");

                    b.HasKey("MessageID");

                    b.HasIndex("FromMemberID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("RedoCommunityApp.Models.Message", b =>
                {
                    b.HasOne("RedoCommunityApp.Models.Member", "From")
                        .WithMany()
                        .HasForeignKey("FromMemberID");
                });
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Eugene.Models;

namespace Eugene.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170222194436_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Eugene.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int?>("MessageID");

                    b.Property<string>("Name");

                    b.HasKey("MemberID");

                    b.HasIndex("MessageID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Eugene.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("Date");

                    b.Property<string>("From");

                    b.Property<int>("Name");

                    b.Property<string>("Subject");

                    b.Property<string>("Topic");

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Eugene.Models.Member", b =>
                {
                    b.HasOne("Eugene.Models.Message")
                        .WithMany("Members")
                        .HasForeignKey("MessageID");
                });
        }
    }
}

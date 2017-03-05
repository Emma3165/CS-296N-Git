using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Eugene.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "Messages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    MessageID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Member_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "MessageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Member_MessageID",
                table: "Member",
                column: "MessageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Messages");
        }
    }
}

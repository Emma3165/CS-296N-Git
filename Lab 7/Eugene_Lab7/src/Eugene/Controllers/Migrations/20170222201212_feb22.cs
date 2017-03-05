using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eugene.Migrations
{
    public partial class feb22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Messages_MessageID",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_MessageID",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageID",
                table: "Member");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.AddColumn<int>(
                name: "FromMemberID",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromMemberID",
                table: "Messages",
                column: "FromMemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Members_FromMemberID",
                table: "Messages",
                column: "FromMemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Members_FromMemberID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromMemberID",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FromMemberID",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MessageID",
                table: "Member",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_MessageID",
                table: "Member",
                column: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Messages_MessageID",
                table: "Member",
                column: "MessageID",
                principalTable: "Messages",
                principalColumn: "MessageID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

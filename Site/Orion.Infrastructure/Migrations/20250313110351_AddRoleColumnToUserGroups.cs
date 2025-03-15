using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleColumnToUserGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "JoinedAt",
                table: "UserGroups");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "UserGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserGroups");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "UserGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedAt",
                table: "UserGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

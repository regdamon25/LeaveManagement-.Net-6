using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c209edbc-61e8-4355-81c6-9dc48a639a13", "c7cc35ce-11d7-4ae3-bf3d-f99890ca120c", "User", "USER" },
                    { "d635121f-4acf-41b0-a8f5-2aa2a120ffeb", "0e3c7cb2-8111-4aa4-97b3-8f61667a64df", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "26c61fd0-67c1-4769-a2a8-95fbe5dd8750", 0, "17e1ab85-8150-4d70-a702-1740487e8f05", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@local.com", false, "System", "Admin", false, null, "ADMIN@LOCAL.COM", null, "AQAAAAEAACcQAAAAEBvd+bxUEPRqIwh9ZY+Pxchr4qlgk+nj+SrGmF+xNh02bGJ3YKNk6I5vBetPnmbsVw==", null, false, "8e20d1bb-b9bc-4be1-8e96-20525e74b0da", null, false, null },
                    { "808d5c0c-0b1f-49c4-9bf8-0223299a3c87", 0, "2c3e4f94-265b-4377-b237-1788c78b1855", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@Localhost.com", false, "System", "User", false, null, "USER@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAENlaNq9WrqjNKrdV+D9Ebj4Ng5gvpNtjCWSKCKfyfjukXiY+AmoAwpVaquCWROY2ZA==", null, false, "b4cd74c5-559b-462a-b8af-8f6632adf52d", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d635121f-4acf-41b0-a8f5-2aa2a120ffeb", "26c61fd0-67c1-4769-a2a8-95fbe5dd8750" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c209edbc-61e8-4355-81c6-9dc48a639a13", "808d5c0c-0b1f-49c4-9bf8-0223299a3c87" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d635121f-4acf-41b0-a8f5-2aa2a120ffeb", "26c61fd0-67c1-4769-a2a8-95fbe5dd8750" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c209edbc-61e8-4355-81c6-9dc48a639a13", "808d5c0c-0b1f-49c4-9bf8-0223299a3c87" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c209edbc-61e8-4355-81c6-9dc48a639a13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d635121f-4acf-41b0-a8f5-2aa2a120ffeb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26c61fd0-67c1-4769-a2a8-95fbe5dd8750");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "808d5c0c-0b1f-49c4-9bf8-0223299a3c87");
        }
    }
}

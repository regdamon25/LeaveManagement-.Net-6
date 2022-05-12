using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefaultUsersUsernames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c209edbc-61e8-4355-81c6-9dc48a639a13",
                column: "ConcurrencyStamp",
                value: "2bd52210-c1ad-4271-a2e4-d2fd8a383516");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d635121f-4acf-41b0-a8f5-2aa2a120ffeb",
                column: "ConcurrencyStamp",
                value: "7aabcc6c-5c9c-4e70-8204-832b4d1df2d2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26c61fd0-67c1-4769-a2a8-95fbe5dd8750",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a994eb50-5f78-4cf4-9f54-11d3c57f9fc1", true, "ADMIN@LOCAL.COM", "AQAAAAEAACcQAAAAEBIo9/33Lljxkk5VJlXih7LzmPvvXxrrFtjRq9qeMVWrxuTFo6aubZ3Bs3a7i+a0JA==", "ae02ae91-8a22-4c9b-9516-506ab7c02a84", "admin@local.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "808d5c0c-0b1f-49c4-9bf8-0223299a3c87",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5809d8d7-9342-4bde-87a7-5d626e9dffb2", true, "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEN+Dl0Uuy31EkuxmJABwGM+UiOZFw2/4R4lW0TWcl2TXQLkpJp4UVYZLc4EIFqdb2Q==", "d0bc98ce-4437-441c-b316-2f7cec4d9d4e", "user@Localhost.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c209edbc-61e8-4355-81c6-9dc48a639a13",
                column: "ConcurrencyStamp",
                value: "c7cc35ce-11d7-4ae3-bf3d-f99890ca120c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d635121f-4acf-41b0-a8f5-2aa2a120ffeb",
                column: "ConcurrencyStamp",
                value: "0e3c7cb2-8111-4aa4-97b3-8f61667a64df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26c61fd0-67c1-4769-a2a8-95fbe5dd8750",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "17e1ab85-8150-4d70-a702-1740487e8f05", false, null, "AQAAAAEAACcQAAAAEBvd+bxUEPRqIwh9ZY+Pxchr4qlgk+nj+SrGmF+xNh02bGJ3YKNk6I5vBetPnmbsVw==", "8e20d1bb-b9bc-4be1-8e96-20525e74b0da", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "808d5c0c-0b1f-49c4-9bf8-0223299a3c87",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "2c3e4f94-265b-4377-b237-1788c78b1855", false, null, "AQAAAAEAACcQAAAAENlaNq9WrqjNKrdV+D9Ebj4Ng5gvpNtjCWSKCKfyfjukXiY+AmoAwpVaquCWROY2ZA==", "b4cd74c5-559b-462a-b8af-8f6632adf52d", null });
        }
    }
}

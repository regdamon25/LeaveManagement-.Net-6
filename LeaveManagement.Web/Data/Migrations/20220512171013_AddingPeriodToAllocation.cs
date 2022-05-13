using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddingPeriodToAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c209edbc-61e8-4355-81c6-9dc48a639a13",
                column: "ConcurrencyStamp",
                value: "064cfd30-ac05-4397-b03a-e0dee1411f24");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d635121f-4acf-41b0-a8f5-2aa2a120ffeb",
                column: "ConcurrencyStamp",
                value: "37f43f97-21dd-438a-89ef-707a9d256d1f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26c61fd0-67c1-4769-a2a8-95fbe5dd8750",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "913a3091-387d-4867-aa3b-87d840a4d5d6", "AQAAAAEAACcQAAAAEL5xikPxmZVtA5ahNCS9TWd3uOcCb4VtAKMtYOlQTe3jqfaa5VGsUP0AY30XIavQ9A==", "5709ba53-afe3-493b-b5ef-81c7feb56edd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "808d5c0c-0b1f-49c4-9bf8-0223299a3c87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c57e5c9-7af1-4cdd-a461-c3e4a8c4a60c", "AQAAAAEAACcQAAAAEBn2099Da3V9uvAWfLOhFL75j+Zhjen4yxFCauigEUbayu97EDeY0RpfU9fUhaSJIA==", "c9164450-72cf-4e6b-b7d9-fa2474e9299a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a994eb50-5f78-4cf4-9f54-11d3c57f9fc1", "AQAAAAEAACcQAAAAEBIo9/33Lljxkk5VJlXih7LzmPvvXxrrFtjRq9qeMVWrxuTFo6aubZ3Bs3a7i+a0JA==", "ae02ae91-8a22-4c9b-9516-506ab7c02a84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "808d5c0c-0b1f-49c4-9bf8-0223299a3c87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5809d8d7-9342-4bde-87a7-5d626e9dffb2", "AQAAAAEAACcQAAAAEN+Dl0Uuy31EkuxmJABwGM+UiOZFw2/4R4lW0TWcl2TXQLkpJp4UVYZLc4EIFqdb2Q==", "d0bc98ce-4437-441c-b316-2f7cec4d9d4e" });
        }
    }
}

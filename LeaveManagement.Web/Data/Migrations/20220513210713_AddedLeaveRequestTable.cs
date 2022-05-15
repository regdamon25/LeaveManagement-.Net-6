using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequestd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c209edbc-61e8-4355-81c6-9dc48a639a13",
                column: "ConcurrencyStamp",
                value: "25fbb755-66a2-4551-b77e-a826e4efb7d7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d635121f-4acf-41b0-a8f5-2aa2a120ffeb",
                column: "ConcurrencyStamp",
                value: "52fdd997-3a5b-4671-bc97-dbd4a1f07a67");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26c61fd0-67c1-4769-a2a8-95fbe5dd8750",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa5ff152-693a-4f2c-b4b2-dfda8f8e0888", "AQAAAAEAACcQAAAAEOJXtJc60W/vXnInF5AsJG9HFChDJJNUAQLUzNQWCIxCkk9bHBSQ+oVKN0r1Mmv9Rg==", "ea8cf3ef-5f11-4d80-8504-ffb1c3b5427c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "808d5c0c-0b1f-49c4-9bf8-0223299a3c87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "000eabf8-1293-4446-95c6-dd890d63b178", "AQAAAAEAACcQAAAAEKxLAU1tlzhJN4ZTXM/8SCH+eHiFFkIxjxnb8ViShE8Mei/g4Vb51YZ0LWYK0HnayA==", "eff5da45-69ce-4b4c-b557-ea2bd5cfda01" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}

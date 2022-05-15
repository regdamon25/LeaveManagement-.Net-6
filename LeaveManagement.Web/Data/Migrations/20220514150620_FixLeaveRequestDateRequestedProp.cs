using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class FixLeaveRequestDateRequestedProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateRequestd",
                table: "LeaveRequests",
                newName: "DateRequested");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c209edbc-61e8-4355-81c6-9dc48a639a13",
                column: "ConcurrencyStamp",
                value: "c2cb2fcf-2c7d-4088-b89a-c9f7a46c76ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d635121f-4acf-41b0-a8f5-2aa2a120ffeb",
                column: "ConcurrencyStamp",
                value: "28299855-1709-489d-8ea3-cbcb197a4f51");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26c61fd0-67c1-4769-a2a8-95fbe5dd8750",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28976d74-9a09-47de-b8a0-af2b78ca60c8", "AQAAAAEAACcQAAAAEBkyHf1vky/RaXHZuLVqLCjwsO3REbp7HVHOqeRE2a4PSG653NQIe+/W+zOfhK208Q==", "3ca28983-e06d-4635-9ab0-9363fb3fd635" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "808d5c0c-0b1f-49c4-9bf8-0223299a3c87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "286b37ce-3390-48cd-ba57-df8e733d448e", "AQAAAAEAACcQAAAAEFSOTQgb/y4iFm+Ui91H8i4gcmi+1bVecnN7Cv1Ou2OreSNtj8QyGjb8ALmS6rOF9w==", "cca1977a-96ed-474c-a4b0-4e2a2456e47a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateRequested",
                table: "LeaveRequests",
                newName: "DateRequestd");

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
        }
    }
}

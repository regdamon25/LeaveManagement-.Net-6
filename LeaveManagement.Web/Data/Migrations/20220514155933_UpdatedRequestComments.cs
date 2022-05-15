using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class UpdatedRequestComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c209edbc-61e8-4355-81c6-9dc48a639a13",
                column: "ConcurrencyStamp",
                value: "a5f23616-9443-4dd5-aad0-5c8929a41707");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d635121f-4acf-41b0-a8f5-2aa2a120ffeb",
                column: "ConcurrencyStamp",
                value: "ad4fadaa-c610-4d46-87e7-66b1815b3081");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26c61fd0-67c1-4769-a2a8-95fbe5dd8750",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f6ab726-49a3-4ab3-a786-238a341cb065", "AQAAAAEAACcQAAAAEKQ2uqLj4FD6smbupoFJopgU4gerNlaElQRRJMlSKZjphPHDqp2uu1wjKMMkbxFgAA==", "ba3ba1b4-9b0f-486e-84bb-3e03a11d2da2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "808d5c0c-0b1f-49c4-9bf8-0223299a3c87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "686ab9b8-116c-4bd4-8338-20afee595d5c", "AQAAAAEAACcQAAAAEKAmM82I330SwDx7ExF58MsyItObtbSfaRBjU6HMXzWi5cCEL0zUFle2Z2v1Dgy2qw==", "f14198ec-f945-4a52-9616-68cb4a8db922" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}

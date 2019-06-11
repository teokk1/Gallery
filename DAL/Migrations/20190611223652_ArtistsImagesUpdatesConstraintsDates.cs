using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ArtistsImagesUpdatesConstraintsDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "025c86e0-740f-4771-94e8-13de204b235f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48c7ee13-6e7d-4632-aed1-8259cc8c0e59");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1a4302c-8145-4409-a093-613ed8a1b233", "29fedc5c-3bd4-4340-9765-ea595efb8242", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0c89989-e681-4072-9cc4-76515467c2d2", "ec0da697-8b13-4272-b3ad-3f45c8dd86fc", "GalleryManager", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1a4302c-8145-4409-a093-613ed8a1b233");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0c89989-e681-4072-9cc4-76515467c2d2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "025c86e0-740f-4771-94e8-13de204b235f", "35962f35-4255-494b-87d3-b5df1122631c", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "48c7ee13-6e7d-4632-aed1-8259cc8c0e59", "5a01adc7-c8b6-4713-9da9-c53b7e852542", "GalleryManager", null });
        }
    }
}

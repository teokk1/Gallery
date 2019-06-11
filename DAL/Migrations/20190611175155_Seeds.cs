using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34d12c2e-c5cb-4f01-8b48-f6f8a36a18a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1f220d4-a119-47aa-91aa-55b671ca52d2");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2869d1f7-be29-47af-95dd-f97140841d7e", "6586852b-2795-47c9-ba2f-16e0213741fb", "Admin", null },
                    { "f5ee5994-7d39-4c30-b8ae-c9e64d71d955", "1d097b9e-d3f3-40fe-9edf-143374f25718", "GalleryManager", null }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { -1, "Bakar" },
                    { -2, "Ćelik" },
                    { -3, "Drvo" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Discriminator", "Height", "ImageId", "Name", "Width" },
                values: new object[] { -1, "Painting", 2f, null, "Untitled 1", 1.3f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Discriminator", "Height", "ImageId", "Name", "Width", "Depth" },
                values: new object[] { -2, "Sculpture", 2f, null, "Lopata", 1.3f, 0f });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { -1, "Apstraktno" },
                    { -2, "Realistično" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2869d1f7-be29-47af-95dd-f97140841d7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5ee5994-7d39-4c30-b8ae-c9e64d71d955");

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1f220d4-a119-47aa-91aa-55b671ca52d2", "b7ba7a5b-92e1-48cb-8d5e-17102dbd7811", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "34d12c2e-c5cb-4f01-8b48-f6f8a36a18a5", "28d96b22-d865-4db0-ad48-6ec80f09fd5a", "GalleryManager", null });
        }
    }
}

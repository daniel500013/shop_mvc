using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_mvc.Migrations
{
    public partial class dbupdate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Count", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "IPhone 11 Opis", "IPhone 11", 699m },
                    { 2, 1, "Myszka Opis", "Myszka", 699m },
                    { 3, 1, "Aparat Opis", "Aparat", 699m },
                    { 4, 1, "PS 4 Opis", "PS 4", 699m }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Email", "FirstName", "HashPassword", "LastName", "Password", "Phone", "Role", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "admin", "admin@admin.com", "admin", "AQAAAAEAACcQAAAAEGn3IGsBmSOp78M8hKtd9kLvuvl3U4PjkuR7uOp7iC2U1qsZQhL34+OzILMC4r9NoA==", "admin", "admin", "111111111", "Admin", "admin", "11-1111" },
                    { 2, "user", "user@user.com", "user", "AQAAAAEAACcQAAAAEL+tndt2YkU94ZbDzJm+dsP3RcddThDpS01b7QXKjUYuHhkuUDbzVTqa+noKHCXK6g==", "user", "user", "111111111", "User", "user", "11-1111" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

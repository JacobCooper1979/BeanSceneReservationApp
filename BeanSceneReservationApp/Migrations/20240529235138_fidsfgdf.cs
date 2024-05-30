using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneReservationApp.Migrations
{
    /// <inheritdoc />
    public partial class fidsfgdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaName",
                table: "RestaurantTables");

            migrationBuilder.AlterColumn<string>(
                name: "TableStatus",
                table: "RestaurantTables",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TableStatus",
                table: "RestaurantTables",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "AreaName",
                table: "RestaurantTables",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

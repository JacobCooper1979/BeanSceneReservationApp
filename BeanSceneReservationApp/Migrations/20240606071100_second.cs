using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneReservationApp.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantTables_Areas_AreaId",
                table: "RestaurantTables");

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "RestaurantTables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AreaName",
                table: "RestaurantTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantTables_Areas_AreaId",
                table: "RestaurantTables",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "AreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantTables_Areas_AreaId",
                table: "RestaurantTables");

            migrationBuilder.DropColumn(
                name: "AreaName",
                table: "RestaurantTables");

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "RestaurantTables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantTables_Areas_AreaId",
                table: "RestaurantTables",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneReservationApp.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Areas__70B82028021F9B83", x => x.AreaID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    RegistrationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Members__0CF04B385D3E9B78", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "SittingSchedules",
                columns: table => new
                {
                    SittingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    SCapacity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SittingS__42A14C30276D7D03", x => x.SittingID);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Staffs__96D4AAF742C351A4", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTables",
                columns: table => new
                {
                    TableID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    AreaID = table.Column<int>(type: "int", nullable: false),
                    TableStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Restaura__7D5F018EB4DAC4D3", x => x.TableID);
                    table.ForeignKey(
                        name: "FK__Restauran__AreaI__398D8EEE",
                        column: x => x.AreaID,
                        principalTable: "Areas",
                        principalColumn: "AreaID");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SittingID = table.Column<int>(type: "int", nullable: true),
                    GuestName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    NumOfGuests = table.Column<int>(type: "int", nullable: false),
                    ReservationSource = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ReservationStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TableID = table.Column<int>(type: "int", nullable: true),
                    MemberID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservat__B7EE5F048FA4C04B", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK__Reservati__Membe__44FF419A",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK__Reservati__Sitti__4316F928",
                        column: x => x.SittingID,
                        principalTable: "SittingSchedules",
                        principalColumn: "SittingID");
                    table.ForeignKey(
                        name: "FK__Reservati__Table__440B1D61",
                        column: x => x.TableID,
                        principalTable: "RestaurantTables",
                        principalColumn: "TableID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MemberID",
                table: "Reservations",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SittingID",
                table: "Reservations",
                column: "SittingID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableID",
                table: "Reservations",
                column: "TableID");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTables_AreaID",
                table: "RestaurantTables",
                column: "AreaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "SittingSchedules");

            migrationBuilder.DropTable(
                name: "RestaurantTables");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}

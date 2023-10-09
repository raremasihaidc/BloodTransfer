using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodTransferAPI.Migrations
{
    /// <inheritdoc />
    public partial class intialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodTransfers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitOfBlood = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverId = table.Column<int>(type: "int", nullable: false),
                    TransmiiterId = table.Column<int>(type: "int", nullable: false),
                    BloodGroupType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfTransmitting = table.Column<int>(type: "int", nullable: false),
                    NumberOfRecieving = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTransfers", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodTransfers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sustatron.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Commutes_VehicleId",
                table: "Commutes");

            migrationBuilder.CreateIndex(
                name: "IX_Commutes_VehicleId",
                table: "Commutes",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Commutes_VehicleId",
                table: "Commutes");

            migrationBuilder.CreateIndex(
                name: "IX_Commutes_VehicleId",
                table: "Commutes",
                column: "VehicleId",
                unique: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Art_Gallery_Management.Migrations
{
    /// <inheritdoc />
    public partial class Added_Collection_In_Exhibition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Artworks_ExhibitionId",
                table: "Artworks");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ExhibitionId",
                table: "Artworks",
                column: "ExhibitionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Artworks_ExhibitionId",
                table: "Artworks");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ExhibitionId",
                table: "Artworks",
                column: "ExhibitionId",
                unique: true);
        }
    }
}

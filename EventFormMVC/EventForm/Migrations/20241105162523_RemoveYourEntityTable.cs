using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventForm.Migrations
{
    /// <inheritdoc />
    public partial class RemoveYourEntityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Repositories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

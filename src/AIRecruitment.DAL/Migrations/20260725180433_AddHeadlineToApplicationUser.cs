using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIRecruitment.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddHeadlineToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Headline",
                table: "AspNetUsers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Headline",
                table: "AspNetUsers");
        }
    }
}

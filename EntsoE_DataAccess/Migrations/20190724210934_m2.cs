using Microsoft.EntityFrameworkCore.Migrations;

namespace EntsoE_DataAccess.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RetryCount",
                table: "GenForecastRequestLogs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RetryCount",
                table: "GenForecastRequestLogs");
        }
    }
}

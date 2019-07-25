using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntsoE_DataAccess.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "entsoe");

            migrationBuilder.CreateTable(
                name: "GenForecastRequestLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    RequestType = table.Column<string>(nullable: true),
                    InsertedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Message = table.Column<string>(nullable: true),
                    HasData = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenForecastRequestLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenForecastMeta",
                schema: "entsoe",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartPeriod = table.Column<DateTime>(nullable: false),
                    EndPeriod = table.Column<DateTime>(nullable: false),
                    IntervalMins = table.Column<int>(nullable: false),
                    mRID = table.Column<int>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    DocumentType = table.Column<string>(nullable: true),
                    ProcessType = table.Column<string>(nullable: true),
                    InsertedOn = table.Column<DateTime>(nullable: false),
                    RowCount = table.Column<int>(nullable: false),
                    GenForecastRequestLogId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenForecastMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenForecastMeta_GenForecastRequestLogs_GenForecastRequestLogId",
                        column: x => x.GenForecastRequestLogId,
                        principalTable: "GenForecastRequestLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenForecastTimeSeries",
                schema: "entsoe",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MetaId = table.Column<long>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenForecastTimeSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenForecastTimeSeries_GenForecastMeta_MetaId",
                        column: x => x.MetaId,
                        principalSchema: "entsoe",
                        principalTable: "GenForecastMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenForecastMeta_GenForecastRequestLogId",
                schema: "entsoe",
                table: "GenForecastMeta",
                column: "GenForecastRequestLogId");

            migrationBuilder.CreateIndex(
                name: "IX_GenForecastTimeSeries_MetaId",
                schema: "entsoe",
                table: "GenForecastTimeSeries",
                column: "MetaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenForecastTimeSeries",
                schema: "entsoe");

            migrationBuilder.DropTable(
                name: "GenForecastMeta",
                schema: "entsoe");

            migrationBuilder.DropTable(
                name: "GenForecastRequestLogs");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenericMonolithWebApplication.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PartRevisions",
                columns: table => new
                {
                    PartRevisionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    PartId = table.Column<Guid>(type: "char(36)", nullable: false),
                    RevisionNum = table.Column<string>(type: "longtext", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartRevisions", x => x.PartRevisionId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartId = table.Column<Guid>(type: "char(36)", nullable: false),
                    PartNum = table.Column<string>(type: "longtext", nullable: false),
                    PartDescription = table.Column<string>(type: "longtext", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "PartDescription", "PartNum" },
                values: new object[] { new Guid("31ae5210-236f-4e65-ac59-b6b16e204c9e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "MATT-NEW-PART", "MATT-NEW-PART" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartRevisions");

            migrationBuilder.DropTable(
                name: "Parts");
        }
    }
}

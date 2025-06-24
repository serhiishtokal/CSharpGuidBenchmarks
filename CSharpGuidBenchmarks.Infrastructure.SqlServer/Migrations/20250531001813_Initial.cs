using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpGuidBenchmarks.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuidV4Bin16ClusteredPkEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<byte[]>(type: "binary(16)", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV4Bin16ClusteredPkEntities", x => x.PrimaryKey);
                });

            migrationBuilder.CreateTable(
                name: "GuidV4ClusteredPkEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV4ClusteredPkEntities", x => x.PrimaryKey);
                });

            migrationBuilder.CreateTable(
                name: "GuidV7Bin16ClusteredPkEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<byte[]>(type: "binary(16)", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV7Bin16ClusteredPkEntities", x => x.PrimaryKey);
                });

            migrationBuilder.CreateTable(
                name: "GuidV7ClusteredPkEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV7ClusteredPkEntities", x => x.PrimaryKey);
                });

            migrationBuilder.CreateTable(
                name: "IntClusteredPrimaryKeyEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntClusteredPrimaryKeyEntities", x => x.PrimaryKey);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuidV4Bin16ClusteredPkEntities");

            migrationBuilder.DropTable(
                name: "GuidV4ClusteredPkEntities");

            migrationBuilder.DropTable(
                name: "GuidV7Bin16ClusteredPkEntities");

            migrationBuilder.DropTable(
                name: "GuidV7ClusteredPkEntities");

            migrationBuilder.DropTable(
                name: "IntClusteredPrimaryKeyEntities");
        }
    }
}

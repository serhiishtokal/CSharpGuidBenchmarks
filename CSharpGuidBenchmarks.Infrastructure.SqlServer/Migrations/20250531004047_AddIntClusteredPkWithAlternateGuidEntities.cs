using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpGuidBenchmarks.Migrations
{
    /// <inheritdoc />
    public partial class AddIntClusteredPkWithAlternateGuidEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntClusteredPkWithAlternateGuidV4Bin16Entities",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlternateKey = table.Column<byte[]>(type: "binary(16)", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntClusteredPkWithAlternateGuidV4Bin16Entities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_IntClusteredPkWithAlternateGuidV4Bin16Entities_AlternateKey", x => x.AlternateKey);
                });

            migrationBuilder.CreateTable(
                name: "IntClusteredPkWithAlternateGuidV4Entities",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntClusteredPkWithAlternateGuidV4Entities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_IntClusteredPkWithAlternateGuidV4Entities_AlternateKey", x => x.AlternateKey);
                });

            migrationBuilder.CreateTable(
                name: "IntClusteredPkWithAlternateGuidV7Bin16Entities",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlternateKey = table.Column<byte[]>(type: "binary(16)", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntClusteredPkWithAlternateGuidV7Bin16Entities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_IntClusteredPkWithAlternateGuidV7Bin16Entities_AlternateKey", x => x.AlternateKey);
                });

            migrationBuilder.CreateTable(
                name: "IntClusteredPkWithAlternateGuidV7Entities",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntClusteredPkWithAlternateGuidV7Entities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_IntClusteredPkWithAlternateGuidV7Entities_AlternateKey", x => x.AlternateKey);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntClusteredPkWithAlternateGuidV4Bin16Entities");

            migrationBuilder.DropTable(
                name: "IntClusteredPkWithAlternateGuidV4Entities");

            migrationBuilder.DropTable(
                name: "IntClusteredPkWithAlternateGuidV7Bin16Entities");

            migrationBuilder.DropTable(
                name: "IntClusteredPkWithAlternateGuidV7Entities");
        }
    }
}

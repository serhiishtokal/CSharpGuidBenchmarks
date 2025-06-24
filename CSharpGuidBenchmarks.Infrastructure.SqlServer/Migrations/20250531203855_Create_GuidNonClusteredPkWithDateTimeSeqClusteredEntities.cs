using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpGuidBenchmarks.Migrations
{
    /// <inheritdoc />
    public partial class Create_GuidNonClusteredPkWithDateTimeSeqClusteredEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuidV4Bin16NonClusteredPkWithDateTimeSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<byte[]>(type: "binary(16)", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV4Bin16NonClusteredPkWithDateTimeSeqClusteredEntities", x => x.PrimaryKey)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_GuidV4Bin16NonClusteredPkWithDateTimeSeqClusteredEntities_AlternateKey", x => x.AlternateKey)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "GuidV4NonClusteredPkWithDateTimeSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV4NonClusteredPkWithDateTimeSeqClusteredEntities", x => x.PrimaryKey)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_GuidV4NonClusteredPkWithDateTimeSeqClusteredEntities_AlternateKey", x => x.AlternateKey)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "GuidV7Bin16NonClusteredPkWithDateTimeSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<byte[]>(type: "binary(16)", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV7Bin16NonClusteredPkWithDateTimeSeqClusteredEntities", x => x.PrimaryKey)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_GuidV7Bin16NonClusteredPkWithDateTimeSeqClusteredEntities_AlternateKey", x => x.AlternateKey)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "GuidV7NonClusteredPkWithDateTimeSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV7NonClusteredPkWithDateTimeSeqClusteredEntities", x => x.PrimaryKey)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_GuidV7NonClusteredPkWithDateTimeSeqClusteredEntities_AlternateKey", x => x.AlternateKey)
                        .Annotation("SqlServer:Clustered", true);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuidV4Bin16NonClusteredPkWithDateTimeSeqClusteredEntities");

            migrationBuilder.DropTable(
                name: "GuidV4NonClusteredPkWithDateTimeSeqClusteredEntities");

            migrationBuilder.DropTable(
                name: "GuidV7Bin16NonClusteredPkWithDateTimeSeqClusteredEntities");

            migrationBuilder.DropTable(
                name: "GuidV7NonClusteredPkWithDateTimeSeqClusteredEntities");
        }
    }
}

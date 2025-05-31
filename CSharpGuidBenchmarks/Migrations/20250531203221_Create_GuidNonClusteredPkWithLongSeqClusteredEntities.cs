using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpGuidBenchmarks.Migrations
{
    /// <inheritdoc />
    public partial class Create_GuidNonClusteredPkWithLongSeqClusteredEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<byte[]>(type: "binary(16)", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntities", x => x.PrimaryKey)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntities_AlternateKey", x => x.AlternateKey)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "GuidV4NonClusteredPkWithLongSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV4NonClusteredPkWithLongSeqClusteredEntities", x => x.PrimaryKey)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_GuidV4NonClusteredPkWithLongSeqClusteredEntities_AlternateKey", x => x.AlternateKey)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<byte[]>(type: "binary(16)", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntities", x => x.PrimaryKey)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntities_AlternateKey", x => x.AlternateKey)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "GuidV7NonClusteredPkWithLongSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV7NonClusteredPkWithLongSeqClusteredEntities", x => x.PrimaryKey)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_GuidV7NonClusteredPkWithLongSeqClusteredEntities_AlternateKey", x => x.AlternateKey)
                        .Annotation("SqlServer:Clustered", true);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntities");

            migrationBuilder.DropTable(
                name: "GuidV4NonClusteredPkWithLongSeqClusteredEntities");

            migrationBuilder.DropTable(
                name: "GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntities");

            migrationBuilder.DropTable(
                name: "GuidV7NonClusteredPkWithLongSeqClusteredEntities");
        }
    }
}

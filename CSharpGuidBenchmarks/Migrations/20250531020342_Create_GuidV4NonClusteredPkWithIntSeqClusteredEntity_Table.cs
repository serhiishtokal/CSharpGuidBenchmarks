using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpGuidBenchmarks.Migrations
{
    /// <inheritdoc />
    public partial class Create_GuidV4NonClusteredPkWithIntSeqClusteredEntity_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuidV4NonClusteredPkWithIntSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV4NonClusteredPkWithIntSeqClusteredEntities", x => x.PrimaryKey)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_GuidV4NonClusteredPkWithIntSeqClusteredEntities_AlternateKey", x => x.AlternateKey)
                        .Annotation("SqlServer:Clustered", true);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuidV4NonClusteredPkWithIntSeqClusteredEntities");
        }
    }
}

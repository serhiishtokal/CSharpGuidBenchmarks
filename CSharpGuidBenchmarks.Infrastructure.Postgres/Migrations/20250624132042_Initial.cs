using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CSharpGuidBenchmarks.Infrastructure.Postgres.Migrations
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
                    PrimaryKey = table.Column<byte[]>(type: "bytea", maxLength: 16, nullable: false),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV4Bin16ClusteredPkEntities", x => x.PrimaryKey);
                    table.CheckConstraint("CK_GuidV4Bin16ClusteredPkEntities_PrimaryKey_Length", "octet_length(\"PrimaryKey\") = 16");
                });

            migrationBuilder.CreateTable(
                name: "GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<byte[]>(type: "bytea", maxLength: 16, nullable: false),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntities_Altern~", x => x.AlternateKey);
                    table.CheckConstraint("CK_GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntities_Primar~", "octet_length(\"PrimaryKey\") = 16");
                });

            migrationBuilder.CreateTable(
                name: "GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<byte[]>(type: "bytea", maxLength: 16, nullable: false),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntities_Alter~", x => x.AlternateKey);
                    table.CheckConstraint("CK_GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntities_Prima~", "octet_length(\"PrimaryKey\") = 16");
                });

            migrationBuilder.CreateTable(
                name: "GuidV4ClusteredPkEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<Guid>(type: "uuid", nullable: false),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV4ClusteredPkEntities", x => x.PrimaryKey);
                });

            migrationBuilder.CreateTable(
                name: "GuidV4NonClusteredPkWithIntSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<Guid>(type: "uuid", nullable: false),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV4NonClusteredPkWithIntSeqClusteredEntities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_GuidV4NonClusteredPkWithIntSeqClusteredEntities_AlternateKey", x => x.AlternateKey);
                });

            migrationBuilder.CreateTable(
                name: "GuidV4NonClusteredPkWithLongSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<Guid>(type: "uuid", nullable: false),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV4NonClusteredPkWithLongSeqClusteredEntities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_GuidV4NonClusteredPkWithLongSeqClusteredEntities_AlternateK~", x => x.AlternateKey);
                });

            migrationBuilder.CreateTable(
                name: "GuidV7Bin16ClusteredPkEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<byte[]>(type: "bytea", maxLength: 16, nullable: false),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV7Bin16ClusteredPkEntities", x => x.PrimaryKey);
                    table.CheckConstraint("CK_GuidV7Bin16ClusteredPkEntities_PrimaryKey_Length", "octet_length(\"PrimaryKey\") = 16");
                });

            migrationBuilder.CreateTable(
                name: "GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<byte[]>(type: "bytea", maxLength: 16, nullable: false),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntities_Altern~", x => x.AlternateKey);
                    table.CheckConstraint("CK_GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntities_Primar~", "octet_length(\"PrimaryKey\") = 16");
                });

            migrationBuilder.CreateTable(
                name: "GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<byte[]>(type: "bytea", maxLength: 16, nullable: false),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntities_Alter~", x => x.AlternateKey);
                    table.CheckConstraint("CK_GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntities_Prima~", "octet_length(\"PrimaryKey\") = 16");
                });

            migrationBuilder.CreateTable(
                name: "GuidV7ClusteredPkEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<Guid>(type: "uuid", nullable: false),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV7ClusteredPkEntities", x => x.PrimaryKey);
                });

            migrationBuilder.CreateTable(
                name: "GuidV7NonClusteredPkWithIntSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<Guid>(type: "uuid", nullable: false),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV7NonClusteredPkWithIntSeqClusteredEntities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_GuidV7NonClusteredPkWithIntSeqClusteredEntities_AlternateKey", x => x.AlternateKey);
                });

            migrationBuilder.CreateTable(
                name: "GuidV7NonClusteredPkWithLongSeqClusteredEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<Guid>(type: "uuid", nullable: false),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidV7NonClusteredPkWithLongSeqClusteredEntities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_GuidV7NonClusteredPkWithLongSeqClusteredEntities_AlternateK~", x => x.AlternateKey);
                });

            migrationBuilder.CreateTable(
                name: "IntClusteredPkWithAlternateGuidV4Bin16Entities",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AlternateKey = table.Column<byte[]>(type: "bytea", maxLength: 16, nullable: false),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntClusteredPkWithAlternateGuidV4Bin16Entities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_IntClusteredPkWithAlternateGuidV4Bin16Entities_AlternateKey", x => x.AlternateKey);
                    table.CheckConstraint("CK_IntClusteredPkWithAlternateGuidV4Bin16Entities_AlternateKey~", "octet_length(\"AlternateKey\") = 16");
                });

            migrationBuilder.CreateTable(
                name: "IntClusteredPkWithAlternateGuidV4Entities",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<Guid>(type: "uuid", nullable: false)
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
                    PrimaryKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AlternateKey = table.Column<byte[]>(type: "bytea", maxLength: 16, nullable: false),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntClusteredPkWithAlternateGuidV7Bin16Entities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_IntClusteredPkWithAlternateGuidV7Bin16Entities_AlternateKey", x => x.AlternateKey);
                    table.CheckConstraint("CK_IntClusteredPkWithAlternateGuidV7Bin16Entities_AlternateKey~", "octet_length(\"AlternateKey\") = 16");
                });

            migrationBuilder.CreateTable(
                name: "IntClusteredPkWithAlternateGuidV7Entities",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AlternateKey = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntClusteredPkWithAlternateGuidV7Entities", x => x.PrimaryKey);
                    table.UniqueConstraint("AK_IntClusteredPkWithAlternateGuidV7Entities_AlternateKey", x => x.AlternateKey);
                });

            migrationBuilder.CreateTable(
                name: "IntClusteredPrimaryKeyEntities",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Payload = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
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
                name: "GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntities");

            migrationBuilder.DropTable(
                name: "GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntities");

            migrationBuilder.DropTable(
                name: "GuidV4ClusteredPkEntities");

            migrationBuilder.DropTable(
                name: "GuidV4NonClusteredPkWithIntSeqClusteredEntities");

            migrationBuilder.DropTable(
                name: "GuidV4NonClusteredPkWithLongSeqClusteredEntities");

            migrationBuilder.DropTable(
                name: "GuidV7Bin16ClusteredPkEntities");

            migrationBuilder.DropTable(
                name: "GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntities");

            migrationBuilder.DropTable(
                name: "GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntities");

            migrationBuilder.DropTable(
                name: "GuidV7ClusteredPkEntities");

            migrationBuilder.DropTable(
                name: "GuidV7NonClusteredPkWithIntSeqClusteredEntities");

            migrationBuilder.DropTable(
                name: "GuidV7NonClusteredPkWithLongSeqClusteredEntities");

            migrationBuilder.DropTable(
                name: "IntClusteredPkWithAlternateGuidV4Bin16Entities");

            migrationBuilder.DropTable(
                name: "IntClusteredPkWithAlternateGuidV4Entities");

            migrationBuilder.DropTable(
                name: "IntClusteredPkWithAlternateGuidV7Bin16Entities");

            migrationBuilder.DropTable(
                name: "IntClusteredPkWithAlternateGuidV7Entities");

            migrationBuilder.DropTable(
                name: "IntClusteredPrimaryKeyEntities");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Delta.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductsAndManyOtherTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reviews",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "'-infinity'::timestamp with time zone",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Pdf = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Certificates_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Companies_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Consumables_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Url = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    ParentCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ProductCategories_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReagentCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ReagentCategories_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reagents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Reagents_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "Reagents_CompanyId_fkey",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Model = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TechInfo = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    ModelSeries = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: false),
                    CardTitle = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    LongNamePrefix = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    ProductCategoriesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Products_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ProductCategoriesId",
                        column: x => x.ProductCategoriesId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReagentCategoryReagent",
                columns: table => new
                {
                    ReagentCategoryId = table.Column<int>(type: "integer", nullable: false),
                    ReagentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ReagentCategoryReagentsPKey", x => new { x.ReagentCategoryId, x.ReagentId });
                    table.ForeignKey(
                        name: "ReagentCategoryReagents_ReagentCategoryId_fkey",
                        column: x => x.ReagentCategoryId,
                        principalTable: "ReagentCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ReagentCategoryReagents_ReagentId_fkey",
                        column: x => x.ReagentId,
                        principalTable: "Reagents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCertificate",
                columns: table => new
                {
                    CertificateId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ProductCertificatesPKey", x => new { x.CertificateId, x.ProductId });
                    table.ForeignKey(
                        name: "ProductCertificates_CertificateId_fkey",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ProductCertificates_ProductId_fkey",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductConsumable",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ConsumableId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ProductConsumablesPKey", x => new { x.ProductId, x.ConsumableId });
                    table.ForeignKey(
                        name: "ProductConsumables_ConsumableId_fkey",
                        column: x => x.ConsumableId,
                        principalTable: "Consumables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ProductConsumables_ProductId_fkey",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ProductImages_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "ProductImages_ProductId_fkey",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductReagent",
                columns: table => new
                {
                    ReagentId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ProductReagentsPKey", x => new { x.ReagentId, x.ProductId });
                    table.ForeignKey(
                        name: "ProductReagents_ProductId_fkey",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ProductReagents_ReagentId_fkey",
                        column: x => x.ReagentId,
                        principalTable: "Reagents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentCategoryId",
                table: "ProductCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCertificate_ProductId",
                table: "ProductCertificate",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductConsumable_ConsumableId",
                table: "ProductConsumable",
                column: "ConsumableId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReagent_ProductId",
                table: "ProductReagent",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoriesId",
                table: "Products",
                column: "ProductCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ReagentCategoryReagent_ReagentId",
                table: "ReagentCategoryReagent",
                column: "ReagentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reagents_CompanyId",
                table: "Reagents",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCertificate");

            migrationBuilder.DropTable(
                name: "ProductConsumable");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductReagent");

            migrationBuilder.DropTable(
                name: "ReagentCategoryReagent");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Consumables");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ReagentCategories");

            migrationBuilder.DropTable(
                name: "Reagents");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reviews",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "'-infinity'::timestamp with time zone");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JohnyStoreApi.Migrations
{
    /// <inheritdoc />
    public partial class migration_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailabilityStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailabilityStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelsSneakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    WinterOrSummer = table.Column<bool>(type: "bit", nullable: false),
                    StyleId = table.Column<int>(type: "int", nullable: false),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sale = table.Column<bool>(type: "bit", nullable: false),
                    New = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelsSneakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelsSneakers_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModelsSneakers_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Availability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Status35Id = table.Column<int>(type: "int", nullable: false),
                    Status36Id = table.Column<int>(type: "int", nullable: false),
                    Status37Id = table.Column<int>(type: "int", nullable: false),
                    Status38Id = table.Column<int>(type: "int", nullable: false),
                    Status39Id = table.Column<int>(type: "int", nullable: false),
                    Status40Id = table.Column<int>(type: "int", nullable: false),
                    Status41Id = table.Column<int>(type: "int", nullable: false),
                    Status42Id = table.Column<int>(type: "int", nullable: false),
                    Status43Id = table.Column<int>(type: "int", nullable: false),
                    Status44Id = table.Column<int>(type: "int", nullable: false),
                    Status45Id = table.Column<int>(type: "int", nullable: false),
                    Status46Id = table.Column<int>(type: "int", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availability_AvailabilityStatuses_Status35Id",
                        column: x => x.Status35Id,
                        principalTable: "AvailabilityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Availability_AvailabilityStatuses_Status36Id",
                        column: x => x.Status36Id,
                        principalTable: "AvailabilityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Availability_AvailabilityStatuses_Status37Id",
                        column: x => x.Status37Id,
                        principalTable: "AvailabilityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Availability_AvailabilityStatuses_Status38Id",
                        column: x => x.Status38Id,
                        principalTable: "AvailabilityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Availability_AvailabilityStatuses_Status39Id",
                        column: x => x.Status39Id,
                        principalTable: "AvailabilityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Availability_AvailabilityStatuses_Status40Id",
                        column: x => x.Status40Id,
                        principalTable: "AvailabilityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Availability_AvailabilityStatuses_Status41Id",
                        column: x => x.Status41Id,
                        principalTable: "AvailabilityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Availability_AvailabilityStatuses_Status42Id",
                        column: x => x.Status42Id,
                        principalTable: "AvailabilityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Availability_AvailabilityStatuses_Status43Id",
                        column: x => x.Status43Id,
                        principalTable: "AvailabilityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Availability_AvailabilityStatuses_Status44Id",
                        column: x => x.Status44Id,
                        principalTable: "AvailabilityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Availability_AvailabilityStatuses_Status45Id",
                        column: x => x.Status45Id,
                        principalTable: "AvailabilityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Availability_AvailabilityStatuses_Status46Id",
                        column: x => x.Status46Id,
                        principalTable: "AvailabilityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Availability_ModelsSneakers_ModelId",
                        column: x => x.ModelId,
                        principalTable: "ModelsSneakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    SizeFoot = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_ModelsSneakers_ModelId",
                        column: x => x.ModelId,
                        principalTable: "ModelsSneakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PictureSneakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Main = table.Column<bool>(type: "bit", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureSneakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PictureSneakers_ModelsSneakers_ModelId",
                        column: x => x.ModelId,
                        principalTable: "ModelsSneakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availability_ModelId",
                table: "Availability",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_Status35Id",
                table: "Availability",
                column: "Status35Id");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_Status36Id",
                table: "Availability",
                column: "Status36Id");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_Status37Id",
                table: "Availability",
                column: "Status37Id");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_Status38Id",
                table: "Availability",
                column: "Status38Id");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_Status39Id",
                table: "Availability",
                column: "Status39Id");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_Status40Id",
                table: "Availability",
                column: "Status40Id");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_Status41Id",
                table: "Availability",
                column: "Status41Id");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_Status42Id",
                table: "Availability",
                column: "Status42Id");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_Status43Id",
                table: "Availability",
                column: "Status43Id");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_Status44Id",
                table: "Availability",
                column: "Status44Id");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_Status45Id",
                table: "Availability",
                column: "Status45Id");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_Status46Id",
                table: "Availability",
                column: "Status46Id");

            migrationBuilder.CreateIndex(
                name: "IX_ModelsSneakers_BrandId",
                table: "ModelsSneakers",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelsSneakers_StyleId",
                table: "ModelsSneakers",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ModelId",
                table: "Orders",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureSneakers_ModelId",
                table: "PictureSneakers",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availability");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PictureSneakers");

            migrationBuilder.DropTable(
                name: "AvailabilityStatuses");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "ModelsSneakers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Styles");
        }
    }
}

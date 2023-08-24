using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JohnyStoreApi.Migrations
{
    /// <inheritdoc />
    public partial class migration_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status35Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status36Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status37Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status38Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status39Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status40Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status41Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status42Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status43Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status44Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status45Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status46Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_ModelsSneakers_ModelId",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelsSneakers_Brands_BrandId",
                table: "ModelsSneakers");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelsSneakers_Styles_StyleId",
                table: "ModelsSneakers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ModelsSneakers_ModelId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_StatusId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PictureSneakers_ModelsSneakers_ModelId",
                table: "PictureSneakers");

            migrationBuilder.CreateTable(
                name: "PictureBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PictureBrands_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PictureBrands_BrandId",
                table: "PictureBrands",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status35Id",
                table: "Availability",
                column: "Status35Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status36Id",
                table: "Availability",
                column: "Status36Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status37Id",
                table: "Availability",
                column: "Status37Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status38Id",
                table: "Availability",
                column: "Status38Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status39Id",
                table: "Availability",
                column: "Status39Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status40Id",
                table: "Availability",
                column: "Status40Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status41Id",
                table: "Availability",
                column: "Status41Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status42Id",
                table: "Availability",
                column: "Status42Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status43Id",
                table: "Availability",
                column: "Status43Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status44Id",
                table: "Availability",
                column: "Status44Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status45Id",
                table: "Availability",
                column: "Status45Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status46Id",
                table: "Availability",
                column: "Status46Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_ModelsSneakers_ModelId",
                table: "Availability",
                column: "ModelId",
                principalTable: "ModelsSneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelsSneakers_Brands_BrandId",
                table: "ModelsSneakers",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelsSneakers_Styles_StyleId",
                table: "ModelsSneakers",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ModelsSneakers_ModelId",
                table: "Orders",
                column: "ModelId",
                principalTable: "ModelsSneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_StatusId",
                table: "Orders",
                column: "StatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PictureSneakers_ModelsSneakers_ModelId",
                table: "PictureSneakers",
                column: "ModelId",
                principalTable: "ModelsSneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status35Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status36Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status37Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status38Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status39Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status40Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status41Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status42Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status43Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status44Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status45Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status46Id",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_ModelsSneakers_ModelId",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelsSneakers_Brands_BrandId",
                table: "ModelsSneakers");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelsSneakers_Styles_StyleId",
                table: "ModelsSneakers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ModelsSneakers_ModelId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_StatusId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PictureSneakers_ModelsSneakers_ModelId",
                table: "PictureSneakers");

            migrationBuilder.DropTable(
                name: "PictureBrands");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status35Id",
                table: "Availability",
                column: "Status35Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status36Id",
                table: "Availability",
                column: "Status36Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status37Id",
                table: "Availability",
                column: "Status37Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status38Id",
                table: "Availability",
                column: "Status38Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status39Id",
                table: "Availability",
                column: "Status39Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status40Id",
                table: "Availability",
                column: "Status40Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status41Id",
                table: "Availability",
                column: "Status41Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status42Id",
                table: "Availability",
                column: "Status42Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status43Id",
                table: "Availability",
                column: "Status43Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status44Id",
                table: "Availability",
                column: "Status44Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status45Id",
                table: "Availability",
                column: "Status45Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_Status46Id",
                table: "Availability",
                column: "Status46Id",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_ModelsSneakers_ModelId",
                table: "Availability",
                column: "ModelId",
                principalTable: "ModelsSneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelsSneakers_Brands_BrandId",
                table: "ModelsSneakers",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelsSneakers_Styles_StyleId",
                table: "ModelsSneakers",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ModelsSneakers_ModelId",
                table: "Orders",
                column: "ModelId",
                principalTable: "ModelsSneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_StatusId",
                table: "Orders",
                column: "StatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PictureSneakers_ModelsSneakers_ModelId",
                table: "PictureSneakers",
                column: "ModelId",
                principalTable: "ModelsSneakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

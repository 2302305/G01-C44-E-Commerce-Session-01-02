using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Presistence.Context.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductConfigNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productBrands_ProductBrandId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productsType_ProductTypeId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "products",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "ProductBrandId",
                table: "products",
                newName: "BrandId");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "products",
                newName: "PictureUrl");

            migrationBuilder.RenameIndex(
                name: "IX_products_ProductTypeId",
                table: "products",
                newName: "IX_products_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_products_ProductBrandId",
                table: "products",
                newName: "IX_products_BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productBrands_BrandId",
                table: "products",
                column: "BrandId",
                principalTable: "productBrands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productsType_TypeId",
                table: "products",
                column: "TypeId",
                principalTable: "productsType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productBrands_BrandId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productsType_TypeId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "products",
                newName: "ProductTypeId");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "products",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "products",
                newName: "ProductBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_products_TypeId",
                table: "products",
                newName: "IX_products_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_products_BrandId",
                table: "products",
                newName: "IX_products_ProductBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productBrands_ProductBrandId",
                table: "products",
                column: "ProductBrandId",
                principalTable: "productBrands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productsType_ProductTypeId",
                table: "products",
                column: "ProductTypeId",
                principalTable: "productsType",
                principalColumn: "Id");
        }
    }
}

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
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productsType_ProductTypeId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "Products",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "ProductBrandId",
                table: "Products",
                newName: "BrandId");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Products",
                newName: "PictureUrl");

            migrationBuilder.RenameIndex(
                name: "IX_products_ProductTypeId",
                table: "Products",
                newName: "IX_products_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_products_ProductBrandId",
                table: "Products",
                newName: "IX_products_BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productBrands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "ProductBrands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productsType_TypeId",
                table: "Products",
                column: "TypeId",
                principalTable: "ProductsType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productBrands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productsType_TypeId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Products",
                newName: "ProductTypeId");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "Products",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Products",
                newName: "ProductBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_products_TypeId",
                table: "Products",
                newName: "IX_products_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_products_BrandId",
                table: "Products",
                newName: "IX_products_ProductBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productBrands_ProductBrandId",
                table: "Products",
                column: "ProductBrandId",
                principalTable: "ProductBrands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productsType_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductsType",
                principalColumn: "Id");
        }
    }
}

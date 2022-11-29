using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom09.Migrations
{
    /// <inheritdoc />
    public partial class EditDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Invoices_invoiceId",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Products_productId",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Invoice_id",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Product_id",
                table: "InvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "InvoiceDetails",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "invoiceId",
                table: "InvoiceDetails",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetails_productId",
                table: "InvoiceDetails",
                newName: "IX_InvoiceDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetails_invoiceId",
                table: "InvoiceDetails",
                newName: "IX_InvoiceDetails_InvoiceId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Invoices_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Products_ProductId",
                table: "InvoiceDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Invoices_InvoiceId",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Products_ProductId",
                table: "InvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "InvoiceDetails",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "InvoiceDetails",
                newName: "invoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetails_ProductId",
                table: "InvoiceDetails",
                newName: "IX_InvoiceDetails_productId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                newName: "IX_InvoiceDetails_invoiceId");

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "InvoiceDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "InvoiceDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "invoiceId",
                table: "InvoiceDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Invoice_id",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Product_id",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Invoices_invoiceId",
                table: "InvoiceDetails",
                column: "invoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Products_productId",
                table: "InvoiceDetails",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}

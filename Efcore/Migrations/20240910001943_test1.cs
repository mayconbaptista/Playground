using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Efcore.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    customer_id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    zip_code = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    state = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.customer_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    product_id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    category_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    weight_g = table.Column<uint>(type: "int unsigned", nullable: false),
                    length_cm = table.Column<uint>(type: "int unsigned", nullable: false),
                    width_cm = table.Column<uint>(type: "int unsigned", nullable: false),
                    height_cm = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.product_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ORDER",
                columns: table => new
                {
                    order_id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<uint>(type: "int unsigned", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    purchase_timestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    approved_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    delivered_timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    estimated_delivery = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerEntityId = table.Column<uint>(type: "int unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_ORDER_CUSTOMER_CustomerEntityId",
                        column: x => x.CustomerEntityId,
                        principalTable: "CUSTOMER",
                        principalColumn: "customer_id");
                    table.ForeignKey(
                        name: "fk_order_customer",
                        column: x => x.CustomerId,
                        principalTable: "ORDER",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ORDER_ITEM",
                columns: table => new
                {
                    order_item_id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    order_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    product_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    seller_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    shipping_charges = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_ITEM", x => x.order_item_id);
                    table.ForeignKey(
                        name: "fk_order_item_order",
                        column: x => x.order_id,
                        principalTable: "ORDER",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_order_item_product",
                        column: x => x.product_id,
                        principalTable: "PRODUCT",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PAYMENT",
                columns: table => new
                {
                    payment_id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    order_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    PaymentFamilyId = table.Column<uint>(type: "int unsigned", nullable: false),
                    type = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    installments = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    value = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENT", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_PAYMENT_ORDER_order_id",
                        column: x => x.order_id,
                        principalTable: "ORDER",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_CustomerEntityId",
                table: "ORDER",
                column: "CustomerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_CustomerId",
                table: "ORDER",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ITEM_order_id",
                table: "ORDER_ITEM",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ITEM_product_id",
                table: "ORDER_ITEM",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_order_id",
                table: "PAYMENT",
                column: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDER_ITEM");

            migrationBuilder.DropTable(
                name: "PAYMENT");

            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "ORDER");

            migrationBuilder.DropTable(
                name: "CUSTOMER");
        }
    }
}

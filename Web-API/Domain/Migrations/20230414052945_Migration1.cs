using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    customer_password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    customer_first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    customer_last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    customer_address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "manufacturers",
                columns: table => new
                {
                    manufacturer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    manufacturer_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturers", x => x.manufacturer_id);
                });

            migrationBuilder.CreateTable(
                name: "warehouses",
                columns: table => new
                {
                    stock_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stock_address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__warehous__E8666862EDFB854D", x => x.stock_id);
                });

            migrationBuilder.CreateTable(
                name: "filters",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false),
                    filter_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filter_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FILTERS", x => new { x.category_id, x.filter_id });
                    table.ForeignKey(
                        name: "FK__filters__categor__4D5F7D71",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id");
                });

            migrationBuilder.CreateTable(
                name: "purchases",
                columns: table => new
                {
                    purchase_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    purchase_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchases", x => x.purchase_id);
                    table.ForeignKey(
                        name: "FK__purchases__custo__3F115E1A",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id");
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    stock_id = table.Column<int>(type: "int", nullable: false),
                    manufacturer_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    product_count = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    product_price = table.Column<decimal>(type: "decimal(9,2)", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK__products__catego__31B762FC",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id");
                    table.ForeignKey(
                        name: "FK__products__manufa__32AB8735",
                        column: x => x.manufacturer_id,
                        principalTable: "manufacturers",
                        principalColumn: "manufacturer_id");
                    table.ForeignKey(
                        name: "FK__products__stock___30C33EC3",
                        column: x => x.stock_id,
                        principalTable: "warehouses",
                        principalColumn: "stock_id");
                });

            migrationBuilder.CreateTable(
                name: "status_of_purchase",
                columns: table => new
                {
                    purchase_id = table.Column<int>(type: "int", nullable: false),
                    purchase_status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "('in process')")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__status_of__purch__4A8310C6",
                        column: x => x.purchase_id,
                        principalTable: "purchases",
                        principalColumn: "purchase_id");
                });

            migrationBuilder.CreateTable(
                name: "deliveries",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    stock_id = table.Column<int>(type: "int", nullable: false),
                    delivery_date = table.Column<DateTime>(type: "date", nullable: false),
                    product_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__deliverie__produ__3864608B",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK__deliverie__stock__395884C4",
                        column: x => x.stock_id,
                        principalTable: "warehouses",
                        principalColumn: "stock_id");
                });

            migrationBuilder.CreateTable(
                name: "price_change",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    date_price_change = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(CONVERT([date],getdate()))"),
                    new_price = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRICE_CHANGE", x => new { x.product_id, x.date_price_change });
                    table.ForeignKey(
                        name: "FK__price_cha__produ__367C1819",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "purchase_items",
                columns: table => new
                {
                    purchase_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    product_count = table.Column<int>(type: "int", nullable: false),
                    product_price = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PURCHASE_ITEMS", x => new { x.purchase_id, x.product_id });
                    table.ForeignKey(
                        name: "FK__purchase___produ__41EDCAC5",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK__purchase___purch__42E1EEFE",
                        column: x => x.purchase_id,
                        principalTable: "purchases",
                        principalColumn: "purchase_id");
                });

            migrationBuilder.CreateTable(
                name: "shopping_cart",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    product_count = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    product_price = table.Column<decimal>(type: "decimal(9,2)", nullable: true, defaultValueSql: "((0.00))")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__shopping___custo__46B27FE2",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id");
                    table.ForeignKey(
                        name: "FK__shopping___produ__47A6A41B",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_deliveries_product_id",
                table: "deliveries",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_deliveries_stock_id",
                table: "deliveries",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_manufacturer_id",
                table: "products",
                column: "manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_stock_id",
                table: "products",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_items_product_id",
                table: "purchase_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_customer_id",
                table: "purchases",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_shopping_cart_customer_id",
                table: "shopping_cart",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_shopping_cart_product_id",
                table: "shopping_cart",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_status_of_purchase_purchase_id",
                table: "status_of_purchase",
                column: "purchase_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deliveries");

            migrationBuilder.DropTable(
                name: "filters");

            migrationBuilder.DropTable(
                name: "price_change");

            migrationBuilder.DropTable(
                name: "purchase_items");

            migrationBuilder.DropTable(
                name: "shopping_cart");

            migrationBuilder.DropTable(
                name: "status_of_purchase");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "purchases");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "manufacturers");

            migrationBuilder.DropTable(
                name: "warehouses");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}

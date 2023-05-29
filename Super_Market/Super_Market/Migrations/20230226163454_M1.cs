using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Super_Market.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Pos = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorys_Stors_StorId",
                        column: x => x.StorId,
                        principalTable: "Stors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuppliersId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recipts_suppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sellinvoces",
                columns: table => new
                {
                    BonNumberr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    PaidMoney = table.Column<double>(type: "float", nullable: false),
                    RemainingMoney = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sellinvoces", x => x.BonNumberr);
                    table.ForeignKey(
                        name: "FK_sellinvoces_users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "proudcts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellingPrice = table.Column<double>(type: "float", nullable: false),
                    PurchasingPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategorysId = table.Column<int>(type: "int", nullable: false),
                    Suppliersid = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ReciptId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proudcts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proudcts_Categorys_CategorysId",
                        column: x => x.CategorysId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_proudcts_recipts_ReciptId",
                        column: x => x.ReciptId,
                        principalTable: "recipts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_proudcts_suppliers_Suppliersid",
                        column: x => x.Suppliersid,
                        principalTable: "suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quanatity = table.Column<int>(type: "int", nullable: false),
                    ProudectId = table.Column<int>(type: "int", nullable: false),
                    SellinvoceId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_proudcts_ProudectId",
                        column: x => x.ProudectId,
                        principalTable: "proudcts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_sellinvoces_SellinvoceId",
                        column: x => x.SellinvoceId,
                        principalTable: "sellinvoces",
                        principalColumn: "BonNumberr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stors",
                columns: new[] { "Id", "IsDelete", "Location", "Name" },
                values: new object[,]
                {
                    { 1, false, "Assiut", "store1" },
                    { 2, false, "Alex", "Store2" }
                });

            migrationBuilder.InsertData(
                table: "suppliers",
                columns: new[] { "Id", "IsDelete", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, false, "johinaa", "01028574231" },
                    { 2, false, "almraie", "01055688224" },
                    { 3, false, "atyab", "0104567432" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "IsDelete", "Password", "Pos", "Salary", "UserName" },
                values: new object[,]
                {
                    { 10, false, "12345", 0, 2000.0, "Ahmed" },
                    { 20, false, "2555", 0, 1000.0, "Mahmoud" },
                    { 30, false, "11111", 1, 3000.0, "Kero" }
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "IsDelete", "Name", "StorId" },
                values: new object[,]
                {
                    { 1, false, "Dairy", 1 },
                    { 2, false, "protien", 2 }
                });

            migrationBuilder.InsertData(
                table: "proudcts",
                columns: new[] { "Id", "CategorysId", "ExpirationDate", "IsDelete", "Name", "ProductionDate", "PurchasingPrice", "Quantity", "ReciptId", "SellingPrice", "Suppliersid" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Milk", new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.0, 20, null, 15.0, 1 },
                    { 2, 1, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Cheese", new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0, 17, null, 30.0, 1 },
                    { 3, 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Yogut", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0, 200, null, 5.0, 1 },
                    { 4, 2, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Meet", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 130.0, 25, null, 150.0, 2 },
                    { 5, 2, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Chicken", new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0, 48, null, 80.0, 2 },
                    { 6, 2, new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "fish", new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.0, 36, null, 90.0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorys_StorId",
                table: "Categorys",
                column: "StorId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_ProudectId",
                table: "orders",
                column: "ProudectId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_SellinvoceId",
                table: "orders",
                column: "SellinvoceId");

            migrationBuilder.CreateIndex(
                name: "IX_proudcts_CategorysId",
                table: "proudcts",
                column: "CategorysId");

            migrationBuilder.CreateIndex(
                name: "IX_proudcts_ReciptId",
                table: "proudcts",
                column: "ReciptId");

            migrationBuilder.CreateIndex(
                name: "IX_proudcts_Suppliersid",
                table: "proudcts",
                column: "Suppliersid");

            migrationBuilder.CreateIndex(
                name: "IX_recipts_SuppliersId",
                table: "recipts",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_sellinvoces_UsersId",
                table: "sellinvoces",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "proudcts");

            migrationBuilder.DropTable(
                name: "sellinvoces");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "recipts");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Stors");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}

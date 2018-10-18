using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace forex4u.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockUsers",
                columns: table => new
                {
                    StockUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockUsers", x => x.StockUserId);
                });

            migrationBuilder.CreateTable(
                name: "SymbolGroup",
                columns: table => new
                {
                    SymbolGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymbolGroup", x => x.SymbolGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(nullable: true),
                    StockUserId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_StockUsers_StockUserId",
                        column: x => x.StockUserId,
                        principalTable: "StockUsers",
                        principalColumn: "StockUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Credit",
                columns: table => new
                {
                    CreditId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreditType = table.Column<int>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    StockUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.CreditId);
                    table.ForeignKey(
                        name: "FK_Credit_StockUsers_StockUserId",
                        column: x => x.StockUserId,
                        principalTable: "StockUsers",
                        principalColumn: "StockUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Symbol",
                columns: table => new
                {
                    SymbolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SymAbbrName = table.Column<string>(nullable: true),
                    SymFullName = table.Column<string>(nullable: true),
                    SymbolGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbol", x => x.SymbolId);
                    table.ForeignKey(
                        name: "FK_Symbol_SymbolGroup_SymbolGroupId",
                        column: x => x.SymbolGroupId,
                        principalTable: "SymbolGroup",
                        principalColumn: "SymbolGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Forcast",
                columns: table => new
                {
                    ForcastId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    EntryPoint = table.Column<decimal>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    StopPoint = table.Column<decimal>(nullable: false),
                    SymbolId = table.Column<int>(nullable: false),
                    TargetPoint = table.Column<decimal>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    VolPercent = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forcast", x => x.ForcastId);
                    table.ForeignKey(
                        name: "FK_Forcast_Symbol_SymbolId",
                        column: x => x.SymbolId,
                        principalTable: "Symbol",
                        principalColumn: "SymbolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSymbol",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    SymbolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSymbol", x => new { x.UserId, x.SymbolId });
                    table.ForeignKey(
                        name: "FK_UserSymbol_Symbol_SymbolId",
                        column: x => x.SymbolId,
                        principalTable: "Symbol",
                        principalColumn: "SymbolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSymbol_StockUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "StockUsers",
                        principalColumn: "StockUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_StockUserId",
                table: "Accounts",
                column: "StockUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Credit_StockUserId",
                table: "Credit",
                column: "StockUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Forcast_SymbolId",
                table: "Forcast",
                column: "SymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_Symbol_SymbolGroupId",
                table: "Symbol",
                column: "SymbolGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSymbol_SymbolId",
                table: "UserSymbol",
                column: "SymbolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "Forcast");

            migrationBuilder.DropTable(
                name: "UserSymbol");

            migrationBuilder.DropTable(
                name: "Symbol");

            migrationBuilder.DropTable(
                name: "StockUsers");

            migrationBuilder.DropTable(
                name: "SymbolGroup");
        }
    }
}

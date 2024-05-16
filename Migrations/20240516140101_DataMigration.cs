using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class DataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillTransactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<int>(type: "int", nullable: false),
                    day = table.Column<int>(type: "int", nullable: false),
                    transactionId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    userToken = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    doctorToken = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    customerToken = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    partnerToken = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    successClassificationAPICount = table.Column<int>(type: "int", nullable: false),
                    failureClassificationAPICount = table.Column<int>(type: "int", nullable: false),
                    successBPMAPICount = table.Column<int>(type: "int", nullable: false),
                    failureBPMAPICount = table.Column<int>(type: "int", nullable: false),
                    failureRecognitionAPICount = table.Column<int>(type: "int", nullable: false),
                    billingTimestamp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillTransactions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    partnerToken = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    subscriptionPlanId = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    contractStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contractEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    downpayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    downpaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contractStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyBillings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<int>(type: "int", nullable: false),
                    partnerToken = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    subscriptionPlanId = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    thereafter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    successCount = table.Column<int>(type: "int", nullable: false),
                    failureCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBillings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlans",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subscriptionPlanId = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    tierName = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    billingPricingPerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    maxTransactionsPerMonth = table.Column<int>(type: "int", nullable: false),
                    thereafterAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlans", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_partnerToken",
                table: "Contracts",
                column: "partnerToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyBillings_year_month_partnerToken",
                table: "MonthlyBillings",
                columns: new[] { "year", "month", "partnerToken" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillTransactions");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "MonthlyBillings");

            migrationBuilder.DropTable(
                name: "SubscriptionPlans");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poke.CloudSalesSystem.Licences.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUuidOsspExtension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";");

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    providerId = table.Column<Guid>(type: "uuid", nullable: true),
                    createdOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    externalSubscriptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    accountId = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceId = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceName = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    createdOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_subscriptions", x => x.id);
                    table.ForeignKey(
                        name: "fK_subscriptions_services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "licences",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    externalLicenceId = table.Column<Guid>(type: "uuid", nullable: false),
                    externalSubscriptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    accountId = table.Column<Guid>(type: "uuid", nullable: true),
                    licenceKey = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    validTo = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    subscriptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    createdOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_licences", x => x.id);
                    table.ForeignKey(
                        name: "fK_licences_subscriptionEntity_subscriptionId",
                        column: x => x.subscriptionId,
                        principalTable: "subscriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "iX_licences_subscriptionId",
                table: "licences",
                column: "subscriptionId");

            migrationBuilder.CreateIndex(
                name: "iX_subscriptions_serviceId",
                table: "subscriptions",
                column: "serviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "licences");

            migrationBuilder.DropTable(
                name: "subscriptions");

            migrationBuilder.DropTable(
                name: "services");


            migrationBuilder.Sql("DROP EXTENSION IF EXISTS \"uuid-ossp\";");
        }
    }
}

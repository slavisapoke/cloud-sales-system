using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Poke.CloudSalesSystem.Accounts.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitializeAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customerId = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    createdOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_accounts", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "createdOn", "customerId", "email", "modifiedOn", "name", "phone" },
                values: new object[,]
                {
                    { new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("43c8a677-2345-4ba2-993e-46668d76ab6e"), null, null, "account_uno@zika.com", "123456" },
                    { new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("43c8a677-2345-4ba2-993e-46668d76ab6e"), null, null, "account_due@zika.com", "223332" },
                    { new Guid("63db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("43c8a677-2345-4ba2-993e-46668d76ab6e"), null, null, "account_tre@zika.com", "234254" },
                    { new Guid("64db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("43c8a677-2345-4ba2-993e-46668d76ab6e"), null, null, "account_quattro@zika.com", "6455645645" },
                    { new Guid("65db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("43c8a677-2345-4ba2-993e-46668d76ab6e"), null, null, "account_cinque@zika.com", "2342333" },
                    { new Guid("66db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("86ddb9e8-3c41-4774-aace-4289afb73eeb"), null, null, "account_sei@zika.com", "2233545332" },
                    { new Guid("67db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("86ddb9e8-3c41-4774-aace-4289afb73eeb"), null, null, "account_sette@zika.com", "23423434" },
                    { new Guid("68db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("86ddb9e8-3c41-4774-aace-4289afb73eeb"), null, null, "account_otto@zika.com", "4566655" },
                    { new Guid("69db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("86ddb9e8-3c41-4774-aace-4289afb73eeb"), null, null, "account_nove@zika.com", "2342342" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");
        }
    }
}

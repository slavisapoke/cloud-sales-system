using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Poke.CloudSalesSystem.Licences.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Outbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inboxState",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    messageId = table.Column<Guid>(type: "uuid", nullable: false),
                    consumerId = table.Column<Guid>(type: "uuid", nullable: false),
                    lockId = table.Column<Guid>(type: "uuid", nullable: false),
                    rowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    received = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    receiveCount = table.Column<int>(type: "integer", nullable: false),
                    expirationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    consumed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    delivered = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastSequenceNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_inboxState", x => x.id);
                    table.UniqueConstraint("aK_inboxState_messageId_consumerId", x => new { x.messageId, x.consumerId });
                });

            migrationBuilder.CreateTable(
                name: "outboxState",
                columns: table => new
                {
                    outboxId = table.Column<Guid>(type: "uuid", nullable: false),
                    lockId = table.Column<Guid>(type: "uuid", nullable: false),
                    rowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    delivered = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastSequenceNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_outboxState", x => x.outboxId);
                });

            migrationBuilder.CreateTable(
                name: "outboxMessage",
                columns: table => new
                {
                    sequenceNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enqueueTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    sentTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    headers = table.Column<string>(type: "text", nullable: true),
                    properties = table.Column<string>(type: "text", nullable: true),
                    inboxMessageId = table.Column<Guid>(type: "uuid", nullable: true),
                    inboxConsumerId = table.Column<Guid>(type: "uuid", nullable: true),
                    outboxId = table.Column<Guid>(type: "uuid", nullable: true),
                    messageId = table.Column<Guid>(type: "uuid", nullable: false),
                    contentType = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    messageType = table.Column<string>(type: "text", nullable: false),
                    body = table.Column<string>(type: "text", nullable: false),
                    conversationId = table.Column<Guid>(type: "uuid", nullable: true),
                    correlationId = table.Column<Guid>(type: "uuid", nullable: true),
                    initiatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    requestId = table.Column<Guid>(type: "uuid", nullable: true),
                    sourceAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    destinationAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    responseAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    faultAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    expirationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_outboxMessage", x => x.sequenceNumber);
                    table.ForeignKey(
                        name: "fK_outboxMessage_inboxState_inboxMessageId_inboxConsumerId",
                        columns: x => new { x.inboxMessageId, x.inboxConsumerId },
                        principalTable: "inboxState",
                        principalColumns: new[] { "messageId", "consumerId" });
                    table.ForeignKey(
                        name: "fK_outboxMessage_outboxState_outboxId",
                        column: x => x.outboxId,
                        principalTable: "outboxState",
                        principalColumn: "outboxId");
                });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("230950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "A4BD8-2H44W-71RZ2-3ZWTE", new DateTimeOffset(new DateTime(2025, 12, 6, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("240950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "W8IXS-G5SIS-C8Q7X-P02I5", new DateTimeOffset(new DateTime(2025, 11, 12, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("250950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "DOUOM-NQCKZ-UVWZT-R5B6M", new DateTimeOffset(new DateTime(2025, 8, 28, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3233), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("260950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "0XHY7-L3R9X-C1SJH-9JHB1", new DateTimeOffset(new DateTime(2025, 9, 9, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3337), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("270950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "174UN-CP9GP-GL7S4-XPG5R", new DateTimeOffset(new DateTime(2025, 7, 28, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3354), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("280950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "YCUW6-2WUPP-0SCYT-JHSK0", new DateTimeOffset(new DateTime(2025, 10, 15, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3372), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("290950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "MSX3E-J5QMS-RIFV5-N7RZJ", new DateTimeOffset(new DateTime(2025, 8, 25, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3386), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2a0950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "N3CGH-QISD1-C4T2A-24J0O", new DateTimeOffset(new DateTime(2025, 11, 24, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3399), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2b0950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "HO2TG-HEDC7-XAQWC-OZYY2", new DateTimeOffset(new DateTime(2026, 2, 5, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3418), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2c0950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "SI2DY-V9L13-6ALCL-I8U60", new DateTimeOffset(new DateTime(2025, 11, 23, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3435), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2d0950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "72RJ4-EW7PR-RWDUH-6RDB0", new DateTimeOffset(new DateTime(2025, 7, 28, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3448), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2e0950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "WQGAX-YKWDL-60AIH-HNSAR", new DateTimeOffset(new DateTime(2025, 6, 25, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3522), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2f0950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "52BOR-24MIO-LXTNL-DABJW", new DateTimeOffset(new DateTime(2025, 10, 29, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3537), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "iX_inboxState_delivered",
                table: "inboxState",
                column: "delivered");

            migrationBuilder.CreateIndex(
                name: "iX_outboxMessage_enqueueTime",
                table: "outboxMessage",
                column: "enqueueTime");

            migrationBuilder.CreateIndex(
                name: "iX_outboxMessage_expirationTime",
                table: "outboxMessage",
                column: "expirationTime");

            migrationBuilder.CreateIndex(
                name: "iX_outboxMessage_inboxMessageId_inboxConsumerId_sequenceNumber",
                table: "outboxMessage",
                columns: new[] { "inboxMessageId", "inboxConsumerId", "sequenceNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "iX_outboxMessage_outboxId_sequenceNumber",
                table: "outboxMessage",
                columns: new[] { "outboxId", "sequenceNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "iX_outboxState_created",
                table: "outboxState",
                column: "created");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "outboxMessage");

            migrationBuilder.DropTable(
                name: "inboxState");

            migrationBuilder.DropTable(
                name: "outboxState");

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("230950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "VP043-ZGVRR-PQDWP-LRT2B", new DateTimeOffset(new DateTime(2025, 12, 28, 21, 16, 11, 452, DateTimeKind.Unspecified).AddTicks(2563), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("240950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "MBBR0-DIBY8-ZVCJX-XWUJR", new DateTimeOffset(new DateTime(2025, 12, 18, 21, 16, 11, 452, DateTimeKind.Unspecified).AddTicks(2611), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("250950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "9UOKC-OHM51-9ICVM-Q2CWQ", new DateTimeOffset(new DateTime(2025, 9, 20, 21, 16, 11, 452, DateTimeKind.Unspecified).AddTicks(2622), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("260950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "MBC7W-C39F8-DB8I3-SL91K", new DateTimeOffset(new DateTime(2025, 5, 19, 21, 16, 11, 452, DateTimeKind.Unspecified).AddTicks(2640), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("270950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "W81JA-MMW96-JOGII-MZBGI", new DateTimeOffset(new DateTime(2025, 10, 26, 21, 16, 11, 452, DateTimeKind.Unspecified).AddTicks(2683), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("280950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "9LL1F-VN59G-RPZ1V-21VI6", new DateTimeOffset(new DateTime(2025, 11, 4, 21, 16, 11, 452, DateTimeKind.Unspecified).AddTicks(2696), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("290950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "03M0E-8SO77-AGZYE-XZB3B", new DateTimeOffset(new DateTime(2025, 12, 24, 21, 16, 11, 452, DateTimeKind.Unspecified).AddTicks(2707), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2a0950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "MSYEF-PFFXM-CMUM6-BOOD1", new DateTimeOffset(new DateTime(2025, 11, 5, 21, 16, 11, 452, DateTimeKind.Unspecified).AddTicks(2717), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2b0950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "UV1JU-J26T0-BM28T-2IY7Z", new DateTimeOffset(new DateTime(2025, 7, 11, 21, 16, 11, 452, DateTimeKind.Unspecified).AddTicks(2732), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2c0950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "YS9P5-PP165-HZCLI-6ASH3", new DateTimeOffset(new DateTime(2026, 1, 5, 21, 16, 11, 452, DateTimeKind.Unspecified).AddTicks(2744), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2d0950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "S9XYK-OW8UO-FRCTP-H2VQL", new DateTimeOffset(new DateTime(2026, 1, 21, 21, 16, 11, 452, DateTimeKind.Unspecified).AddTicks(2754), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2e0950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "F0OKW-3W67J-KVV31-43CZZ", new DateTimeOffset(new DateTime(2026, 1, 5, 21, 16, 11, 452, DateTimeKind.Unspecified).AddTicks(2784), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2f0950e0-fb93-406d-bf9d-61aee5de4506"),
                columns: new[] { "licenceKey", "validTo" },
                values: new object[] { "5A663-IY8X0-GP8ND-103D6", new DateTimeOffset(new DateTime(2025, 6, 11, 21, 16, 11, 452, DateTimeKind.Unspecified).AddTicks(2794), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}

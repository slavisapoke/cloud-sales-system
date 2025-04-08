using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Poke.CloudSalesSystem.Licences.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitializeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "services",
                columns: new[] { "id", "createdOn", "description", "modifiedOn", "name", "providerId" },
                values: new object[,]
                {
                    { new Guid("d284eb26-9d42-4c16-89cb-ce75e0ab5afa"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Service 1 description...", null, "Service 1", new Guid("d484eb26-9d42-4c16-89cb-ce75e0ab5afa") },
                    { new Guid("d384eb26-9d42-4c16-89cb-ce75e0ab5afa"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Service 2 description...", null, "Service 2", new Guid("d484eb26-9d42-4c16-89cb-ce75e0ab5afa") }
                });

            migrationBuilder.InsertData(
                table: "subscriptions",
                columns: new[] { "id", "accountId", "createdOn", "externalSubscriptionId", "modifiedOn", "quantity", "serviceId", "serviceName", "status" },
                values: new object[,]
                {
                    { new Guid("2284eda3-29ec-4bf1-b077-225a2bcbfdc1"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b337547d-4f1c-4b17-b464-8e4e28899a8b"), null, 5, new Guid("d284eb26-9d42-4c16-89cb-ce75e0ab5afa"), "Service 1 name...", 1 },
                    { new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"), null, 10, new Guid("d284eb26-9d42-4c16-89cb-ce75e0ab5afa"), "Service 1 name...", 1 },
                    { new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), null, 15, new Guid("d284eb26-9d42-4c16-89cb-ce75e0ab5afa"), "Service 1 name...", 1 }
                });

            migrationBuilder.InsertData(
                table: "licences",
                columns: new[] { "id", "accountId", "createdOn", "externalLicenceId", "externalSubscriptionId", "licenceKey", "modifiedOn", "status", "subscriptionId", "validTo" },
                values: new object[,]
                {
                    { new Guid("230950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a511a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b337547d-4f1c-4b17-b464-8e4e28899a8b"), "VDKI2-QIA3U-H3SFG-89NTT", null, 1, new Guid("2284eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 9, 6, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(403), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("240950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a611a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b337547d-4f1c-4b17-b464-8e4e28899a8b"), "KT5RN-GV831-Z1BQN-BD0HY", null, 1, new Guid("2284eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 11, 3, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(443), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("250950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a711a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b337547d-4f1c-4b17-b464-8e4e28899a8b"), "KQ3I9-V564Y-0UT75-JLB4I", null, 1, new Guid("2284eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 8, 19, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(454), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("260950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a811a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b337547d-4f1c-4b17-b464-8e4e28899a8b"), "2YYVB-9U82C-U22Q4-HUKFD", null, 1, new Guid("2284eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 10, 29, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(464), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("270950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a911a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b337547d-4f1c-4b17-b464-8e4e28899a8b"), "LSAN4-LGTIG-D58R8-ML4QA", null, 1, new Guid("2284eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 12, 22, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(473), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("280950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("aa11a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"), "6XT8I-OY6TG-W4TY9-CZIFY", null, 1, new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 7, 25, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(489), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("290950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ab11a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"), "LWWC2-74Q76-3BD6I-P0RB0", null, 1, new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 11, 2, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(546), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2a0950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ac11a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"), "EDKKN-IFNKX-E2ED9-HFK0X", null, 1, new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 12, 12, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(557), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2b0950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ad11a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"), "JJLPP-M1KV1-OS0C8-O1KGI", null, 1, new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 7, 27, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(566), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2c0950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ae11a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"), "DSXKM-MHO5K-22K52-B81OE", null, 1, new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 7, 6, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(577), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2d0950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("af11a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"), "YGQPN-EEVHY-I7R4G-O966H", null, 1, new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 6, 6, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(586), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2e0950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b011a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"), "IN18K-0K5SR-9LLVI-E80LK", null, 1, new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 5, 18, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(594), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2f0950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b111a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"), "T21MH-0OA5D-48T89-LS26W", null, 1, new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 5, 27, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(603), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("300950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b211a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"), "0UJ95-M3MBS-0B1YX-UZ8KV", null, 1, new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2026, 1, 16, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(644), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("310950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("61db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b311a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"), "M68NE-KIRBL-Y7RJG-MH7DS", null, 1, new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 6, 23, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(654), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("320950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b411a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "VGBZ7-OR19Q-MM3JK-4OFAL", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 8, 13, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(667), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("330950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b511a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "VML18-7J3LE-I5R6W-H17C1", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 12, 25, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(679), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("340950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b611a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "F42FM-LTS98-XG041-MPGID", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 12, 17, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(690), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("350950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b711a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "8RE3W-7DDYD-8BIIK-8PKNL", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 10, 24, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(699), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("360950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b811a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "UAQS7-ORM5P-AIJRY-U2JC7", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 5, 29, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(707), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("370950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b911a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "JRD3I-4N8II-O5WC7-PMPL7", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 8, 9, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(716), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("380950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ba11a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "F2CTN-8T3LX-JEN90-Y92Z7", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 6, 27, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(751), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("390950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("bb11a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "O2VRQ-95A5K-8DYX6-XJLVA", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 7, 12, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(762), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3a0950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("bc11a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "51HBG-BLYG4-Q4XZD-UV6ZO", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 5, 27, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(771), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3b0950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("bd11a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "VOW7M-P2Q61-MWH5Z-01IWU", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 12, 20, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(780), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3c0950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("be11a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "2M3A0-TSXDL-AU84V-8M9X7", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 6, 22, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(789), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3d0950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("bf11a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "BBGP6-OI9ZJ-5TJZ3-EFZSO", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 8, 18, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(797), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3e0950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c011a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "JVJLR-IFCDS-P32LO-ID5R3", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 12, 16, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(806), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3f0950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c111a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "2LTVF-PC0US-PHOYS-UBF7W", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 6, 22, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(838), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("400950e0-fb93-406d-bf9d-61aee5de4506"), new Guid("62db564e-5ef0-4614-9127-562a8b2856db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c211a5be-f12d-4ce5-999e-9f6623de4d54"), new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"), "WKLUE-NB52B-BSW4B-7G61R", null, 1, new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"), new DateTimeOffset(new DateTime(2025, 7, 10, 23, 54, 6, 797, DateTimeKind.Unspecified).AddTicks(848), new TimeSpan(0, 0, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("230950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("240950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("250950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("260950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("270950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("280950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("290950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2a0950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2b0950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2c0950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2d0950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2e0950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("2f0950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("300950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("310950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("320950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("330950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("340950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("350950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("360950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("370950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("380950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("390950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("3a0950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("3b0950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("3c0950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("3d0950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("3e0950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("3f0950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "licences",
                keyColumn: "id",
                keyValue: new Guid("400950e0-fb93-406d-bf9d-61aee5de4506"));

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "id",
                keyValue: new Guid("d384eb26-9d42-4c16-89cb-ce75e0ab5afa"));

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "id",
                keyValue: new Guid("2284eda3-29ec-4bf1-b077-225a2bcbfdc1"));

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "id",
                keyValue: new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"));

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "id",
                keyValue: new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"));

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "id",
                keyValue: new Guid("d284eb26-9d42-4c16-89cb-ce75e0ab5afa"));
        }
    }
}

﻿// <auto-generated />
using System;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Poke.CloudSalesSystem.Licences.Infrastructure.Migrations
{
    [DbContext(typeof(LicencesDbContext))]
    [Migration("20250412012544_Outbox")]
    partial class Outbox
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.InboxState", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("Consumed")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("consumed");

                    b.Property<Guid>("ConsumerId")
                        .HasColumnType("uuid")
                        .HasColumnName("consumerId");

                    b.Property<DateTime?>("Delivered")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delivered");

                    b.Property<DateTime?>("ExpirationTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expirationTime");

                    b.Property<long?>("LastSequenceNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("lastSequenceNumber");

                    b.Property<Guid>("LockId")
                        .HasColumnType("uuid")
                        .HasColumnName("lockId");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid")
                        .HasColumnName("messageId");

                    b.Property<int>("ReceiveCount")
                        .HasColumnType("integer")
                        .HasColumnName("receiveCount");

                    b.Property<DateTime>("Received")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("received");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("rowVersion");

                    b.HasKey("Id")
                        .HasName("pK_inboxState");

                    b.HasAlternateKey("MessageId", "ConsumerId")
                        .HasName("aK_inboxState_messageId_consumerId");

                    b.HasIndex("Delivered")
                        .HasDatabaseName("iX_inboxState_delivered");

                    b.ToTable("inboxState", (string)null);
                });

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.OutboxMessage", b =>
                {
                    b.Property<long>("SequenceNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("sequenceNumber");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("SequenceNumber"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("body");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("contentType");

                    b.Property<Guid?>("ConversationId")
                        .HasColumnType("uuid")
                        .HasColumnName("conversationId");

                    b.Property<Guid?>("CorrelationId")
                        .HasColumnType("uuid")
                        .HasColumnName("correlationId");

                    b.Property<string>("DestinationAddress")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("destinationAddress");

                    b.Property<DateTime?>("EnqueueTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("enqueueTime");

                    b.Property<DateTime?>("ExpirationTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expirationTime");

                    b.Property<string>("FaultAddress")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("faultAddress");

                    b.Property<string>("Headers")
                        .HasColumnType("text")
                        .HasColumnName("headers");

                    b.Property<Guid?>("InboxConsumerId")
                        .HasColumnType("uuid")
                        .HasColumnName("inboxConsumerId");

                    b.Property<Guid?>("InboxMessageId")
                        .HasColumnType("uuid")
                        .HasColumnName("inboxMessageId");

                    b.Property<Guid?>("InitiatorId")
                        .HasColumnType("uuid")
                        .HasColumnName("initiatorId");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid")
                        .HasColumnName("messageId");

                    b.Property<string>("MessageType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("messageType");

                    b.Property<Guid?>("OutboxId")
                        .HasColumnType("uuid")
                        .HasColumnName("outboxId");

                    b.Property<string>("Properties")
                        .HasColumnType("text")
                        .HasColumnName("properties");

                    b.Property<Guid?>("RequestId")
                        .HasColumnType("uuid")
                        .HasColumnName("requestId");

                    b.Property<string>("ResponseAddress")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("responseAddress");

                    b.Property<DateTime>("SentTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("sentTime");

                    b.Property<string>("SourceAddress")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("sourceAddress");

                    b.HasKey("SequenceNumber")
                        .HasName("pK_outboxMessage");

                    b.HasIndex("EnqueueTime")
                        .HasDatabaseName("iX_outboxMessage_enqueueTime");

                    b.HasIndex("ExpirationTime")
                        .HasDatabaseName("iX_outboxMessage_expirationTime");

                    b.HasIndex("OutboxId", "SequenceNumber")
                        .IsUnique()
                        .HasDatabaseName("iX_outboxMessage_outboxId_sequenceNumber");

                    b.HasIndex("InboxMessageId", "InboxConsumerId", "SequenceNumber")
                        .IsUnique()
                        .HasDatabaseName("iX_outboxMessage_inboxMessageId_inboxConsumerId_sequenceNumber");

                    b.ToTable("outboxMessage", (string)null);
                });

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.OutboxState", b =>
                {
                    b.Property<Guid>("OutboxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("outboxId");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<DateTime?>("Delivered")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delivered");

                    b.Property<long?>("LastSequenceNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("lastSequenceNumber");

                    b.Property<Guid>("LockId")
                        .HasColumnType("uuid")
                        .HasColumnName("lockId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("rowVersion");

                    b.HasKey("OutboxId")
                        .HasName("pK_outboxState");

                    b.HasIndex("Created")
                        .HasDatabaseName("iX_outboxState_created");

                    b.ToTable("outboxState", (string)null);
                });

            modelBuilder.Entity("Poke.CloudSalesSystem.Licences.Domain.Model.LicenceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("accountId");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdOn");

                    b.Property<Guid>("ExternalLicenceId")
                        .HasColumnType("uuid")
                        .HasColumnName("externalLicenceId");

                    b.Property<Guid>("ExternalSubscriptionId")
                        .HasColumnType("uuid")
                        .HasColumnName("externalSubscriptionId");

                    b.Property<string>("LicenceKey")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("licenceKey");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modifiedOn");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uuid")
                        .HasColumnName("subscriptionId");

                    b.Property<DateTimeOffset?>("ValidTo")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("validTo");

                    b.HasKey("Id")
                        .HasName("pK_licences");

                    b.HasIndex("SubscriptionId")
                        .HasDatabaseName("iX_licences_subscriptionId");

                    b.ToTable("licences", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("230950e0-fb93-406d-bf9d-61aee5de4506"),
                            AccountId = new Guid("61db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalLicenceId = new Guid("a511a5be-f12d-4ce5-999e-9f6623de4d54"),
                            ExternalSubscriptionId = new Guid("b337547d-4f1c-4b17-b464-8e4e28899a8b"),
                            LicenceKey = "A4BD8-2H44W-71RZ2-3ZWTE",
                            Status = 1,
                            SubscriptionId = new Guid("2284eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            ValidTo = new DateTimeOffset(new DateTime(2025, 12, 6, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("240950e0-fb93-406d-bf9d-61aee5de4506"),
                            AccountId = new Guid("61db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalLicenceId = new Guid("a611a5be-f12d-4ce5-999e-9f6623de4d54"),
                            ExternalSubscriptionId = new Guid("b337547d-4f1c-4b17-b464-8e4e28899a8b"),
                            LicenceKey = "W8IXS-G5SIS-C8Q7X-P02I5",
                            Status = 1,
                            SubscriptionId = new Guid("2284eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            ValidTo = new DateTimeOffset(new DateTime(2025, 11, 12, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3218), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("250950e0-fb93-406d-bf9d-61aee5de4506"),
                            AccountId = new Guid("61db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalLicenceId = new Guid("a711a5be-f12d-4ce5-999e-9f6623de4d54"),
                            ExternalSubscriptionId = new Guid("b337547d-4f1c-4b17-b464-8e4e28899a8b"),
                            LicenceKey = "DOUOM-NQCKZ-UVWZT-R5B6M",
                            Status = 1,
                            SubscriptionId = new Guid("2284eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            ValidTo = new DateTimeOffset(new DateTime(2025, 8, 28, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3233), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("260950e0-fb93-406d-bf9d-61aee5de4506"),
                            AccountId = new Guid("61db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalLicenceId = new Guid("a811a5be-f12d-4ce5-999e-9f6623de4d54"),
                            ExternalSubscriptionId = new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"),
                            LicenceKey = "0XHY7-L3R9X-C1SJH-9JHB1",
                            Status = 1,
                            SubscriptionId = new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            ValidTo = new DateTimeOffset(new DateTime(2025, 9, 9, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3337), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("270950e0-fb93-406d-bf9d-61aee5de4506"),
                            AccountId = new Guid("61db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalLicenceId = new Guid("a911a5be-f12d-4ce5-999e-9f6623de4d54"),
                            ExternalSubscriptionId = new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"),
                            LicenceKey = "174UN-CP9GP-GL7S4-XPG5R",
                            Status = 1,
                            SubscriptionId = new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            ValidTo = new DateTimeOffset(new DateTime(2025, 7, 28, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3354), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("280950e0-fb93-406d-bf9d-61aee5de4506"),
                            AccountId = new Guid("61db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalLicenceId = new Guid("aa11a5be-f12d-4ce5-999e-9f6623de4d54"),
                            ExternalSubscriptionId = new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"),
                            LicenceKey = "YCUW6-2WUPP-0SCYT-JHSK0",
                            Status = 1,
                            SubscriptionId = new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            ValidTo = new DateTimeOffset(new DateTime(2025, 10, 15, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3372), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("290950e0-fb93-406d-bf9d-61aee5de4506"),
                            AccountId = new Guid("61db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalLicenceId = new Guid("ab11a5be-f12d-4ce5-999e-9f6623de4d54"),
                            ExternalSubscriptionId = new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"),
                            LicenceKey = "MSX3E-J5QMS-RIFV5-N7RZJ",
                            Status = 1,
                            SubscriptionId = new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            ValidTo = new DateTimeOffset(new DateTime(2025, 8, 25, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3386), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("2a0950e0-fb93-406d-bf9d-61aee5de4506"),
                            AccountId = new Guid("61db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalLicenceId = new Guid("ac11a5be-f12d-4ce5-999e-9f6623de4d54"),
                            ExternalSubscriptionId = new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"),
                            LicenceKey = "N3CGH-QISD1-C4T2A-24J0O",
                            Status = 1,
                            SubscriptionId = new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            ValidTo = new DateTimeOffset(new DateTime(2025, 11, 24, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3399), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("2b0950e0-fb93-406d-bf9d-61aee5de4506"),
                            AccountId = new Guid("62db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalLicenceId = new Guid("ad11a5be-f12d-4ce5-999e-9f6623de4d54"),
                            ExternalSubscriptionId = new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"),
                            LicenceKey = "HO2TG-HEDC7-XAQWC-OZYY2",
                            Status = 1,
                            SubscriptionId = new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            ValidTo = new DateTimeOffset(new DateTime(2026, 2, 5, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3418), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("2c0950e0-fb93-406d-bf9d-61aee5de4506"),
                            AccountId = new Guid("62db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalLicenceId = new Guid("ae11a5be-f12d-4ce5-999e-9f6623de4d54"),
                            ExternalSubscriptionId = new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"),
                            LicenceKey = "SI2DY-V9L13-6ALCL-I8U60",
                            Status = 1,
                            SubscriptionId = new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            ValidTo = new DateTimeOffset(new DateTime(2025, 11, 23, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3435), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("2d0950e0-fb93-406d-bf9d-61aee5de4506"),
                            AccountId = new Guid("62db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalLicenceId = new Guid("af11a5be-f12d-4ce5-999e-9f6623de4d54"),
                            ExternalSubscriptionId = new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"),
                            LicenceKey = "72RJ4-EW7PR-RWDUH-6RDB0",
                            Status = 1,
                            SubscriptionId = new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            ValidTo = new DateTimeOffset(new DateTime(2025, 7, 28, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3448), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("2e0950e0-fb93-406d-bf9d-61aee5de4506"),
                            AccountId = new Guid("62db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalLicenceId = new Guid("b011a5be-f12d-4ce5-999e-9f6623de4d54"),
                            ExternalSubscriptionId = new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"),
                            LicenceKey = "WQGAX-YKWDL-60AIH-HNSAR",
                            Status = 1,
                            SubscriptionId = new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            ValidTo = new DateTimeOffset(new DateTime(2025, 6, 25, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3522), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("2f0950e0-fb93-406d-bf9d-61aee5de4506"),
                            AccountId = new Guid("62db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalLicenceId = new Guid("b111a5be-f12d-4ce5-999e-9f6623de4d54"),
                            ExternalSubscriptionId = new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"),
                            LicenceKey = "52BOR-24MIO-LXTNL-DABJW",
                            Status = 1,
                            SubscriptionId = new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            ValidTo = new DateTimeOffset(new DateTime(2025, 10, 29, 1, 25, 43, 993, DateTimeKind.Unspecified).AddTicks(3537), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("Poke.CloudSalesSystem.Licences.Domain.Model.ServiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdOn");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modifiedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<Guid?>("ProviderId")
                        .HasColumnType("uuid")
                        .HasColumnName("providerId");

                    b.HasKey("Id")
                        .HasName("pK_services");

                    b.ToTable("services", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d284eb26-9d42-4c16-89cb-ce75e0ab5afa"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Service 1 description...",
                            Name = "Service 1",
                            ProviderId = new Guid("d484eb26-9d42-4c16-89cb-ce75e0ab5afa")
                        },
                        new
                        {
                            Id = new Guid("d384eb26-9d42-4c16-89cb-ce75e0ab5afa"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Service 2 description...",
                            Name = "Service 2",
                            ProviderId = new Guid("d484eb26-9d42-4c16-89cb-ce75e0ab5afa")
                        });
                });

            modelBuilder.Entity("Poke.CloudSalesSystem.Licences.Domain.Model.SubscriptionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("accountId");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdOn");

                    b.Property<Guid>("ExternalSubscriptionId")
                        .HasColumnType("uuid")
                        .HasColumnName("externalSubscriptionId");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modifiedOn");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid")
                        .HasColumnName("serviceId");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("serviceName");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pK_subscriptions");

                    b.HasIndex("ServiceId")
                        .HasDatabaseName("iX_subscriptions_serviceId");

                    b.ToTable("subscriptions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2284eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            AccountId = new Guid("61db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalSubscriptionId = new Guid("b337547d-4f1c-4b17-b464-8e4e28899a8b"),
                            Quantity = 5,
                            ServiceId = new Guid("d284eb26-9d42-4c16-89cb-ce75e0ab5afa"),
                            ServiceName = "Service 1 name...",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("2384eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            AccountId = new Guid("61db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalSubscriptionId = new Guid("b437547d-4f1c-4b17-b464-8e4e28899a8b"),
                            Quantity = 10,
                            ServiceId = new Guid("d384eb26-9d42-4c16-89cb-ce75e0ab5afa"),
                            ServiceName = "Service 2 name...",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("2484eda3-29ec-4bf1-b077-225a2bcbfdc1"),
                            AccountId = new Guid("62db564e-5ef0-4614-9127-562a8b2856db"),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalSubscriptionId = new Guid("b537547d-4f1c-4b17-b464-8e4e28899a8b"),
                            Quantity = 15,
                            ServiceId = new Guid("d384eb26-9d42-4c16-89cb-ce75e0ab5afa"),
                            ServiceName = "Service 2 name...",
                            Status = 1
                        });
                });

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.OutboxMessage", b =>
                {
                    b.HasOne("MassTransit.EntityFrameworkCoreIntegration.OutboxState", null)
                        .WithMany()
                        .HasForeignKey("OutboxId")
                        .HasConstraintName("fK_outboxMessage_outboxState_outboxId");

                    b.HasOne("MassTransit.EntityFrameworkCoreIntegration.InboxState", null)
                        .WithMany()
                        .HasForeignKey("InboxMessageId", "InboxConsumerId")
                        .HasPrincipalKey("MessageId", "ConsumerId")
                        .HasConstraintName("fK_outboxMessage_inboxState_inboxMessageId_inboxConsumerId");
                });

            modelBuilder.Entity("Poke.CloudSalesSystem.Licences.Domain.Model.LicenceEntity", b =>
                {
                    b.HasOne("Poke.CloudSalesSystem.Licences.Domain.Model.SubscriptionEntity", "Subscription")
                        .WithMany("Licences")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fK_licences_subscriptions_subscriptionId");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("Poke.CloudSalesSystem.Licences.Domain.Model.SubscriptionEntity", b =>
                {
                    b.HasOne("Poke.CloudSalesSystem.Licences.Domain.Model.ServiceEntity", "Service")
                        .WithMany("Subscriptions")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fK_subscriptions_services_serviceId");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Poke.CloudSalesSystem.Licences.Domain.Model.ServiceEntity", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("Poke.CloudSalesSystem.Licences.Domain.Model.SubscriptionEntity", b =>
                {
                    b.Navigation("Licences");
                });
#pragma warning restore 612, 618
        }
    }
}

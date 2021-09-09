﻿// <auto-generated />
using System;
using Cryptofolio.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Cryptofolio.Infrastructure.Migrations
{
    [DbContext(typeof(CryptofolioContext))]
    partial class CryptofolioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("data")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.Asset", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("name");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("symbol");

                    b.HasKey("Id");

                    b.HasIndex("Symbol");

                    b.ToTable("asset");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.AssetTicker", b =>
                {
                    b.Property<string>("asset_id")
                        .HasColumnType("character varying(100)");

                    b.Property<string>("vs_currency_id")
                        .HasColumnType("character varying(36)");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestamp");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric")
                        .HasColumnName("value");

                    b.HasKey("asset_id", "vs_currency_id", "Timestamp");

                    b.HasIndex("Timestamp");

                    b.HasIndex("vs_currency_id");

                    b.ToTable("asset_ticker");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.Currency", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<int>("Precision")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(2)
                        .HasColumnName("precision");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("symbol");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("currency");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.CurrencyTicker", b =>
                {
                    b.Property<string>("currency_id")
                        .HasColumnType("character varying(36)");

                    b.Property<string>("vs_currency_id")
                        .HasColumnType("character varying(36)");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestamp");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric")
                        .HasColumnName("value");

                    b.HasKey("currency_id", "vs_currency_id", "Timestamp");

                    b.HasIndex("Timestamp");

                    b.HasIndex("vs_currency_id");

                    b.ToTable("currency_ticker");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.Exchange", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("name");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)")
                        .HasColumnName("url");

                    b.Property<long?>("YearEstablished")
                        .HasColumnType("bigint")
                        .HasColumnName("year_established");

                    b.HasKey("Id");

                    b.ToTable("exchange");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.Holding", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("id");

                    b.Property<decimal>("Change")
                        .HasColumnType("numeric")
                        .HasColumnName("change");

                    b.Property<decimal>("CurrentValue")
                        .HasColumnType("numeric")
                        .HasColumnName("current_value");

                    b.Property<decimal>("InitialValue")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Qty")
                        .HasColumnType("numeric")
                        .HasColumnName("qty");

                    b.Property<string>("asset_id")
                        .IsRequired()
                        .HasColumnType("character varying(100)");

                    b.Property<string>("wallet_id")
                        .IsRequired()
                        .HasColumnType("character varying(36)");

                    b.HasKey("Id");

                    b.HasIndex("asset_id");

                    b.HasIndex("wallet_id", "asset_id")
                        .IsUnique();

                    b.ToTable("holding");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.Setting", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("key");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("group");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Key");

                    b.HasIndex("Group");

                    b.ToTable("setting");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("id");

                    b.Property<decimal>("Change")
                        .HasColumnType("numeric")
                        .HasColumnName("change");

                    b.Property<decimal>("CurrentValue")
                        .HasColumnType("numeric")
                        .HasColumnName("current_value");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<decimal>("InitialValue")
                        .HasColumnType("numeric")
                        .HasColumnName("initial_value");

                    b.Property<string>("Note")
                        .HasColumnType("text")
                        .HasColumnName("note");

                    b.Property<decimal>("Qty")
                        .HasColumnType("numeric")
                        .HasColumnName("qty");

                    b.Property<string>("asset_id")
                        .IsRequired()
                        .HasColumnType("character varying(100)");

                    b.Property<string>("discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("exchange_id")
                        .HasColumnType("character varying(100)");

                    b.Property<string>("wallet_id")
                        .IsRequired()
                        .HasColumnType("character varying(36)");

                    b.HasKey("Id");

                    b.HasIndex("Date")
                        .HasSortOrder(new[] { SortOrder.Descending });

                    b.HasIndex("asset_id");

                    b.HasIndex("exchange_id");

                    b.HasIndex("wallet_id");

                    b.ToTable("transaction");

                    b.HasDiscriminator<string>("discriminator").HasValue("Transaction");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.Wallet", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("id");

                    b.Property<decimal>("Change")
                        .HasColumnType("numeric")
                        .HasColumnName("change");

                    b.Property<decimal>("CurrentValue")
                        .HasColumnType("numeric")
                        .HasColumnName("current_value");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<decimal>("InitialValue")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("name");

                    b.Property<bool>("Selected")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("selected");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("user_id");

                    b.Property<string>("currency_id")
                        .IsRequired()
                        .HasColumnType("character varying(36)");

                    b.HasKey("Id");

                    b.HasIndex("currency_id");

                    b.ToTable("wallet");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.BuyOrSellTransaction", b =>
                {
                    b.HasBaseType("Cryptofolio.Infrastructure.Entities.Transaction");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("type");

                    b.Property<string>("currency_id")
                        .IsRequired()
                        .HasColumnType("character varying(36)");

                    b.HasIndex("Type");

                    b.HasIndex("currency_id");

                    b.HasDiscriminator().HasValue("BuyOrSellTransaction");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.TransferTransaction", b =>
                {
                    b.HasBaseType("Cryptofolio.Infrastructure.Entities.Transaction");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("destination");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("source");

                    b.HasIndex("Destination");

                    b.HasIndex("Source");

                    b.HasDiscriminator().HasValue("TransferTransaction");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.AssetTicker", b =>
                {
                    b.HasOne("Cryptofolio.Infrastructure.Entities.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("asset_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cryptofolio.Infrastructure.Entities.Currency", "VsCurrency")
                        .WithMany()
                        .HasForeignKey("vs_currency_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("VsCurrency");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.CurrencyTicker", b =>
                {
                    b.HasOne("Cryptofolio.Infrastructure.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("currency_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cryptofolio.Infrastructure.Entities.Currency", "VsCurrency")
                        .WithMany()
                        .HasForeignKey("vs_currency_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("VsCurrency");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.Holding", b =>
                {
                    b.HasOne("Cryptofolio.Infrastructure.Entities.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("asset_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cryptofolio.Infrastructure.Entities.Wallet", "Wallet")
                        .WithMany("Holdings")
                        .HasForeignKey("wallet_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.Transaction", b =>
                {
                    b.HasOne("Cryptofolio.Infrastructure.Entities.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("asset_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cryptofolio.Infrastructure.Entities.Exchange", "Exchange")
                        .WithMany()
                        .HasForeignKey("exchange_id");

                    b.HasOne("Cryptofolio.Infrastructure.Entities.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("wallet_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("Exchange");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.Wallet", b =>
                {
                    b.HasOne("Cryptofolio.Infrastructure.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("currency_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.BuyOrSellTransaction", b =>
                {
                    b.HasOne("Cryptofolio.Infrastructure.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("currency_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Cryptofolio.Infrastructure.Entities.Wallet", b =>
                {
                    b.Navigation("Holdings");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using MagicRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicRepositories.Migrations
{
    [DbContext(typeof(PortalContext))]
    [Migration("20231231145750_Logs")]
    partial class Logs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MtGDomain.Entities.CardType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CardType");
                });

            modelBuilder.Entity("MtGDomain.Entities.CardTypeMagicCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CardTypeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MagicCardId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CardTypeId");

                    b.HasIndex("MagicCardId");

                    b.ToTable("CardTypeMagicCards");
                });

            modelBuilder.Entity("MtGDomain.Entities.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedUTC")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicAbility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MagicAbility");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicAbilityMagicCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MagicAbilityId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MagicCardId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("MagicAbilityId");

                    b.HasIndex("MagicCardId");

                    b.ToTable("MagicAbilityMagicCards");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CardId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Cmc")
                        .HasColumnType("int");

                    b.Property<string>("CollectingNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsColorLess")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsMultiColor")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("MagicSetId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ManaCost")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MultiverseId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MagicSetId");

                    b.ToTable("MagicCards");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicCardMagicLegality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MagicCardId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MagicLegalityId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("MagicCardId");

                    b.HasIndex("MagicLegalityId");

                    b.ToTable("MagicCardMagicLegalities");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicCardSuperCardType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MagicCardId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SuperCardTypeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("MagicCardId");

                    b.HasIndex("SuperCardTypeId");

                    b.ToTable("MagicCardSuperCardTypes");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicLegality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LegalityName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MagicLegality");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicRuling", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("MagicCardId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MagicCardId");

                    b.ToTable("MagicRuling");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("SetCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SetName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MagicSets");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicSetMagicCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MagicCardId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MagicSetId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("MagicCardId");

                    b.HasIndex("MagicSetId");

                    b.ToTable("MagicSetMagicCards");
                });

            modelBuilder.Entity("MtGDomain.Entities.SuperCardType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SuperCardTypes");
                });

            modelBuilder.Entity("MtGDomain.Entities.CardTypeMagicCard", b =>
                {
                    b.HasOne("MtGDomain.Entities.CardType", "CardType")
                        .WithMany("MagicCards")
                        .HasForeignKey("CardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MtGDomain.Entities.MagicCard", "MagicCard")
                        .WithMany("CardTypes")
                        .HasForeignKey("MagicCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardType");

                    b.Navigation("MagicCard");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicAbilityMagicCard", b =>
                {
                    b.HasOne("MtGDomain.Entities.MagicAbility", "MagicAbility")
                        .WithMany("MagicCards")
                        .HasForeignKey("MagicAbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MtGDomain.Entities.MagicCard", null)
                        .WithMany("Abilities")
                        .HasForeignKey("MagicCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MagicAbility");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicCard", b =>
                {
                    b.HasOne("MtGDomain.Entities.MagicSet", "MagicSet")
                        .WithMany("MagicCards")
                        .HasForeignKey("MagicSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MagicSet");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicCardMagicLegality", b =>
                {
                    b.HasOne("MtGDomain.Entities.MagicCard", "MagicCard")
                        .WithMany("MagicLegalities")
                        .HasForeignKey("MagicCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MtGDomain.Entities.MagicLegality", "MagicLegality")
                        .WithMany("MagicCards")
                        .HasForeignKey("MagicLegalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MagicCard");

                    b.Navigation("MagicLegality");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicCardSuperCardType", b =>
                {
                    b.HasOne("MtGDomain.Entities.MagicCard", "MagicCard")
                        .WithMany("SuperCardTypes")
                        .HasForeignKey("MagicCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MtGDomain.Entities.SuperCardType", "SuperCardType")
                        .WithMany("MagicCards")
                        .HasForeignKey("SuperCardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MagicCard");

                    b.Navigation("SuperCardType");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicRuling", b =>
                {
                    b.HasOne("MtGDomain.Entities.MagicCard", "MagicCard")
                        .WithMany("Rulings")
                        .HasForeignKey("MagicCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MagicCard");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicSetMagicCard", b =>
                {
                    b.HasOne("MtGDomain.Entities.MagicCard", "MagicCard")
                        .WithMany()
                        .HasForeignKey("MagicCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MtGDomain.Entities.MagicSet", "MagicSet")
                        .WithMany()
                        .HasForeignKey("MagicSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MagicCard");

                    b.Navigation("MagicSet");
                });

            modelBuilder.Entity("MtGDomain.Entities.CardType", b =>
                {
                    b.Navigation("MagicCards");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicAbility", b =>
                {
                    b.Navigation("MagicCards");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicCard", b =>
                {
                    b.Navigation("Abilities");

                    b.Navigation("CardTypes");

                    b.Navigation("MagicLegalities");

                    b.Navigation("Rulings");

                    b.Navigation("SuperCardTypes");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicLegality", b =>
                {
                    b.Navigation("MagicCards");
                });

            modelBuilder.Entity("MtGDomain.Entities.MagicSet", b =>
                {
                    b.Navigation("MagicCards");
                });

            modelBuilder.Entity("MtGDomain.Entities.SuperCardType", b =>
                {
                    b.Navigation("MagicCards");
                });
#pragma warning restore 612, 618
        }
    }
}

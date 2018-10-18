﻿// <auto-generated />
using forex4u.Infrastructure;
using FX.Core.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace forex4u.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("forex4u.Models.StockUser", b =>
                {
                    b.Property<int>("StockUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MobileNumber");

                    b.Property<int>("State");

                    b.HasKey("StockUserId");

                    b.ToTable("StockUsers");
                });

            modelBuilder.Entity("FX.Core.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<int>("StockUserId");

                    b.Property<string>("Username");

                    b.HasKey("AccountId");

                    b.HasIndex("StockUserId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("FX.Core.Entities.Credit", b =>
                {
                    b.Property<int>("CreditId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreditType");

                    b.Property<DateTime>("ExpireDate");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("StartDate");

                    b.Property<int?>("StockUserId");

                    b.HasKey("CreditId");

                    b.HasIndex("StockUserId");

                    b.ToTable("Credit");
                });

            modelBuilder.Entity("FX.Core.Entities.Forcast", b =>
                {
                    b.Property<int>("ForcastId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("EntryPoint");

                    b.Property<int>("Period");

                    b.Property<decimal>("StopPoint");

                    b.Property<int>("SymbolId");

                    b.Property<decimal>("TargetPoint");

                    b.Property<int>("Type");

                    b.Property<float>("VolPercent");

                    b.HasKey("ForcastId");

                    b.HasIndex("SymbolId");

                    b.ToTable("Forcast");
                });

            modelBuilder.Entity("FX.Core.Entities.Symbol", b =>
                {
                    b.Property<int>("SymbolId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SymAbbrName");

                    b.Property<string>("SymFullName");

                    b.Property<int?>("SymbolGroupId");

                    b.HasKey("SymbolId");

                    b.HasIndex("SymbolGroupId");

                    b.ToTable("Symbol");
                });

            modelBuilder.Entity("FX.Core.Entities.SymbolGroup", b =>
                {
                    b.Property<int>("SymbolGroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupName");

                    b.HasKey("SymbolGroupId");

                    b.ToTable("SymbolGroup");
                });

            modelBuilder.Entity("FX.Core.Entities.UserSymbol", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("SymbolId");

                    b.HasKey("UserId", "SymbolId");

                    b.HasIndex("SymbolId");

                    b.ToTable("UserSymbol");
                });

            modelBuilder.Entity("FX.Core.Entities.Account", b =>
                {
                    b.HasOne("forex4u.Models.StockUser", "StockUser")
                        .WithOne("Account")
                        .HasForeignKey("FX.Core.Entities.Account", "StockUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FX.Core.Entities.Credit", b =>
                {
                    b.HasOne("forex4u.Models.StockUser", "StockUser")
                        .WithMany("Credits")
                        .HasForeignKey("StockUserId");
                });

            modelBuilder.Entity("FX.Core.Entities.Forcast", b =>
                {
                    b.HasOne("FX.Core.Entities.Symbol", "Symbol")
                        .WithMany("Forcasts")
                        .HasForeignKey("SymbolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FX.Core.Entities.Symbol", b =>
                {
                    b.HasOne("FX.Core.Entities.SymbolGroup", "SymbolGroup")
                        .WithMany("Symbols")
                        .HasForeignKey("SymbolGroupId");
                });

            modelBuilder.Entity("FX.Core.Entities.UserSymbol", b =>
                {
                    b.HasOne("FX.Core.Entities.Symbol", "Symbol")
                        .WithMany("UserSymbols")
                        .HasForeignKey("SymbolId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("forex4u.Models.StockUser", "StockUser")
                        .WithMany("UserSymbols")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

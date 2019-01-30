﻿// <auto-generated />
using System;
using BankingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankingApp.Migrations
{
    [DbContext(typeof(BankingAppContext))]
    [Migration("20190125230049_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankingApp.Models.Account", b =>
                {
                    b.Property<int>("AccountID");

                    b.Property<int>("AccountType");

                    b.Property<double>("Balance");

                    b.Property<DateTime>("InitialTransactionDate");

                    b.HasKey("AccountID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BankingApp.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("Phone");

                    b.Property<DateTime>("startDate");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BankingApp.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionID");

                    b.Property<int?>("AccountID");

                    b.Property<float>("EndBalance");

                    b.Property<float>("StartBalance");

                    b.Property<float>("TransactionAmount");

                    b.Property<DateTime>("TransactionTime");

                    b.HasKey("TransactionID");

                    b.HasIndex("AccountID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BankingApp.Models.Account", b =>
                {
                    b.HasOne("BankingApp.Models.Customer", "Customer")
                        .WithOne("Account")
                        .HasForeignKey("BankingApp.Models.Account", "AccountID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BankingApp.Models.Transaction", b =>
                {
                    b.HasOne("BankingApp.Models.Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountID");
                });
#pragma warning restore 612, 618
        }
    }
}
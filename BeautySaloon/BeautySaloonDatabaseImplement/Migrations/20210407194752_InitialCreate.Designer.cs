﻿// <auto-generated />
using System;
using BeautySaloonDatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeautySaloonDatabaseImplement.Migrations
{
    [DbContext(typeof(BeautySaloonDatabase))]
    [Migration("20210407194752_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientSurame")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.Cosmetic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CosmeticName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Cosmetics");
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.Distribution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VisitId");

                    b.ToTable("Distributions");
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.DistributionCosmetic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CosmeticId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("DistributionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CosmeticId");

                    b.HasIndex("DistributionId");

                    b.ToTable("DistributionCosmetics");
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("F_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("L_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.Procedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProcedureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.ProcedurePurchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcedureId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("ProcedurePurchases");
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.ProcedureVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcedureId");

                    b.HasIndex("VisitId");

                    b.ToTable("ProcedureVisits");
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ReceiptId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ReceiptId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.ReceiptCosmetic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CosmeticId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("ReceiptId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CosmeticId");

                    b.HasIndex("ReceiptId");

                    b.ToTable("ReceiptCosmetics");
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.Cosmetic", b =>
                {
                    b.HasOne("BeautySaloonDatabaseImplement.Models.Employee", "Employee")
                        .WithMany("Cosmetic")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.Distribution", b =>
                {
                    b.HasOne("BeautySaloonDatabaseImplement.Models.Employee", "Employee")
                        .WithMany("Distribution")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautySaloonDatabaseImplement.Models.Visit", "Visit")
                        .WithMany("Distributions")
                        .HasForeignKey("VisitId");
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.DistributionCosmetic", b =>
                {
                    b.HasOne("BeautySaloonDatabaseImplement.Models.Cosmetic", "Cosmetic")
                        .WithMany("DistributionCosmetics")
                        .HasForeignKey("CosmeticId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautySaloonDatabaseImplement.Models.Distribution", "Distribution")
                        .WithMany("DistributionCosmetics")
                        .HasForeignKey("DistributionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.Procedure", b =>
                {
                    b.HasOne("BeautySaloonDatabaseImplement.Models.Client", "Client")
                        .WithMany("Procedure")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.ProcedurePurchase", b =>
                {
                    b.HasOne("BeautySaloonDatabaseImplement.Models.Procedure", "Procedure")
                        .WithMany("ProcedurePurchase")
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautySaloonDatabaseImplement.Models.Purchase", "Purchase")
                        .WithMany("ProcedurePurchase")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.ProcedureVisit", b =>
                {
                    b.HasOne("BeautySaloonDatabaseImplement.Models.Procedure", "Procedure")
                        .WithMany("ProcedureVisit")
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautySaloonDatabaseImplement.Models.Visit", "Visit")
                        .WithMany("ProcedureVisit")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.Purchase", b =>
                {
                    b.HasOne("BeautySaloonDatabaseImplement.Models.Client", "Client")
                        .WithMany("Purchase")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautySaloonDatabaseImplement.Models.Receipt", "Receipt")
                        .WithMany("Purchases")
                        .HasForeignKey("ReceiptId");
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.Receipt", b =>
                {
                    b.HasOne("BeautySaloonDatabaseImplement.Models.Employee", "Employee")
                        .WithMany("Receipt")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.ReceiptCosmetic", b =>
                {
                    b.HasOne("BeautySaloonDatabaseImplement.Models.Cosmetic", "Cosmetic")
                        .WithMany("ReceiptCosmetics")
                        .HasForeignKey("CosmeticId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautySaloonDatabaseImplement.Models.Receipt", "Receipt")
                        .WithMany("ReceiptCosmetics")
                        .HasForeignKey("ReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeautySaloonDatabaseImplement.Models.Visit", b =>
                {
                    b.HasOne("BeautySaloonDatabaseImplement.Models.Client", "Client")
                        .WithMany("Visit")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

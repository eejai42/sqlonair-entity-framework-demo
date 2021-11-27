﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using entity_framework_test2.Models;

namespace entity_framework_test2.Migrations
{
    [DbContext(typeof(ShoppingContext))]
    [Migration("20211127213248_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("entity_framework_test2.Models.Cart", b =>
                {
                    b.Property<Guid>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CartNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CartId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cart");

                    b.HasData(
                        new
                        {
                            CartId = new Guid("41973484-2eda-403a-8f59-84afb6c66a85"),
                            CartDate = new DateTime(2021, 11, 27, 21, 32, 47, 527, DateTimeKind.Utc).AddTicks(1069),
                            CartNumber = 0,
                            CustomerId = new Guid("5f08a8db-13b7-4c64-9d9b-9f9bb8589381")
                        },
                        new
                        {
                            CartId = new Guid("03b6cb94-5a14-4cda-8a8e-7f7cb508f429"),
                            CartDate = new DateTime(2021, 11, 27, 21, 32, 47, 527, DateTimeKind.Utc).AddTicks(3087),
                            CartNumber = 0,
                            CustomerId = new Guid("18026425-03c2-42b6-9080-c7df1afed350")
                        },
                        new
                        {
                            CartId = new Guid("b97a18ea-b650-4c12-bee5-2039c33204f4"),
                            CartDate = new DateTime(2021, 11, 27, 21, 32, 47, 527, DateTimeKind.Utc).AddTicks(3095),
                            CartNumber = 0,
                            CustomerId = new Guid("d3953001-b917-4484-8dae-ca9b60610e30")
                        });
                });

            modelBuilder.Entity("entity_framework_test2.Models.CartItem", b =>
                {
                    b.Property<Guid>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CartItemId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");

                    b.HasData(
                        new
                        {
                            CartItemId = new Guid("34b80451-2750-4906-bc36-e3612d97ae37"),
                            CartId = new Guid("41973484-2eda-403a-8f59-84afb6c66a85"),
                            ProductId = new Guid("35eeb65b-b9c4-4c44-a30f-d78cf5933726"),
                            Quantity = 1m
                        },
                        new
                        {
                            CartItemId = new Guid("1d5e8dcc-1431-430e-abd4-291fd79c9c5d"),
                            CartId = new Guid("41973484-2eda-403a-8f59-84afb6c66a85"),
                            ProductId = new Guid("c0abc7ec-4932-48ce-9697-76d0bac9ced8"),
                            Quantity = 25m
                        },
                        new
                        {
                            CartItemId = new Guid("bb59e508-608b-4728-86ef-e4adccbd33e7"),
                            CartId = new Guid("03b6cb94-5a14-4cda-8a8e-7f7cb508f429"),
                            ProductId = new Guid("35eeb65b-b9c4-4c44-a30f-d78cf5933726"),
                            Quantity = 125m
                        },
                        new
                        {
                            CartItemId = new Guid("c3453ef4-4d9f-4b06-8c9a-85c0a9818574"),
                            CartId = new Guid("b97a18ea-b650-4c12-bee5-2039c33204f4"),
                            ProductId = new Guid("c0abc7ec-4932-48ce-9697-76d0bac9ced8"),
                            Quantity = 6m
                        });
                });

            modelBuilder.Entity("entity_framework_test2.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PaymentArrangementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PaymentTerm")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TaxRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CustomerId");

                    b.HasIndex("PaymentArrangementId");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            CustomerId = new Guid("5f08a8db-13b7-4c64-9d9b-9f9bb8589381"),
                            Name = "EJ",
                            PaymentArrangementId = new Guid("0da423a4-9a3e-429a-a5f4-40b1520304cf"),
                            PaymentTerm = 0,
                            PhoneNumber = "555-123-4567",
                            TaxRate = 0m
                        },
                        new
                        {
                            CustomerId = new Guid("18026425-03c2-42b6-9080-c7df1afed350"),
                            Name = "Bob",
                            PaymentArrangementId = new Guid("28d814bf-3c4a-46e8-9b32-abba46ff179a"),
                            PaymentTerm = 0,
                            PhoneNumber = "808-808-8088",
                            TaxRate = 0m
                        },
                        new
                        {
                            CustomerId = new Guid("d3953001-b917-4484-8dae-ca9b60610e30"),
                            Name = "Mary",
                            PaymentArrangementId = new Guid("0da423a4-9a3e-429a-a5f4-40b1520304cf"),
                            PaymentTerm = 0,
                            PhoneNumber = "123-456-7890",
                            TaxRate = 0m
                        });
                });

            modelBuilder.Entity("entity_framework_test2.Models.PaymentArrangement", b =>
                {
                    b.Property<Guid>("PaymentArrangementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.HasKey("PaymentArrangementId");

                    b.ToTable("PaymentArrangement");

                    b.HasData(
                        new
                        {
                            PaymentArrangementId = new Guid("0da423a4-9a3e-429a-a5f4-40b1520304cf"),
                            Term = 15
                        },
                        new
                        {
                            PaymentArrangementId = new Guid("28d814bf-3c4a-46e8-9b32-abba46ff179a"),
                            Term = 30
                        });
                });

            modelBuilder.Entity("entity_framework_test2.Models.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("35eeb65b-b9c4-4c44-a30f-d78cf5933726"),
                            Name = "Product A",
                            UnitPrice = 2.50m
                        },
                        new
                        {
                            ProductId = new Guid("c0abc7ec-4932-48ce-9697-76d0bac9ced8"),
                            Name = "Product B",
                            UnitPrice = 5.25m
                        });
                });

            modelBuilder.Entity("entity_framework_test2.Models.Cart", b =>
                {
                    b.HasOne("entity_framework_test2.Models.Customer", "Customer")
                        .WithMany("Carts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("entity_framework_test2.Models.CartItem", b =>
                {
                    b.HasOne("entity_framework_test2.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("entity_framework_test2.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("entity_framework_test2.Models.Customer", b =>
                {
                    b.HasOne("entity_framework_test2.Models.PaymentArrangement", "PaymentArrangement")
                        .WithMany("Customer")
                        .HasForeignKey("PaymentArrangementId");

                    b.Navigation("PaymentArrangement");
                });

            modelBuilder.Entity("entity_framework_test2.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("entity_framework_test2.Models.Customer", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("entity_framework_test2.Models.PaymentArrangement", b =>
                {
                    b.Navigation("Customer");
                });

            modelBuilder.Entity("entity_framework_test2.Models.Product", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
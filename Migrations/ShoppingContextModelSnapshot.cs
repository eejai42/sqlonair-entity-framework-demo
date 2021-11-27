﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using entity_framework_test2.Models;

namespace entity_framework_test2.Migrations
{
    [DbContext(typeof(ShoppingContext))]
    partial class ShoppingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            CartId = new Guid("45484328-602e-4a62-b357-389df4ca57ff"),
                            CartDate = new DateTime(2021, 11, 27, 22, 46, 41, 718, DateTimeKind.Utc).AddTicks(2783),
                            CartNumber = 1000,
                            CustomerId = new Guid("8d592aa9-c729-4789-86c9-0c00b77884e8")
                        },
                        new
                        {
                            CartId = new Guid("50946c2c-83cf-4c9c-bccc-7cc9c6d87f41"),
                            CartDate = new DateTime(2021, 11, 27, 22, 46, 41, 718, DateTimeKind.Utc).AddTicks(5736),
                            CartNumber = 1001,
                            CustomerId = new Guid("e199899f-3c5c-487e-975a-5f3773e6547a")
                        },
                        new
                        {
                            CartId = new Guid("798fd6d7-d4b9-41f3-92ac-94f91a94d90e"),
                            CartDate = new DateTime(2021, 11, 27, 22, 46, 41, 718, DateTimeKind.Utc).AddTicks(5745),
                            CartNumber = 1002,
                            CustomerId = new Guid("58e0f5cd-7de8-4c0b-8094-50d915e83b6e")
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
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CartItemId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");

                    b.HasData(
                        new
                        {
                            CartItemId = new Guid("03f1c51c-4106-4ad0-b6d3-31d9fd493ce1"),
                            CartId = new Guid("45484328-602e-4a62-b357-389df4ca57ff"),
                            ProductId = new Guid("463e8e24-61bf-4342-a64b-51338455ca83"),
                            Quantity = 1m
                        },
                        new
                        {
                            CartItemId = new Guid("804acd71-bf7e-4ca1-9b35-606a31069ca7"),
                            CartId = new Guid("45484328-602e-4a62-b357-389df4ca57ff"),
                            ProductId = new Guid("2e987de0-b832-4c8b-9da9-ceb01da2b4e1"),
                            Quantity = 25m
                        },
                        new
                        {
                            CartItemId = new Guid("aed01c16-5720-4996-8c83-adbf2b7efb3e"),
                            CartId = new Guid("50946c2c-83cf-4c9c-bccc-7cc9c6d87f41"),
                            ProductId = new Guid("463e8e24-61bf-4342-a64b-51338455ca83"),
                            Quantity = 125m
                        },
                        new
                        {
                            CartItemId = new Guid("5d515c3b-e9fd-416c-8823-8427a89778ab"),
                            CartId = new Guid("798fd6d7-d4b9-41f3-92ac-94f91a94d90e"),
                            ProductId = new Guid("2e987de0-b832-4c8b-9da9-ceb01da2b4e1"),
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

                    b.Property<int?>("PaymentTerm")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TaxRate")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("CustomerId");

                    b.HasIndex("PaymentArrangementId");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            CustomerId = new Guid("8d592aa9-c729-4789-86c9-0c00b77884e8"),
                            Name = "EJ",
                            PaymentArrangementId = new Guid("67dcb6bc-a404-43e4-a870-f468c54935c3"),
                            PaymentTerm = 15,
                            PhoneNumber = "555-123-4567",
                            TaxRate = 0.055m
                        },
                        new
                        {
                            CustomerId = new Guid("e199899f-3c5c-487e-975a-5f3773e6547a"),
                            Name = "Bob",
                            PaymentArrangementId = new Guid("727a9833-6de1-4c2d-85e0-b6744eee251f"),
                            PaymentTerm = 30,
                            PhoneNumber = "808-808-8088",
                            TaxRate = 0.0385m
                        },
                        new
                        {
                            CustomerId = new Guid("58e0f5cd-7de8-4c0b-8094-50d915e83b6e"),
                            Name = "Mary",
                            PaymentArrangementId = new Guid("67dcb6bc-a404-43e4-a870-f468c54935c3"),
                            PaymentTerm = 15,
                            PhoneNumber = "123-456-7890",
                            TaxRate = 0.025m
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
                            PaymentArrangementId = new Guid("67dcb6bc-a404-43e4-a870-f468c54935c3"),
                            Term = 15
                        },
                        new
                        {
                            PaymentArrangementId = new Guid("727a9833-6de1-4c2d-85e0-b6744eee251f"),
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
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("463e8e24-61bf-4342-a64b-51338455ca83"),
                            Name = "Product A",
                            UnitPrice = 2.50m
                        },
                        new
                        {
                            ProductId = new Guid("2e987de0-b832-4c8b-9da9-ceb01da2b4e1"),
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

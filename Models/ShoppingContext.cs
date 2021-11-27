﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_test2.Models
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var net15 = new PaymentArrangement()
            {
                Term = 15
            };

            var net30 = new PaymentArrangement()
            {
                Term = 30
            };

            modelBuilder.Entity<PaymentArrangement>().HasData(new Models.PaymentArrangement[]
            {
                net15, net30
            });

            var ej = new Customer()
            {
                Name = "EJ",
                PaymentArrangementId = net15.PaymentArrangementId,
                PhoneNumber = "555-123-4567"
            };
            var bob = new Customer()
            {
                Name = "Bob",
                PaymentArrangementId = net30.PaymentArrangementId,
                PhoneNumber = "808-808-8088"
            };
            var mary = new Customer()
            {
                Name = "Mary",
                PaymentArrangementId = net15.PaymentArrangementId,
                PhoneNumber = "123-456-7890"
            };
            modelBuilder.Entity<Customer>().HasData(new Models.Customer[]
            {
                ej, bob, mary
            });

            var productA = new Product()
            {
                Name = "Product A",
                UnitPrice = 2.50m
            };

            var productB = new Product()
            {
                Name = "Product B",
                UnitPrice = 5.25m
            };

            modelBuilder.Entity<Product>().HasData(new Models.Product[]
            {
                productA, productB
            });

            var ejsCart = new Cart() { CustomerId = ej.CustomerId };
            var bobsCart = new Cart() { CustomerId = bob.CustomerId };
            var marysCart = new Cart() { CustomerId = mary.CustomerId };

            modelBuilder.Entity<Cart>().HasData(new Models.Cart[]
            {
                ejsCart, bobsCart, marysCart
            });

            var ejItem1 = new CartItem() { CartId = ejsCart.CartId, ProductId = productA.ProductId, Quantity = 1 };
            var ejItem2 = new CartItem() { CartId = ejsCart.CartId, ProductId = productB.ProductId, Quantity = 25 };
            var bobItem1 = new CartItem() { CartId = bobsCart.CartId, ProductId = productA.ProductId, Quantity = 125 };
            var maryItem1 = new CartItem() { CartId = marysCart.CartId, ProductId = productB.ProductId, Quantity = 6 };

            modelBuilder.Entity<CartItem>().HasData(new Models.CartItem[]
            {
                ejItem1, ejItem2, bobItem1, maryItem1
            });
        }

        public DbSet<Cart> Cart { get; set; } = null!;
        public DbSet<CartItem> CartItem { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;
        public DbSet<PaymentArrangement> PaymentArrangement { get; set; } = null!;
        public DbSet<Customer> Customer { get; set; } = null!;
    }
}

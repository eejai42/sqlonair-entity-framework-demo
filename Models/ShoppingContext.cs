using Microsoft.EntityFrameworkCore;
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
            UpdateTaxRateFields(modelBuilder);
            UpdateNullibleDecimals(modelBuilder);
            UpdateDecimals(modelBuilder);

            base.OnModelCreating(modelBuilder);
            PopulateSeedData(modelBuilder);
        }

        private static void PopulateSeedData(ModelBuilder modelBuilder)
        {
            SeedPaymentArragements(modelBuilder, out var net15, out var net30);
            SeedProducts(modelBuilder, out var productA, out var productB);

            SeedCustomers(modelBuilder, net15, net30, out var ej, out var bob, out var mary);

            SeedOrders(modelBuilder, productA, productB, ej, bob, mary);
        }

        private static void SeedOrders(ModelBuilder modelBuilder, Product productA, Product productB, Customer ej, Customer bob, Customer mary)
        {
            var ejsOrder = new Order() { CustomerId = ej.CustomerId, OrderNumber = 1000 };
            var bobsOrder = new Order() { CustomerId = bob.CustomerId, OrderNumber = 1001 };
            var marysOrder = new Order() { CustomerId = mary.CustomerId, OrderNumber = 1002 };

            modelBuilder.Entity<Order>().HasData(new Models.Order[]
            {
                ejsOrder, bobsOrder, marysOrder
            });

            SeedItems(modelBuilder, productA, productB, ejsOrder, bobsOrder, marysOrder);
        }

        private static void SeedItems(ModelBuilder modelBuilder, Product productA, Product productB, Order ejsCart, Order bobsCart, Order marysCart)
        {
            var ejItem1 = new LineItem() { OrderId = ejsCart.OrderId, ProductId = productA.ProductId, Quantity = 1 };
            var ejItem2 = new LineItem() { OrderId = ejsCart.OrderId, ProductId = productB.ProductId, Quantity = 25 };
            var bobItem1 = new LineItem() { OrderId = bobsCart.OrderId, ProductId = productA.ProductId, Quantity = 125 };
            var maryItem1 = new LineItem() { OrderId = marysCart.OrderId, ProductId = productB.ProductId, Quantity = 6 };

            modelBuilder.Entity<LineItem>().HasData(new Models.LineItem[]
            {
                ejItem1, ejItem2, bobItem1, maryItem1
            });
        }

        private static void SeedProducts(ModelBuilder modelBuilder, out Product productA, out Product productB)
        {
            productA = new Product()
            {
                Name = "Product A",
                UnitPrice = 2.50m
            };
            productB = new Product()
            {
                Name = "Product B",
                UnitPrice = 5.25m
            };
            modelBuilder.Entity<Product>().HasData(new Models.Product[]
            {
                productA, productB
            });
        }

        private static void SeedCustomers(ModelBuilder modelBuilder, PaymentArrangement net15, PaymentArrangement net30, out Customer ej, out Customer bob, out Customer mary)
        {
            ej = new Customer()
            {
                Name = "EJ",
                PaymentArrangementId = net15.PaymentArrangementId,
                PhoneNumber = "555-123-4567",
                PaymentTerm = 15,
                TaxRate = 0.055m
            };
            bob = new Customer()
            {
                Name = "Bob",
                PaymentArrangementId = net30.PaymentArrangementId,
                PhoneNumber = "808-808-8088",
                PaymentTerm = 30,
                TaxRate = 0.0385m
            };
            mary = new Customer()
            {
                Name = "Mary",
                PaymentArrangementId = net15.PaymentArrangementId,
                PhoneNumber = "123-456-7890",
                PaymentTerm = 15,
                TaxRate = 0.025m
            };
            modelBuilder.Entity<Customer>().HasData(new Models.Customer[]
{
                ej, bob, mary
});
        }

        private static void SeedPaymentArragements(ModelBuilder modelBuilder, out PaymentArrangement net15, out PaymentArrangement net30)
        {
            net15 = new PaymentArrangement()
            {
                Term = 15,
                TermName = "NET 15"
            };
            net30 = new PaymentArrangement()
            {
                Term = 30,
                TermName = "NET 30"
            };
            modelBuilder.Entity<PaymentArrangement>().HasData(new Models.PaymentArrangement[]
            {
                net15, net30
            });
        }

        private static void UpdateDecimals(ModelBuilder modelBuilder)
        {
            var decimals = new[]
            {
                modelBuilder.Entity<LineItem>().Property(cartItem => cartItem.Quantity)
                ,modelBuilder.Entity<LineItem>().Property(cartItem => cartItem.Quantity)
                ,modelBuilder.Entity<Product>().Property(product => product.UnitPrice)
                ,modelBuilder.Entity<Product>().Property(product => product.UnitPrice)
            };

            decimals.ToList().ForEach(property =>
            {
                property.HasPrecision(18, 2);
            });
        }

        private static void UpdateNullibleDecimals(ModelBuilder modelBuilder)
        {
#if WITH_CALCULATED_FIELDS
            var nullibleDecimals = new[]
            {
                modelBuilder.Entity<Cart>().Property(cart => cart.SubTotal)
                ,modelBuilder.Entity<Cart>().Property(cart => cart.Tax)
                ,modelBuilder.Entity<Cart>().Property(cart => cart.Total)
                ,modelBuilder.Entity<CartItem>().Property(cartItem => cartItem.SubTotal)
                ,modelBuilder.Entity<CartItem>().Property(cartItem => cartItem.Tax)
                ,modelBuilder.Entity<CartItem>().Property(cartItem => cartItem.Total)
                ,modelBuilder.Entity<CartItem>().Property(cartItem => cartItem.UnitPrice)
                ,modelBuilder.Entity<Customer>().Property(customer => customer.OrderTotal)
                ,modelBuilder.Entity<Product>().Property(product => product.OrderQuantity)
                ,modelBuilder.Entity<Product>().Property(product => product.OrderTotal)
        };

            nullibleDecimals.ToList().ForEach(property =>
            {
                property.HasPrecision(18, 2);
            });
#endif
        }

        private static void UpdateTaxRateFields(ModelBuilder modelBuilder)
        {
            var taxRates = new[]
 {
            modelBuilder.Entity<Customer>().Property(product => product.TaxRate)
#if WITH_CALCULATED_FIELDS
            ,modelBuilder.Entity<Customer>().Property(detail => detail.TaxRate)
            ,modelBuilder.Entity<Cart>().Property(order => order.CustomerTaxRate)
            ,modelBuilder.Entity<CartItem>().Property(detail => detail.CustomerTaxRate)
#endif
        };

            taxRates.ToList().ForEach(property =>
            {
                property.HasPrecision(18, 4);
            });
        }

        public DbSet<Order> Order { get; set; } = null!;
        public DbSet<LineItem> LineItem { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;
        public DbSet<PaymentArrangement> PaymentArrangement { get; set; } = null!;
        public DbSet<Customer> Customer { get; set; } = null!;
    }
}

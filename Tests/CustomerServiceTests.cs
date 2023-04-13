//using Microsoft.AspNetCore.Routing;
//using Microsoft.EntityFrameworkCore;
//using NUnit.Framework;
//using ProvaPub.Models;
//using ProvaPub.Repository;
//using ProvaPub.Services;
//using System;

//namespace ProvaPub.Tests
//{
//    [TestFixture]
//    public class CustomerServiceTests
//    {
//        private TestDbContext _ctx;
//        private CustomerService _customerService;

//        [SetUp]
//        public void Setup()
//        {
//            // Setup the database context
//            var options = new DbContextOptionsBuilder<TestDbContext>()
//                .UseInMemoryDatabase(databaseName: "TestDatabase")
//                .Options;
//            _ctx = new TestDbContext(options);

//            // Seed some test data
//            var customer = new Customer { Id = 1, Name = "John" };
//            _ctx.Customers.Add(customer);
//            _ctx.SaveChanges();

//            _customerService = new CustomerService(_ctx);
//        }

//        [Test]
//        public void CanPurchase_CustomerDoesNotExist_ThrowsException()
//        {
//            // Arrange
//            int customerId = 999;
//            decimal purchaseValue = 10;

//            // Act & Assert
//            Assert.ThrowsAsync<InvalidOperationException>(() => _customerService.CanPurchase(customerId, purchaseValue));
//        }

//        [Test]
//        public async Task CanPurchase_MoreThanOnePurchaseThisMonth_ReturnsFalse()
//        {
//            // Arrange
//            int customerId = 1;
//            decimal purchaseValue = 10;

//            // Seed some test data
//            var order1 = new Order { OrderDate = DateTime.UtcNow.AddDays(-5), Value = 5 };
//            var order2 = new Order { OrderDate = DateTime.UtcNow.AddDays(-3), Value = 7 };
//            var customer = await _ctx.Customers.FindAsync(customerId);
//            customer.Orders.Add(order1);
//            customer.Orders.Add(order2);
//            _ctx.SaveChanges();

//            // Act
//            bool result = await _customerService.CanPurchase(customerId, purchaseValue);

//            // Assert
//            Assert.IsFalse(result);
//        }

//        [Test]
//        public async Task CanPurchase_FirstPurchaseMoreThan100_ReturnsFalse()
//        {
//            // Arrange
//            int customerId = 1;
//            decimal purchaseValue = 110;

//            // Act
//            bool result = await _customerService.CanPurchase(customerId, purchaseValue);

//            // Assert
//            Assert.IsFalse(result);
//        }

//        [Test]
//        public async Task CanPurchase_ValidPurchase_ReturnsTrue()
//        {
//            // Arrange
//            int customerId = 1;
//            decimal purchaseValue = 50;

//            // Act
//            bool result = await _customerService.CanPurchase(customerId, purchaseValue);

//            // Assert
//            Assert.IsTrue(result);
//        }
//    }
//}
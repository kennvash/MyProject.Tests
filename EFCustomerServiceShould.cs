using Microsoft.EntityFrameworkCore;
using Moq;
using MyStore.Data;
using MyStore.Models;
using MyStore.Services;

namespace MyProject.Tests
{
    public class EFCustomerServiceShould
    {

        [Fact]
        private void GetAllCustomers()
        {
            var mockData = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Kenn",
                    LastName = "Acabal",
                    Address = "LB",
                    ContactNumber = "09876543212",
                    Email = "k@g.c"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Von",
                    LastName = "Acaba",
                    Address = "Bulacan",
                    ContactNumber = "12345678909",
                    Email = "v@g.c"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(mockData.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(mockData.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(c => c.Customers).Returns(mockSet.Object);

            var mockService = new EFCustomerService(mockContext.Object);
            var customers = mockService.GetAll();

            Assert.Equal(2, customers.Count);
            Assert.Equal(mockData.ElementAt(0), customers[0]);
            Assert.Equal(mockData.ElementAt(1), customers[1]);
        }

        [Fact]
        private void FindById()
        {
            var mockData = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Kenn",
                    LastName = "Acabal",
                    Address = "LB",
                    ContactNumber = "09876543212",
                    Email = "k@g.c"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Von",
                    LastName = "Acaba",
                    Address = "Bulacan",
                    ContactNumber = "12345678909",
                    Email = "v@g.c"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(mockData.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(mockData.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(c => c.Customers).Returns(mockSet.Object);

            var mockService = new EFCustomerService(mockContext.Object);
            var customer = mockService.FindById(1);

            Assert.Equal(mockData.ElementAt(0), customer);
        }

        [Fact]
        private void DeleteById()
        {
            var mockData = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Kenn",
                    LastName = "Acabal",
                    Address = "LB",
                    ContactNumber = "09876543212",
                    Email = "k@g.c"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Von",
                    LastName = "Acaba",
                    Address = "Bulacan",
                    ContactNumber = "12345678909",
                    Email = "v@g.c"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(mockData.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(mockData.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(c => c.Customers).Returns(mockSet.Object);

            var mockService = new EFCustomerService(mockContext.Object);
            bool deleteResult = mockService.Delete(2);

            Assert.True(deleteResult);
        }

        [Fact]
        private void AddNewCustomer()
        {
            var mockData = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Kenn",
                    LastName = "Acabal",
                    Address = "LB",
                    ContactNumber = "09876543212",
                    Email = "k@g.c"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Von",
                    LastName = "Acaba",
                    Address = "Bulacan",
                    ContactNumber = "12345678909",
                    Email = "v@g.c"}
            }.AsQueryable();

            Customer mockCustomer = new Customer
            {
                FirstName = "John",
                LastName = "Wick",
                ContactNumber = "09171234567",
                Address = "Tondo",
                Email = "jw@g.c"
            };

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(mockData.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(mockData.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(c => c.Customers).Returns(mockSet.Object);

            var mockService = new EFCustomerService(mockContext.Object);
            var customer = mockService.Save(mockCustomer);

            Assert.NotNull(customer.Id);
            Assert.Equal(mockCustomer.FirstName, customer.FirstName);
        }

        [Fact]
        private void UpdateExistingCustomer()
        {
            var mockData = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Kenn",
                    LastName = "Acabal",
                    Address = "LB",
                    ContactNumber = "09876543212",
                    Email = "k@g.c"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Von",
                    LastName = "Acaba",
                    Address = "Bulacan",
                    ContactNumber = "12345678909",
                    Email = "v@g.c"}
            }.AsQueryable();

            Customer mockCustomer = new Customer
            {
                Id = 2,
                FirstName = "Von",
                LastName = "Wick",
                Address = "Bulacan",
                ContactNumber = "12345678909",
                Email = "v@g.c"
            };

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(mockData.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(mockData.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(c => c.Customers).Returns(mockSet.Object);

            var mockService = new EFCustomerService(mockContext.Object);
            var customer = mockService.Save(mockCustomer);

            Assert.Equal(mockCustomer.LastName, customer.LastName);
        }
    }
}
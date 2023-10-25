using Customers.WebApi.Models;
using Customers.WebApi.Models.ResponseModels;
using Customers.WebApi.Repository;
using Moq;

namespace Customers.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Validate_Customer_If_Exist_Should_Be_False()
        {
            Mock<ICustomerService> _mockCustomerService = new Mock<ICustomerService>();
            Response expectedResponse = new Response(false);
            _mockCustomerService.Setup(service => service.ValidateAsync(It.IsAny<Guid>())).ReturnsAsync(expectedResponse);

            Guid guid = Guid.NewGuid();
            Response response = await _mockCustomerService.Object.ValidateAsync(guid);

            Assert.IsFalse(response.Success);

        }
        [Test]
        public async Task GetByIdAsync_Should_Be_False()
        {
            Mock<ICustomerService> _mockCustomerService = new Mock<ICustomerService>();

            DataResponse<Customer> expectedResponse = new DataResponse<Customer>(null, false);
            _mockCustomerService.Setup(service => service.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(expectedResponse);

            Guid guid = Guid.NewGuid();
            DataResponse<Customer> response = await _mockCustomerService.Object.GetByIdAsync(guid);

            Assert.IsFalse(response.Success);

        }

        [Test]
        public async Task Customer_Id_Should_Not_Be_Null()
        {
            Mock<ICustomerService> _mockCustomerService = new Mock<ICustomerService>();

            DataResponse<Guid> expectedResponse = new DataResponse<Guid>(Guid.NewGuid(), true); // Set Success to true and provide a non-empty Guid
            var customer2 = new Customer { Name = "Muhammed", Email = "m.akin4990@gmail.com", CreatedAt = DateTime.UtcNow, Address = new() };

            _mockCustomerService.Setup(service => 
                                      service.CreateAsync(It.Is<Customer>(
                                          customer =>
                                            customer.Id == Guid.Empty && 
                                           !string.IsNullOrEmpty(customer.Name) && 
                                           !string.IsNullOrEmpty(customer.Email)))).ReturnsAsync(expectedResponse);


            DataResponse<Guid> response = await _mockCustomerService.Object.CreateAsync(customer2);

            Assert.IsTrue(response.Success); // Ensure that Success is true
            Assert.That(response.Data, Is.Not.EqualTo(Guid.Empty)); // 

        }
    }
}
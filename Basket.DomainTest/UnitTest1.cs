using System;
using System.Threading;
using Basket.Api.Controllers;
using Basket.Application.Requests;
using Basket.Application.Services;
using Basket.Definition.Request;
using Basket.Domain;
using Basket.Domain.Contracts;
using Moq;
using Xunit;

namespace Basket.DomainTest
{
    public class UnitTest1
    {
        public Mock<IProductRepository> mock = new Mock<IProductRepository>();
        [Fact]  
        public async void GetProductById()
        {
            var cT = new CancellationToken();
            var apRequest = new SearchProductApplicationRequest()
            {
                ProductId = new Guid("0CA31F19-B050-4965-95E8-3B58A3004C06")
            };
            var expectedProduct = Product.CreateProduct("item2", 57.0, 4);
            mock.Setup(p => p.SearchProduct(new Guid("0CA31F19-B050-4965-95E8-3B58A3004C06"),cT)).ReturnsAsync(expectedProduct);  
            ProductService pro = new ProductService(mock.Object);
            var result = await pro.SearchProduct(apRequest, cT);  
            Assert.Equal(expectedProduct, result);  
        }  
        /*[Fact]  
        public async void GetEmployeeDetails()  
        {  
            var employeeDTO = new Employee()  
            {  
                Id = 1,  
                Name = "JK",  
                Desgination = "SDE"  
            };  
            mock.Setup(p => p.GetEmployeeDetails(1)).ReturnsAsync(employeeDTO);  
            EmployeeController emp = new EmployeeController(mock.Object);  
            var result = await emp.GetEmployeeDetails(1);  
            Assert.True(employeeDTO.Equals(result));  
        }  */
    }
}
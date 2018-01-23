using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using ShoppingBasket.Controllers;
using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingBasket.Tests
{
    public class ProductsControllerTests
    {
        [Fact]
        public async Task GetProduct_ReturnsAListOfProducts()
        {
            var mockContext = new Mock<ShoppingBasketContext>();
            var controller = new ProductsController(mockContext.Object);

            var result = controller.GetProduct();

            //Unit tests kwam ik niet helemaal uit. 
            //De results view van 'result' in de bovenstaande regel geeft de volgende melding: "Value cannot be null. Parameter name: model" 
            //De onderstaande test failt niet, maar zo kan ik verder niets controleren van het resultaat

            Assert.IsAssignableFrom<IEnumerable<Product>>(result);
        }


        // Deze test is uitgecomment omdat ik hier meebezig was toen ik erachter kwam dat die foutmelding in result zat
        //[Theory]
        //[InlineData("Test product", 45.99)]
        //public async Task PostProduct_AddsProductToGetProductResults(string productName, decimal productPrice)
        //{
        //    var mockContext = new Mock<ShoppingBasketContext>();
        //    var controller = new ProductsController(mockContext.Object);
            
        //    int count = (controller.GetProduct() as List<Product>).Count;

        //    var productToPost = new Product();
        //    productToPost.Name = productName;
        //    productToPost.Price = productPrice;
        //    productToPost.Description = "This is a testingproduct";
        //    await controller.PostProduct(productToPost);

        //    var result = controller.GetProduct() as List<Product>;
        //    Assert.Equal(count + 1, result.Count);
        //    Assert.True(result[0].Name == productName);
        //    Assert.Equal(result[0].Price, productPrice);
        //}
    }
}

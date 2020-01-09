
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using SportsStore.Domain.Abstract;
//using SportsStore.Domain.Entities;
//using System.Collections.Generic;
//using SportsStore.Web_1;
//using System.Linq;
//using System.Web.Mvc;
//using SportsStore.Web_1.Controllers;

//namespace SportsStore.Tests
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        [TestMethod]
//        public void Can_Paginate()
//        {
//            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
//            mock.Setup(m => m.Products).Returns(new Product[]
//            {
//                new Product {ProductId=1,Name="p1"},
//                new Product {ProductId=2,Name="p2"},
//                new Product {ProductId=3,Name="p3"},
//                new Product {ProductId=4,Name="p4"},
//                new Product {ProductId=5,Name="p5"}
//            }.AsQueryable());
//            ProductController controller = new ProductController(mock.Object);
//            controller.pageSize = 3;
//            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2);

//            Product[] prodArray = result.ToArray();
//            Assert.IsTrue(prodArray.Length == 2);
//            Assert.AreEqual(prodArray[0].Name, "P4");
//            Assert.AreEqual(prodArray[1].Name, "P5");
//        }
//    }
//}

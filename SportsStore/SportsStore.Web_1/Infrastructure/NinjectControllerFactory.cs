using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;
using System.Configuration;

namespace SportsStore.Web_1.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        IKernel kernel;
        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBiding();
        }

        public void AddBiding()
        {
            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product {Name="Futball",Price=125.0m,ID=101 },
            //    new Product {Name="Tenis",Price=125.0m,ID=102 },
            //    new Product {Name="Gimnaztika",Price=125.0m,ID=103 },
            //    new Product {Name="BOX",Price=125.0m,ID=104 }
            //}.AsQueryable);
            kernel.Bind<IProductsRepository>().To<EFProductRepository>();
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
               .AppSettings["Email.WriteAsFile"] ?? "false")
            };
            kernel.Bind<IOrderProcerssor>()
            .To<EmailOrderProcessor>()
            .WithConstructorArgument("settings", emailSettings);
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return  controllerType==null?null:(IController)kernel.Get(controllerType);
        }
    }
}
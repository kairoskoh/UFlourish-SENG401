using JokesWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JokesWebApp.Controllers
{
    [TestClass]
    public class Request_Mental_HealthControllerTests
    {
        private readonly ApplicationDbContext _context;
        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new Request_Mental_HealthController(_context);
            var result = controller.Details(1);
            Console.WriteLine(result);
            Console.WriteLine("hedd");
            //controller.Details(2) as ViewResult;
            //Assert.AreEqual("Details", result.ViewName);

        }
    }
}


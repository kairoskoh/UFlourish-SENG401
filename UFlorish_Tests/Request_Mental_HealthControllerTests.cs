using JokesWebApp.Controllers;
using JokesWebApp.Data;
using JokesWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace UFlorish_Tests
{
    public class Request_Mental_HealthControllerTests
    {
        private ApplicationDbContext _context;
        [Fact]
        public async Task Test_DetailsView()
        {
            var model = new Request_Mental_Health
            {
                Id = 1,
                UserName = "test_details@gmail.com",
                Date = DateTime.Now
            };
            Assert.Equal("test_details@gmail.com", model.UserName);
            //Testing if data is stored and reterived properly
           

            // _context.Add(model);
            //await _context.SaveChangesAsync();
            var controller = new Request_Mental_HealthController(_context);
           
            //_context.Request_Mental_Health.Add(model);
            //getting data using controler
           
            ViewResult? result = (ViewResult?)await controller.Details(1);
            //Assert.NotNull(result);
            Assert.Equal("Details", result.ViewData["Title"]);

        }
        [Fact]
        public void Test_CreateView()
        {
            var controller = new Request_Mental_HealthController(_context);
            ViewResult? result = (ViewResult?) controller.Create();
            Assert.NotNull(result);
            Assert.Equal("Create", result.ViewName);


        }
    }
}
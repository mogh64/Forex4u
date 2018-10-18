using forex4u.Controllers;
using forex4u.Infrastructure;
using forex4u.Models;
using forex4u.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private IConfigurationRoot _configuration;

        // represents database's configuration
        private DbContextOptions<ApplicationDbContext> _options;

        public object TokenController { get; private set; }
        [TestInitialize]
        public void Initialize()
        {
            try
            {
                var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

                _configuration = builder.Build();
                _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(_configuration["Data:forex4u:ConnectionString"])
                    .Options;
            }
            catch(Exception ex)
            {
                throw ex;
            }
                

        }


        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                using (var contex = new ApplicationDbContext(_options))
                {
                    StockUser stockUser = new StockUser()
                    {
                        Email = "ali@g.com",
                        FirstName = "ali",
                        LastName = "garom",
                        MobileNumber = "09124568897",
                        WebPassword = "1234qwer"
                    };
                    UserController controller = new UserController(new UserEfRepository(contex));
                   var user =  controller.Post(stockUser);

                    Assert.IsTrue(user.StockUserId > 0);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
            

            
        }
    }
}

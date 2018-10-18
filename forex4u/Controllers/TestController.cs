using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace forex4u.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : Controller
    {
        [HttpGet, Authorize]
        public IEnumerable<TestBook> Get()
        {
            var currentUser = HttpContext.User;
            var books = new List<TestBook>()
            {
                new TestBook("asd","123"),
                new TestBook("zxc","4745"),
                new TestBook("dfdf","845")
            };
            return books;
        }
    }
    public class TestBook
    {
        public TestBook(string name,string isbn)
        {
            Name = name;
            ISBN = isbn;
        }
        public string Name { get; set; }
        public string ISBN { get; set; }
    }
}
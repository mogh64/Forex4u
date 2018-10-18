using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using forex4u.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using forex4u.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace forex4u.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        IUserRepository repository;
        public UserController(IUserRepository _repository) => repository = _repository;

        [HttpGet, Authorize]
        public IEnumerable<StockUser> Get() => repository.Get();

        [HttpGet("{id}"), Authorize]
        public StockUser Get(int id) => repository.Get(id);

        [HttpPost, Authorize]
        public StockUser Post([FromBody] StockUser res) =>
            repository.Add(res);


        [HttpPut, Authorize]
        public StockUser Put([FromBody] StockUser res) =>
            repository.Update(res);

        [HttpPatch("{id}"), Authorize]
        public StatusCodeResult Patch(int id,
                [FromBody]JsonPatchDocument<StockUser> patch)
        {
            StockUser res = Get(id);
            if (res != null)
            {
                patch.ApplyTo(res);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}"), Authorize]
        public void Delete(int id) => repository.Delete(id);



    }
}
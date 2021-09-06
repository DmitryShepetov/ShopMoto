using Microsoft.AspNetCore.Mvc;
using ShopMoto.Data.Interfaces;
using ShopMoto.Data.Model;
using ShopMoto.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IBaseRepository User;
        public UsersController(IBaseRepository user)
        {
            User = user;
        }

        // GET: api/Users
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(User.GetAll());
        }

        // GET api/<Val
        // uesController>/5
/*        [HttpGet("{id}")]
*//*        public JsonResult Get(int id)
        {
            if (id == 5)
                return BadRequest("Не найден value");
            return "value";
        }*/

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public JsonResult Put(User user)
        {
            bool success = true;
            var document = User.Get(user.Id);
            try
            {
                if (document != null)
                {
                    document = User.Update(user);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult($"Update successful {document.Id}") : new JsonResult("Update was not successful");
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(Guid id)
        {
            bool success = true;
            var document = User.Get(id);

            try
            {
                if (document != null)
                {
                    User.Delete(document.Id);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult("Delete successful") : new JsonResult("Delete was not successful");
        }
    }
}

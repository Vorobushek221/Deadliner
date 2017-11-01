using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Deadliner.Models;

namespace Deadliner.Controllers
{
    [Produces("application/json")]
    [Route("api/Values")]
    public class ValuesController : Controller
    {
        // GET: api/Values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            using (var context = new DatabaseEntitiesCotext())
            {
                try
                {
                    context.Users.Add(new User()
                    {
                        Name = "Dmitry",
                        Age = 21
                    });
                
                    context.SaveChanges();

                }
                catch(Exception ex)
                {

                }

                var userArray = new string[10];
                var users = context.Users.ToList();
                users.ForEach(user => userArray[user.Id - 1] = user.Name.ToString());

                return userArray;
            }
        }

        // GET: api/Values/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

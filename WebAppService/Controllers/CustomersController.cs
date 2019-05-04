using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/values
        // Authorize attribute on top of the GET method restricts the access to only authorized users that are logged in.
        [HttpGet, Authorize]
        public IEnumerable<string> GetLoginAction()
        {
            return new string[] { "John Doe", "Jane Doe" };
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string GetByIDAction(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void PostCreateAction([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void PutUpdateAction(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void DeleteByIDAction(int id)
        //{
        //}
    }
}

﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BiddHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
      

        // POST api/<CompanyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

     
    }
}

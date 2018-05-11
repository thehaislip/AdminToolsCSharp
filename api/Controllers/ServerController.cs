﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    
    public class ServerController : Controller
    {
        // GET api/server
        [HttpGet]
        public IActionResult Get()
        {
            var result = new[] {
                new { FirstName = "John", LastName = "Doe" },
                new { FirstName = "Mike", LastName = "Smith" }
            };

            return Ok(result);
        }

        [HttpGet("{farm}")]
        public IActionResult Get(string farm)
        {
            var result = new[] {
              
                new { FirstName = "Mike", LastName = "Smith" }
            };


            return Ok(result);
        }
    }
}
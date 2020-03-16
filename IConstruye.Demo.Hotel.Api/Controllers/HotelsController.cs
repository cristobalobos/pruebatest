using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Search.Models;


namespace IConstruye.Demo.Hotel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
       
        public HotelsController()
        {
           
        }

        [HttpGet]
        public  IList<SearchResult<Models.Hotel>> Get(string searchText)
        {
            throw new NotImplementedException();
        }

    }
}
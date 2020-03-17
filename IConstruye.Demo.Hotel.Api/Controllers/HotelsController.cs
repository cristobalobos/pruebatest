using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace IConstruye.Demo.Hotel.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CORSAngularPolicy")]
    public class HotelsController : ControllerBase
    {
     
        private readonly IConfiguration config;
        private static SearchServiceClient _serviceClient;
        private static ISearchIndexClient _indexClient;

        [BindProperty]
        public string SearchText { get; set; }
        public HotelsController()
        {

            string searchServiceName = "azs-playground"; //config["SearchServiceName"];
            string queryApiKey = "EA4510A6219E14888741FCFC19BFBB82"; //config["SearchServiceQueryApiKey"];

            // Create a service and index client.
            _serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(queryApiKey));
            _indexClient = _serviceClient.Indexes.GetClient("hotels");
        }

        public IList<SearchResult<Models.Hotel>> ResultList { get; set; }


        [HttpGet]
        [Route("~/api/GetHotel")]
        public IList<SearchResult<Models.Hotel>> Get(string searchText)
        {
            var parameters = new SearchParameters
            {
                // Enter Hotel property names into this list so only these values will be returned.
                // If Select is empty, all values will be returned, which can be inefficient.
                Select = new[] { "HotelName", "Description" }
            };

            var results = _indexClient.Documents.SearchAsync<Models.Hotel>(SearchText, parameters);
            ResultList = results.Result.Results;
            return ResultList;
        }



    }
}
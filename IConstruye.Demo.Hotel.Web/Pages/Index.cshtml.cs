using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IConstruye.Demo.Hotel.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration config;
        private static SearchServiceClient _serviceClient;
        private static ISearchIndexClient _indexClient;

        [BindProperty]
        public string SearchText { get; set; }

        public IndexModel(IConfiguration config, ILogger<IndexModel> logger)
        {
            this.config = config;
            _logger = logger;
            string searchServiceName = config["SearchServiceName"];
            string queryApiKey = config["SearchServiceQueryApiKey"];

            // Create a service and index client.
            _serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(queryApiKey));
            _indexClient = _serviceClient.Indexes.GetClient("hotels");
        }   

       

        public IList<SearchResult<Models.Hotel>> ResultList { get; set; }
       

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var parameters = new SearchParameters
            {
                // Enter Hotel property names into this list so only these values will be returned.
                // If Select is empty, all values will be returned, which can be inefficient.
                Select = new[] { "HotelName", "Description" }
            };

            // For efficiency, the search call should be asynchronous, so use SearchAsync rather than Search.
            var results = await _indexClient.Documents.SearchAsync<Models.Hotel>(SearchText, parameters);
            ResultList = results.Results;
            return Page();

        }
    }
}

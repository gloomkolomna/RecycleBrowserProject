using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using RecycleProject;
using RecycleProject.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Xunit;
using Newtonsoft.Json.Linq;

namespace RecycleTests
{
    public class RecycleMapControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public RecycleMapControllerTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()                
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }


        [Fact]
        public async System.Threading.Tasks.Task GetCategoriesTestAsync()
        {
            IEnumerable<Category> responseModel = null;
            var response = await _client.GetAsync("api/recycle_map/categories");
            if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Content != null && response.Content.Headers.ContentLength > 0)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                responseModel = JsonConvert.DeserializeObject<IEnumerable<Category>>(responseString);
            }

            Assert.NotEmpty(responseModel);
        }

        [Fact]
        public async System.Threading.Tasks.Task AddCategoryTestAsync()
        {
            Category responseModel = null;

            var category = new Category
            {
                Name = "Новая категория",
                Description = "Новая категория для теста"
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(category));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync("api/recycle_map/add_category", content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Content != null && response.Content.Headers.ContentLength > 0)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                dynamic result = JObject.Parse(responseString);
                responseModel = JsonConvert.DeserializeObject<Category>(result.value.ToString());
            }

            Assert.NotEqual(category.Id, responseModel?.Id);
        }
    }
}

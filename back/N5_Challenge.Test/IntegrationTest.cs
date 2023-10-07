using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using N5Challenge.Api;
using N5Challenge.Domain.Models;
using Newtonsoft.Json;

namespace N5_Challenge.Test
{
    public class IntegrationTest
    {
        private WebApplicationFactory<Program> _application;
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _application = new CustomWebApplicationFactory<Program>();
            _httpClient = _application.CreateClient();
        }

        [Test]
        public async Task Get()
        {
            var response = await _httpClient.GetAsync($"Permission");

            Assert.That(response.StatusCode == HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            var permissions = JsonConvert.DeserializeObject<IEnumerable<Permission>>(content);

            Assert.IsNotNull(permissions);
        }

        [Test]
        public async Task GetPermissionById()
        {
            int permissionId = 1;

            var response = await _httpClient.GetAsync($"Permission/{permissionId}");

            Assert.That(response.StatusCode == HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            var actualPermission = JsonConvert.DeserializeObject<Permission>(content);

            Assert.IsNotNull(actualPermission);
            Assert.That(permissionId == actualPermission.Id);
        }

        [Test]
        public async Task ModifyPermission()
        {
            var permissionDto = new PermissionDto() { Id = 1, Name = "Juan", Surname = "Perez", PermissionDate = DateTime.Now, PermissionTypeId = 1 };
            StringContent queryString = new StringContent(JsonConvert.SerializeObject(permissionDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"Permission", queryString);

            Assert.That(response.StatusCode == HttpStatusCode.OK);
        }
    }
}
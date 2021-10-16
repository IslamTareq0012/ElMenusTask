using Microsoft.AspNetCore.Mvc.Testing;
using Ordering.API;
using Ordering.Infrastructure.Context;
using System;
using System.Net.Http;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using System.Text;
using Ordering.Services.DTOs;
using System.Threading.Tasks;

namespace IntegrationTest
{
    public class CheckoutEndpointTest
    {
        protected readonly HttpClient TestClient;

        protected CheckoutEndpointTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(EFContext));
                        services.AddDbContext<EFContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });

            TestClient = appFactory.CreateClient();
        }
        [Fact]
        public async Task Post_CheckoutOrderAsync()
        {
            //ARRANGE 
            var request = new HttpRequestMessage(HttpMethod.Post, "/orders/CheckOutOrder");

            request.Content = new StringContent(
                    JsonConvert.SerializeObject(new OrderDTO()
                    {
                        Address = "",
                        BuyerID = 1,
                        PaymentTypeID = 1,
                        ItemsIDs = new System.Collections.Generic.List<int>() { 1, 2, 3 }
                    }),
                    Encoding.UTF8, "application/json");

            //ACT
            var response = await TestClient.SendAsync(request);

            //ASSERT
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}

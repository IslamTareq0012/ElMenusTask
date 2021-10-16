using Microsoft.Extensions.DependencyInjection;
using Moq;
using Ordering.Infrastructure.Context;
using Ordering.Services.Payment.Services;
using Ordering.Services.Services.Implementations;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Services.Test
{
    public class OrderServiceTest
    {
        private readonly EFContext _context;
        private readonly Ordering.Infrastructure.RepositoryImplementaion.OrderingReopsitory _reopsitory;

        public OrderServiceTest()
        {
            _context = DatabaseMock.Create();
            _reopsitory = new Ordering.Infrastructure.RepositoryImplementaion.OrderingReopsitory(_context);
        }
        [Fact]
        public async Task TestCrateOrder()
        {

            //ARRANGE

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(CardPayment)))
                .Returns(new CardPayment());

            var serviceScope = new Mock<IServiceScope>();
            serviceScope.Setup(x => x.ServiceProvider).Returns(serviceProvider.Object);

            var serviceScopeFactory = new Mock<IServiceScopeFactory>();
            serviceScopeFactory.Setup(x => x.CreateScope()).Returns(serviceScope.Object);
            var service = new OrderingService(_reopsitory, serviceScopeFactory.Object);



            //ACT
            var result = await service.CrateOrderAsync(new Ordering.Services.DTOs.OrderDTO()
            {
                ItemsIDs = new System.Collections.Generic.List<int>() { 1, 2, 3 },
                Address = "",
                BuyerID = 1,
                PaymentTypeID = 1
            });

            //ASSERT
            Assert.IsType<string>(result.Data.PaymentURLResponse);
            Assert.True(result.Data.IsSuccessfullyCheckOut);
        }
    }
}

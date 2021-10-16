using Microsoft.EntityFrameworkCore;
using Ordering.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Test
{
    public static class DatabaseMock
    {
        public static EFContext Create()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
                .EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true)
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new EFContext(options);
            context.Database.EnsureCreated();

            for (int i = 0; i < 3; i++)
            {
                context.OrderItems.Add(new Ordering.Domain.Order.Aggregate.OrderItem() 
                { 
                    isValid = true,
                    ItemPrice = 5.0m,
                    Name = "FAKE ORDER " + i.ToString(),
                });

            }
            context.SaveChanges();

            return context;
        }
    }
}

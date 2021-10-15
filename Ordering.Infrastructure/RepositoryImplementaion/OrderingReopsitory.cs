using Ordering.Domain.Repositories.Interface;
using Ordering.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.RepositoryImplementaion
{
    class OrderingReopsitory : IOrderingRepository
    {
        private readonly EFContext _context;
        public OrderingReopsitory(EFContext context)
        {
            _context = context;
        }
        public void SaveChecedkOutOrder()
        {
            throw new NotImplementedException();
        }
    }
}

using Tdd.Core.Models;

namespace Tdd.Core.Repositories
{
    public interface IOrderRepository
    {
        public Task AddAsync(Order order, CancellationToken cancellationToken);
        Order? GetAsync(int basketId);
    }
}


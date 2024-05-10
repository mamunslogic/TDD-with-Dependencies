using Tdd.Core.Models;
using Tdd.Core.Repositories;

namespace Tdd.Core.Test.Fakes
{
    public class FakeOrderRepository : IOrderRepository
    {
        private Dictionary<int, Order> _data = new();

        public Task AddAsync(Order order, CancellationToken cancellationToken)
        {
            _data.Add(order.BasketId, order);
            return Task.CompletedTask;
        }

        public Order? GetAsync(int busketId)
        {
            _data.TryGetValue(busketId, out var order);
            return order;
        }
    }
}

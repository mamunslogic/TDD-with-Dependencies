using Tdd.Core.Models;
using Tdd.Core.Repositories;

namespace Tdd.Core.Test.Fakes
{
    public class FakeBasketRepository : IBasketRepository
    {
        private Dictionary<int, Basket> _data = new();
        public Task<Basket?> GetAsync(int busketId, CancellationToken cancellationToken)
        {
            _data.TryGetValue(busketId, out var basket);
            return Task.FromResult(basket);
        }

        public void Add(int id, Basket basket) => _data.Add(id, basket);
    }
}

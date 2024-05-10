using Tdd.Core.Models;

namespace Tdd.Core.Repositories
{
    public interface IBasketRepository
    {
        void Add(int id, Basket basket);
        public Task<Basket?> GetAsync(int basketId, CancellationToken cancellationToken);
    }
}


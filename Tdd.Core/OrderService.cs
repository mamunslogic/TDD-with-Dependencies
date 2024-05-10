using Tdd.Core.Exceptions;
using Tdd.Core.Models;
using Tdd.Core.Repositories;

namespace Tdd.Core
{
    public class OrderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IBasketRepository basketRepository, IOrderRepository orderRepository)
        {
            _basketRepository = basketRepository;
            _orderRepository = orderRepository;
        }

        public async Task CreateOrderAsync(int basketId, Address shippingAddress, CancellationToken cancellationToken)
        {
            if (shippingAddress is null)
                throw new ArgumentNullException();

            var basket = await _basketRepository.GetAsync(basketId, cancellationToken);
            if (basket is null)
                throw new BasketNotFoundException();

            var order = new Order(basket.Id, basket.BuyerId, shippingAddress);
            await _orderRepository.AddAsync(order, cancellationToken);
        }

        public async Task<Order> GetOrderAsync(int basketId)
        {
            var order = await _orderRepository.GetAsync(basketId);
            if (order is null)
                throw new OrderNotFoundException();
            return order;
        }
    }
}

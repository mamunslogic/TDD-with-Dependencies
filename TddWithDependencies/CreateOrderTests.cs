using Tdd.Core;
using Tdd.Core.Models;
using Tdd.Core.Exceptions;
using FluentAssertions;
using Tdd.Core.Repositories;
using Tdd.Core.Test.Fakes;

namespace TddWithDependencies
{
    public class CreateOrderTests
    {
        [Fact]
        public async Task GivenAnIndvalidBasketId_ThenThrowBasketNotFoundException()
        {
            IBasketRepository basketRepository = new FakeBasketRepository();
            IOrderRepository orderRepository = new FakeOrderRepository();

            var service = new OrderService(basketRepository, orderRepository);

            System.Func<Task> action = () => service.CreateOrderAsync(10, ShippingAddress(), default(CancellationToken));
            await action.Should().ThrowAsync<BasketNotFoundException>();
        }

        private static Address ShippingAddress()
        => new(street: "11", city: "Dhaka", country: "Bangladesh", zipcode: "1216");

        [Fact]
        public async Task GivenNullShippingAddress_ThenThrowArgumentNullException()
        {
            IBasketRepository basketRepository = new FakeBasketRepository();
            IOrderRepository orderRepository = new FakeOrderRepository();

            var service = new OrderService(basketRepository, orderRepository);

            System.Func<Task> action = () => service.CreateOrderAsync(10, null, default(CancellationToken));
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task GivenValidBasket_ThenAddOrderToRepository()
        {
            const int basketId = 1;

            IBasketRepository basketRepository = new FakeBasketRepository();
            basketRepository.Add(basketId, new Basket { Id = basketId, BuyerId = 100 });

            IOrderRepository orderRepository = new FakeOrderRepository();
            var orderService = new OrderService(basketRepository, orderRepository);

            await orderService.CreateOrderAsync(basketId, ShippingAddress(), default(CancellationToken));

            orderRepository.GetAsync(basketId).Should().NotBeNull();
        }

        [Fact]
        public async Task GivenAnIndvalidBasketId_ThenThrowOrderNotFoundException()
        {
            IBasketRepository basketRepository = new FakeBasketRepository();
            IOrderRepository orderRepository = new FakeOrderRepository();

            var service = new OrderService(basketRepository, orderRepository);

            System.Func<Task> action = () => service.GetOrderAsync(10);
            await action.Should().ThrowAsync<OrderNotFoundException>();
        }

        [Fact]
        public async Task GivenAnValidBasketId_ThenGetOrderDetail()
        {
            const int basketId = 1;

            IBasketRepository basketRepository = new FakeBasketRepository();
            basketRepository.Add(basketId, new Basket { Id = basketId, BuyerId = 100 });

            IOrderRepository orderRepository = new FakeOrderRepository();
            var orderService = new OrderService(basketRepository, orderRepository);

            await orderService.CreateOrderAsync(basketId, ShippingAddress(), default(CancellationToken));

            orderRepository.GetAsync(basketId).Should().NotBeNull();
        }
    }
}
namespace Tdd.Core.Models
{
    public class Order
    {
        public Order(int basketId, int buyerId, Address shippingAddress)
        {
            BasketId = basketId;
            BuyerId = buyerId;
            ShippingAddress = shippingAddress;
        }

        public int BasketId { get; set; }
        public int BuyerId { get; set; }
        public Address ShippingAddress { get; set; }
    }
}


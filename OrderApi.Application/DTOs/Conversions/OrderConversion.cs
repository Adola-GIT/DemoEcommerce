using OrderApi.Domain.Entities;

namespace OrderApi.Application.DTOs.Conversions
{
    public static class OrderConversion
    {
        public static Order ToEntity(OrderDTO order) => new Order()
        {
            Id = order.Id,
            ClientId = order.ClientId,
            ProductId = order.ProductId,
            OrderedDate = order.OrderedDate,
            PurchesQuantity = order.PurchesQuantity
        };


        public static (OrderDTO?, IEnumerable<OrderDTO>?) FromEntity(Order? order, IEnumerable<Order>? orders)
        {
            // return single
            if(order is not null || order is null)
            {
                var singleOrder = new OrderDTO(
                    order!.Id, 
                    order.ClientId, order.ProductId,
                    order.PurchesQuantity, 
                    order.OrderedDate);

                return (singleOrder, null);
            }

            // return list
            if(orders is not null || order is null)
            {
                var _orders = orders!.Select(o =>
                new OrderDTO(
                    o.Id,
                    o.ClientId,
                    o.ProductId,
                    o.PurchesQuantity,
                    o.OrderedDate));

                return (null, _orders);
            }

            return (null, null);
        }
    }
}

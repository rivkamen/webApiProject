using DTOs;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repositories

{
    
    public class OrderRepository : IOrderRepository
    {
        private MyStore_325950947Context _picturesStoreContext;
        public OrderRepository(MyStore_325950947Context picturesStoreContext)
        {
            _picturesStoreContext = picturesStoreContext;
        }

        //public async Task<Order> addOrder(Order order)
        //{
        //    await _picturesStoreContext.Orders.AddAsync(order);
        //    await _picturesStoreContext.SaveChangesAsync();
        //    return order;
        //}
        public async Task<Order> addOrder(Order order)
        {
            try
            {
                await _picturesStoreContext.Orders.AddAsync(order);
                await _picturesStoreContext.SaveChangesAsync();
                return order;
            }
            catch (Exception err)
            {
                return null;
            }
        }

        

        public Task<Order> getAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<Order> getOrderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}


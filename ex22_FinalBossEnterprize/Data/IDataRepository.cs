// --- Data/IDataRepository.cs ---
// Repository interface for accessing and manipulating store data.

using System.Collections.Generic;
using System.Threading.Tasks;
using FinalBossEnterprize.Models;

namespace FinalBossEnterprize.Data
{
    public interface IDataRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<List<Order>> GetOrdersAsync();
        Task AddOrderAsync(Order order);
        Task<Order> CreateOrderAsync(int[] productIds);
    }
}

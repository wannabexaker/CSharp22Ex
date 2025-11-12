// --- Data/DataRepository.cs ---
// In-memory data repository implementing IDataRepository.
// In a real app, this would talk to a database. Here it talks to your patience.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalBossEnterprize.Models;

namespace FinalBossEnterprize.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly List<Product> _products;
        private readonly List<Order> _orders;
        private readonly Random _rng = new();

        public DataRepository()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Mechanical Keyboard", Price = 89.99, InStock = true },
                new Product { Id = 2, Name = "Wireless Mouse", Price = 49.99, InStock = true },
                new Product { Id = 3, Name = "27\" Monitor", Price = 229.00, InStock = false },
                new Product { Id = 4, Name = "C# Mug", Price = 15.00, InStock = true }
            };

            _orders = new List<Order>();
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return Task.FromResult(_products.ToList());
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            return Task.FromResult(_orders.ToList());
        }

        public Task AddOrderAsync(Order order)
        {
            _orders.Add(order);
            return Task.CompletedTask;
        }

        public async Task<Order> CreateOrderAsync(int[] productIds)
        {
            var products = await GetProductsAsync();

            var items = products
                .Where(p => productIds.Contains(p.Id) && p.InStock)
                .ToList();

            var order = new Order
            {
                Id = _rng.Next(1000, 9999)
            };

            foreach (var item in items)
                order.Items.Add(item);

            await AddOrderAsync(order);
            return order;
        }
    }
}

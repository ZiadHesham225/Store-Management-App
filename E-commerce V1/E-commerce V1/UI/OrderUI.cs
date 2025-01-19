using E_commerce_V1.Context;
using E_commerce_V1.Models.Entities;
using E_commerce_V1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_V1.UI
{
    public static class OrderUI
    {
        private static ECommerceContext _context = new ECommerceContext();
        private static ProductRepository productRepo = new ProductRepository(_context);
        private static OrderRepository orderRepo = new OrderRepository(_context);
        private static OrderDetailsRepository orderDetailsRepo = new OrderDetailsRepository(_context);
        private static CustomerRepository customerRepo = new CustomerRepository(_context);
        public static void PlaceOrder()
        {
            Console.Write("Enter Customer ID: ");
            var customerId = int.Parse(Console.ReadLine());

            var customer = customerRepo.GetById(customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Select products to add to the order:");
            var products = productRepo.GetAll().ToList();
            var order = new Order { CustomerId = customerId, OrderDate = DateTime.Now};
            bool added = false;
            foreach (var product in products)
            {
                Console.Write($"Add {product.Name} (Price: {product.Price})? Enter quantity or 0 to skip: ");
                var quantity = int.Parse(Console.ReadLine());
                if (quantity > 0)
                {
                    if (!added)
                    {
                        orderRepo.Add(order);
                        added = true;
                    }
                    orderDetailsRepo.Add(new OrderDetails
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Quantity = quantity,
                        TotalPrice = product.Price * quantity
                    });
                    product.Stock -= quantity;
                }
            }

            Console.WriteLine("Order placed successfully. Press any key to continue.");
            Console.ReadKey();
        }

        public static void ViewOrderHistory()
        {
            

            Console.Write("Enter Customer ID: ");
            var customerId = int.Parse(Console.ReadLine());
            var orders = orderRepo.GetAll().Where(o => o.CustomerId == customerId).ToList();

            if (!orders.Any())
            {
                Console.WriteLine("No orders found for this customer.");
            }
            else
            {
                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.Id}, Date: {order.OrderDate}");
                    foreach (var detail in order.OrderDetails)
                    {
                        var product = productRepo.GetById(detail.ProductId);
                        Console.WriteLine($"  - Product: {product.Name}, Quantity: {detail.Quantity}, TotalPrice: {detail.TotalPrice}");
                    }
                }
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

    }

}

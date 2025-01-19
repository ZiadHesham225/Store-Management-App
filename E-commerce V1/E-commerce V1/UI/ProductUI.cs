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
    public static class ProductUI
    {
        private static ProductRepository productRepo = new ProductRepository(new ECommerceContext());

        public static void ManageProducts()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Product Management:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. List All Products");
                Console.WriteLine("0. Back");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        UpdateProduct();
                        break;
                    case "3":
                        ListProducts();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void AddProduct()
        {
            Console.Write("Enter Product Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Price: ");
            var price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Stock Quantity: ");
            var stock = int.Parse(Console.ReadLine());
            Console.Write("Enter Category: ");
            var category = int.Parse(Console.ReadLine());

            var product = new Product { Name = name, Price = price, Stock = stock, CategoryId = category };
            productRepo.Add(product);
            Console.WriteLine("Product added successfully. Press any key to continue.");
            Console.ReadKey();
        }

        private static void UpdateProduct()
        {
            ListProducts();
            Console.Write("Enter Product ID to update: ");
            var id = int.Parse(Console.ReadLine());
            var product = productRepo.GetById(id);

            if (product != null)
            {
                Console.Write("Enter New Name (leave empty to keep current): ");
                var name = Console.ReadLine();
                Console.Write("Enter New Price (leave empty to keep current): ");
                var priceInput = Console.ReadLine();
                Console.Write("Enter New Stock Quantity (leave empty to keep current): ");
                var stockInput = Console.ReadLine();

                product.Name = !string.IsNullOrWhiteSpace(name) ? name : product.Name;
                product.Price = !string.IsNullOrWhiteSpace(priceInput) ? decimal.Parse(priceInput) : product.Price;
                product.Stock = !string.IsNullOrWhiteSpace(stockInput) ? int.Parse(stockInput) : product.Stock;

                productRepo.Update(product);
                Console.WriteLine("Product updated successfully. Press any key to continue.");
            }
            else
            {
                Console.WriteLine("Product not found. Press any key to continue.");
            }
            Console.ReadKey();
        }

        private static void ListProducts()
        {
            var products = productRepo.GetAll();
            Console.WriteLine("Products:");
            foreach (var product in products)
            {
                var categoryName = product.Category?.Name ?? "No Category";
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}, Category: {categoryName}");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

    }
}

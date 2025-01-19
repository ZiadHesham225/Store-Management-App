using E_commerce_V1.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_V1.UI
{
    public static class MainMenu
    {
        public static void MainUI()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the E-Commerce Console App!");
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Category Management");
                Console.WriteLine("3. Place Order");
                Console.WriteLine("4. View Order History");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ProductUI.ManageProducts();
                        break;
                    case "2":
                        CategoryUI.ManageCategories();
                        break;
                    case "3":
                        OrderUI.PlaceOrder();
                        break;
                    case "4":
                        OrderUI.ViewOrderHistory();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

    }
}

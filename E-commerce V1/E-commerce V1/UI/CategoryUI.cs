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
    public static class CategoryUI
    {
        public static void ManageCategories()
        {
            using var context = new ECommerceContext();
            var categoryRepo = new CategoryRepository(context);

            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Category Management:");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. Update Category");
                Console.WriteLine("3. List All Categories");
                Console.WriteLine("0. Back");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCategory(categoryRepo);
                        break;
                    case "2":
                        UpdateCategory(categoryRepo);
                        break;
                    case "3":
                        ListCategories(categoryRepo);
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

        private static void AddCategory(CategoryRepository categoryRepo)
        {
            Console.Write("Enter Category Name: ");
            var name = Console.ReadLine();

            var category = new Category { Name = name };
            categoryRepo.Add(category);
            Console.WriteLine("Category added successfully. Press any key to continue.");
            Console.ReadKey();
        }

        private static void UpdateCategory(CategoryRepository categoryRepo)
        {
            ListCategories(categoryRepo);
            Console.Write("Enter Category ID to update: ");
            var id = int.Parse(Console.ReadLine());

            var category = categoryRepo.GetById(id);
            if (category != null)
            {
                Console.Write("Enter New Name (leave empty to keep current): ");
                var name = Console.ReadLine();

                category.Name = !string.IsNullOrWhiteSpace(name) ? name : category.Name;
                categoryRepo.Update(category);
                Console.WriteLine("Category updated successfully. Press any key to continue.");
            }
            else
            {
                Console.WriteLine("Category not found. Press any key to continue.");
            }
            Console.ReadKey();
        }

        private static void ListCategories(CategoryRepository categoryRepo)
        {
            var categories = categoryRepo.GetAll().ToList();
            Console.WriteLine("Categories:");
            foreach (var category in categories)
            {
                Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}

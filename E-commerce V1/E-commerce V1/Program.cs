using E_commerce_V1.Context;
using E_commerce_V1.Models.Entities;
using E_commerce_V1.Repositories;
using E_commerce_V1.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_commerce_V1;

class Program
{
    static void Main(string[] args)
    {
        MainMenu.MainUI();
    }
}
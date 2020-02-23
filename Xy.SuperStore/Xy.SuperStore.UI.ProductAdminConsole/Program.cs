using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.SuperStore.Data.Entities;
using Xy.SuperStore.Services;

namespace Xy.SuperStore.UI.ProductAdminConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            string command = "";
            do
            {
                Console.WriteLine("============ Product Admin =============");
                Console.WriteLine("Please type your command:");
                Console.WriteLine("AddUpdate product id name price quantity");
                Console.WriteLine("Add product quantity id quantity");
                Console.WriteLine("Remove product id quantity");
                Console.WriteLine("Find product id");
                Console.WriteLine("List all products");
                Console.WriteLine("quit");
                Console.WriteLine("-----------------------------------------");

                command = Console.ReadLine().ToLowerInvariant();
                var commandSplit = command.Split(' ');
                if (command.StartsWith("addupdate product"))
                {
                    try
                    {
                        var id = int.Parse(commandSplit[2]);
                        var name = commandSplit[3];
                        var price = decimal.Parse(commandSplit[4]);
                        var quantity = int.Parse(commandSplit[5]);
                        var product = productService.AddProduct(id, name, price, quantity);
                        Console.WriteLine("Add/Update product successfully!");
                        Console.WriteLine(product);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    continue;
                }

                if (command.StartsWith("add product"))
                {
                    try
                    {
                        var id = int.Parse(commandSplit[2]);
                        var quantity = int.Parse(commandSplit[3]);
                        var product = productService.AddProduct(id, quantity);
                        Console.WriteLine("Add product successfully!");
                        Console.WriteLine(product);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    continue;
                }

                if (command.StartsWith("remove product"))
                {
                    try
                    {
                        var id = int.Parse(commandSplit[2]);
                        var quantity = int.Parse(commandSplit[3]);
                        var product = productService.RemoveProduct(id, quantity);
                        if (product == null)
                        {
                            Console.WriteLine("This product stock is 0;");
                        }
                        else
                        {
                            Console.WriteLine("This product balance in stock:");
                            Console.WriteLine(product);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    continue;
                }

                if (command.StartsWith("find product"))
                {
                    var id = int.Parse(commandSplit[2]);
                    var product = productService.GetPRoductById(id);
                    if (product == null)
                    {
                        Console.WriteLine($"Product id={id} does not exist");
                    }
                    else
                    {
                        Console.WriteLine("Found this product:");
                        Console.WriteLine(product);
                    }
                    continue;
                }

                if (command.StartsWith("list all product"))
                {
                    Console.WriteLine( productService.ListAllProducts());
                    continue;
                }

            } while (command!="quit");
        }
    }
}

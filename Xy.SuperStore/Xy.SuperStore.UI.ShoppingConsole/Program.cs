using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.SuperStore.Data.Entities;
using Xy.SuperStore.Services;

namespace Xy.SuperStore.UI.ShoppingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            ShoppingService shoppingService = new ShoppingService();
            ShoppingCart shoppingCart = new ShoppingCart();

            string command = "";
            do
            {
                Console.WriteLine("============ Product Admin =============");
                Console.WriteLine("Please type your command:");
                Console.WriteLine("Add to cart id quantity");
                Console.WriteLine("Remove from cart id quantity");
                Console.WriteLine("Check shoppingCart");
                Console.WriteLine("Checkout");
                Console.WriteLine("Find product id");
                Console.WriteLine("List all products");
                Console.WriteLine("quit");
                Console.WriteLine("-----------------------------------------");

                command = Console.ReadLine().ToLowerInvariant();
                var commandSplit = command.Split(' ');
 
                if (command.StartsWith("add to cart"))
                {
                    try
                    {
                        var id = int.Parse(commandSplit[3]);
                        var quantity = int.Parse(commandSplit[4]);
                        var shoppingItem= shoppingService.AddShoppingItem(shoppingCart,id, quantity);
                        Console.WriteLine(shoppingItem);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    continue;
                }

                if (command.StartsWith("remove from cart"))
                {
                    try
                    {
                        var id = int.Parse(commandSplit[3]);
                        var quantity = int.Parse(commandSplit[4]);
                        var shoppingItem = shoppingService.RemoveFromCart(shoppingCart,id, quantity);
                        if (shoppingItem != null)
                        {
                            Console.WriteLine(shoppingItem);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    continue;
                }

                if (command.StartsWith("check shoppingcart"))
                {
                    Console.WriteLine(shoppingService.CheckShoppingCart(shoppingCart));
                    continue;
                }

                if (command.StartsWith("checkout"))
                {
                    Receipt receipt = shoppingService.Checkout(shoppingCart);
                    shoppingService.SaveReceipt(receipt);
                    Console.WriteLine(receipt.ToString());
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
                    Console.WriteLine(productService.ListAllProducts());
                    continue;
                }

            } while (command != "quit");
        }
    }
    
}

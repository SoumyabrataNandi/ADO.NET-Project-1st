using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoumyaKart
{
    public class Programshopping
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Clear();

                USERDETAILS us = new USERDETAILS();
                System.Console.WriteLine("Please Enter User Id:-");
                string UName = Console.ReadLine();
                System.Console.WriteLine("Please Enter Password:-");
                string Password = "";

                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Enter)
                    {
                        Password += key.KeyChar;
                        Console.Write("*");
                    }
                }
                while (key.Key != ConsoleKey.Enter);

                if (us.IsValidUser(UName, Password))
                {
                    Console.Clear();

                    System.Console.WriteLine("****************  WelCome Back User  ***************");

                    while (true)
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine("      -:Main Manu:-       ");
                        System.Console.WriteLine("---------------------------");
                        System.Console.WriteLine();
                        System.Console.WriteLine("Press 1 To View Cart..");
                        System.Console.WriteLine("Press 2 To View Orders..");
                        System.Console.WriteLine("Press 3 To View Product..");
                        System.Console.WriteLine("Press 4 To Exit From Application..");
                        System.Console.WriteLine();
                        System.Console.WriteLine();
                        System.Console.WriteLine("Enter Your Input:----------");

                        int ch = Convert.ToInt32(System.Console.ReadLine());

                        switch (ch)
                        {
                            case 1:
                                viewcartmanu(UName);
                                break;

                            case 2:
                                viewordermanu(UName);
                                break;

                            case 3:
                                viewproductmanu(UName);
                                break;

                            case 4:
                                System.Console.WriteLine();
                                Console.WriteLine("...Thank You For Visite Our App, Have a Good Day Meet You Soon...");
                                System.Console.WriteLine();
                                return;

                            default:
                                System.Console.WriteLine("Please Enter Valid Manu Option And Try Again ..........");
                                break;
                        }
                    }
                }
                else if (us.AdminCheckLogin(UName, Password))
                {
                    Console.Clear();

                    ProductRepo pr = new ProductRepo();

                    System.Console.WriteLine("****************  WelCome Admin  ***************");

                    while (true)
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine("      -:Main Manu:-       ");
                        System.Console.WriteLine("---------------------------");
                        System.Console.WriteLine();
                        System.Console.WriteLine("Press 1 To Add Product..");
                        System.Console.WriteLine("Press 2 To Update Product..");
                        System.Console.WriteLine("Press 3 To Remove Product..");
                        System.Console.WriteLine("Press 4 To Exit From Application..");
                        System.Console.WriteLine();
                        System.Console.WriteLine();
                        System.Console.WriteLine("Enter Your Input:----------");

                        int ch = Convert.ToInt32(System.Console.ReadLine());

                        switch (ch)
                        {
                            case 1:
                                System.Console.WriteLine("Enter Product Name:-");
                                string PN = Console.ReadLine();
                                System.Console.WriteLine("Enter Product Category:-");
                                string pc = Console.ReadLine();
                                System.Console.WriteLine("Enter Product Price:-");
                                int price = int.Parse(Console.ReadLine());
                                System.Console.WriteLine("Enter Product Quantity:-");
                                int qnt = int.Parse(Console.ReadLine());
                                pr.AddProduct(PN, pc, price, qnt);

                                break;

                            case 2:
                                System.Console.WriteLine("Enter Product Id You WantTo Update:-");
                                int Pi = int.Parse(Console.ReadLine());
                                System.Console.WriteLine("Enter Product Price:-");
                                int price2 = int.Parse(Console.ReadLine());
                                System.Console.WriteLine("Enter Product Quantity:-");
                                int qnt2 = int.Parse(Console.ReadLine());

                                pr.UpdateProduct(Pi, price2, qnt2);
                                break;

                            case 3:
                                System.Console.WriteLine("Enter Product Id You Want To Delete:-");
                                int pi = int.Parse(Console.ReadLine());
                                pr.RemoveProduct(pi);
                                break;

                            case 4:
                                System.Console.WriteLine();
                                Console.WriteLine("...Thank You Admin, Have a Good Day Meet You Soon...");
                                System.Console.WriteLine();
                                return;

                            default:
                                System.Console.WriteLine("Please Enter Valid Manu Option And Try Again ..........");
                                break;
                        }
                    }
                }

                else
                {
                    Console.Clear();

                    us.NewUser(UName, Password);

                    System.Console.WriteLine("****************  WelCome New User  ***************");

                    while (true)
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine("      -:Main Manu:-       ");
                        System.Console.WriteLine("---------------------------");
                        System.Console.WriteLine();
                        System.Console.WriteLine("Press 1 To View Cart..");
                        System.Console.WriteLine("Press 2 To View Orders..");
                        System.Console.WriteLine("Press 3 To View Product..");
                        System.Console.WriteLine("Press 4 To Exit From Application..");
                        System.Console.WriteLine();
                        System.Console.WriteLine();
                        System.Console.WriteLine("Enter Your Input:----------");

                        int ch = Convert.ToInt32(System.Console.ReadLine());

                        switch (ch)
                        {
                            case 1:
                                viewcartmanu(UName);
                                break;

                            case 2:
                                viewordermanu(UName);
                                break;

                            case 3:
                                viewproductmanu(UName);
                                break;

                            case 4:
                                System.Console.WriteLine();
                                Console.WriteLine("...Thank You For Visite Our App, Have a Good Day Meet You Soon...");
                                System.Console.WriteLine();
                                return;

                            default:
                                System.Console.WriteLine("Please Enter Valid Manu Option And Try Again ..........");
                                break;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                System.Console.WriteLine("Error Come Because Of:-", ex.Message);
            }

            finally
            {
                feedback fb = new feedback();
                System.Console.WriteLine("Please Give Your FeedBack About Our Application");
                string input = Console.ReadLine();

                fb.Userfb(input);
            }

        }

        public static void viewcartmanu(string UName)
        {
            Console.Clear();

            CartRepo cr = new CartRepo();

            System.Console.WriteLine();
            System.Console.WriteLine("       -:Cart Manu:-       ");
            System.Console.WriteLine("---------------------------");
            System.Console.WriteLine();
            System.Console.WriteLine("Press 1 To Edit Cart Product..");
            System.Console.WriteLine("Press 2 To Remove Cart Product..");
            System.Console.WriteLine("Press 3 To Order Cart Product..");
            System.Console.WriteLine("Press 4 To Display Cart Product..");
            System.Console.WriteLine("Press 5 To Go Back....");
            System.Console.WriteLine();
            System.Console.WriteLine("Enter Your Input:----------");

            int ch = Convert.ToInt32(System.Console.ReadLine());

            switch (ch)
            {
                case 1:
                    System.Console.WriteLine("Enter ProductId:-");
                    int pro = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.WriteLine("Enter Quantity:- ");
                    int Qnt = Convert.ToInt32(System.Console.ReadLine());

                    cr.UpdateProductQuantity(pro, Qnt);
                    break;
                case 2:
                    System.Console.WriteLine("Enter ProductId:-");
                    int pid = Convert.ToInt32(System.Console.ReadLine());

                    cr.RemoveProductFromCart(pid);
                    break;

                case 3:
                    System.Console.WriteLine("Please Enter UserId:-");
                    string Uid = Console.ReadLine();

                    cr.ConfirmOrder(Uid);
                    break;

                case 4:

                    foreach (var it in cr.GetCartItems(UName))
                    {
                        System.Console.WriteLine("****************************************************************************");
                        System.Console.WriteLine($"Cart Id:- {it.CartId}, Product Id:- {it.ProductId}, Quantity:- {it.Quantity}");
                        System.Console.WriteLine("****************************************************************************");
                    }
                    break;

                case 5:
                    return;

                default:
                    System.Console.WriteLine("Please Enter Valid Manu Option And Try Again ..........");
                    break;
            }
        }

        public static void viewordermanu(string UName)
        {
            Console.Clear();
            OrderRepo or = new OrderRepo();

            foreach (var it in or.ViewOrdersByUserId(UName))
            {
                System.Console.WriteLine("****************************************************************************");
                System.Console.WriteLine($"Order Id:- {it.OrderId}, Cart Id:- {it.CartId}, Order Date:- {it.OrderDate}");
                System.Console.WriteLine("****************************************************************************");
            }

            System.Console.WriteLine();
            System.Console.WriteLine("---------------------------");
            System.Console.WriteLine();
            System.Console.WriteLine("Press 1 To Go Back....");
            System.Console.WriteLine();
            System.Console.WriteLine("Enter Your Input:----------");

            int ch = Convert.ToInt32(System.Console.ReadLine());

            switch (ch)
            {
                case 1:
                    return;

                default:
                    System.Console.WriteLine("Please Enter Valid Manu Option And Try Again ..........");
                    break;
            }
        }

        public static void viewproductmanu(string UName)
        {
            Console.Clear();
            ProductRepo pr = new ProductRepo();
            CartRepo cr = new CartRepo();

            foreach (var it in pr.GetAllProduct())
            {
                System.Console.WriteLine("****************************************************************************");
                System.Console.WriteLine($"ProductId:- {it.ProductId}");
                System.Console.WriteLine($"ProductName:- {it.ProductName}");
                System.Console.WriteLine($"Product Quantity:- {it.Quantity}");
                System.Console.WriteLine($"ProductCategory:- {it.ProductCategory}");
                System.Console.WriteLine("****************************************************************************");
            }

            System.Console.WriteLine();
            System.Console.WriteLine("      -:Product Manu:-       ");
            System.Console.WriteLine("---------------------------");
            System.Console.WriteLine();
            System.Console.WriteLine("Press 1 To Display Product By Category..");
            System.Console.WriteLine("Press 2 To Display Product By ProductId..");
            System.Console.WriteLine("Press 3 To Add To Cart Product..");
            System.Console.WriteLine("Press 4 To Go Back....");
            System.Console.WriteLine();
            System.Console.WriteLine("Enter Your Input:----------");

            int ch = Convert.ToInt32(System.Console.ReadLine());

            switch (ch)
            {
                case 1:
                    System.Console.WriteLine("Enter Product Category:-");
                    string cat = Console.ReadLine();

                    foreach (var it in pr.GetProductsByCategory(cat))
                    {
                        System.Console.WriteLine("****************************************************************************");
                        System.Console.WriteLine($"ProductId:- {it.ProductId}");
                        System.Console.WriteLine($"ProductName:- {it.ProductName}");
                        System.Console.WriteLine($"Product Quantity:- {it.Quantity}");
                        System.Console.WriteLine($"ProductCategory:- {it.ProductCategory}");
                        System.Console.WriteLine("****************************************************************************");
                    }
                    break;

                case 2:
                    System.Console.WriteLine("Enter ProductId To Get Product:- ");
                    int proid = Convert.ToInt32(System.Console.ReadLine());

                    var pro = pr.GetProductById(proid);
                    System.Console.WriteLine("****************************************************************************");
                    System.Console.WriteLine($"Product Id = {pro.ProductId}");
                    System.Console.WriteLine($"Product Name = {pro.ProductName}");
                    System.Console.WriteLine($"Product Category = {pro.ProductCategory}");
                    System.Console.WriteLine($"Product Quantity = {pro.Quantity}");
                    System.Console.WriteLine("****************************************************************************");
                    break;

                case 3:
                    System.Console.WriteLine("Enter ProductId:-");
                    int Pro = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.WriteLine("Enter Quantity:- ");
                    int qnt = Convert.ToInt32(System.Console.ReadLine());

                    cr.AddToCart(Pro, qnt, UName);
                    break;

                case 4:
                    return;

                default:
                    System.Console.WriteLine("Please Enter Valid Manu Option And Try Again ..........");
                    break;
            }
        }
    }
}

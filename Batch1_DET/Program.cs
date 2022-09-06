// See https://aka.ms/new-console-template for more information
using Batch1_DET.Data;
using Batch1_DET.Models;
using System;

using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace Batch1_DET
{
    public class CodeFirstApproach
    {
        static void Main(string[] args)
        {
            //AddNewBook();
            //   deleteNewBook();
            // updateNewBook();
            //GetBook();
            //Console.ReadLine();
           // AddNewCustomerAndOrder();
            //GetAllCustomersWithOrder_EagerLoading();
           // GetAllCustomersWithOrder_ExplicitLoading();
            
           
        }
        private static void AddNewCustomerAndOrder()
        {
            var ctx = new BookContext();

            Customer customer = new Customer();
            customer.ID = 2;
            customer.Name = "john";
            customer.Age = 45;

            Order ord = new Order();
            ord.Order_ID = 101;
            ord.Amount = 2000;
            ord.OrderDate = DateTime.Now;
        
        ord.cust =customer;
            try
            {
            ctx.Orders.Add(ord);
            ctx.SaveChanges();
            Console.WriteLine("customer and order is created");
            }
     catch (Exception ex)
       {
           Console.WriteLine(ex.InnerException.Message);

      }
    }

        private static void GetAllCustomersWithOrder_EagerLoading()
        {
            //Eager loading means that the related data is loaded 
            //from the database as part of the initial query.
            var ctx = new BookContext();
            try
            {
                var customers = ctx.Customers.Include("Orders");

                //var customers = ctx.Customers.Include(o => o.Orders);                   

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.Name);
                    Console.WriteLine("----->");


                    foreach (var order in customer.Orders)
                    {
                        Console.WriteLine(order.Amount.ToString() + " " + order.Order_ID);
                    }
                    Console.WriteLine("-----");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void GetAllCustomersWithOrder_ExplicitLoading()
        {
            //Explicit loading means that the related data is
            //explicitly loaded from the database at a later time.
            //Needs MARS to be set to TRUE in connection string
            var ctx = new BookContext();
            try
            {
                var customers = ctx.Customers;



                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.Name);
                    Console.WriteLine("----->");



                    ctx.Entry(customer).Collection(o => o.Orders).Load();

                    foreach (var order in customer.Orders)
                    {
                        Console.WriteLine(order.Amount.ToString() + "  " + order.OrderDate.ToString());



                    }
                    Console.WriteLine("-----");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        private static void AddNewOrder()
        {
            var ctx = new BookContext();

            Customer customer = new Customer();
            customer.ID = 2;
            customer.Name = "john";
            customer.Age = 45;

            Order ord = new Order();
            ord.Order_ID = 101;
            ord.Amount = 2000;
            ord.OrderDate = DateTime.Now;
           
          

            ord.cust = customer;
            try
            {
                ctx.Orders.Add(ord);
                ctx.SaveChanges();
                Console.WriteLine("customer and order is created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);

            }
        }
        //private static void AddNewBook()
        //{
        //    var ctx = new BookContext();
        //    Book book = new Book();
        //    book.BookID = 3;
        //    book.BookName = "Statistics";
        //    book.author = "Tom";
        //    book.price = 180;
        //    try
        //    {
        //        ctx.Books.Add(book);
        //        ctx.SaveChanges();
        //        Console.WriteLine("new book added");

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.InnerException.Message);

        //    }
        //}
        //private static void deleteNewBook()
        //{
        //    var ctx = new BookContext();
        //    var Books = ctx.Books.Where(b => b.BookID == 3).SingleOrDefault();




        //    try
        //    {
        //        ctx.Books.Remove(Books);
        //        ctx.SaveChanges();
        //        Console.WriteLine("book removed");

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.InnerException.Message);

        //    }
        //}
        //private static void updateNewBook()
        //{
        //    var ctx = new BookContext();
        //    Book book = new Book();
        //    book.BookID = 1;
        //    book.BookName = "Software";
        //    book.author = "Sabhyata";
        //    book.price = 150;
        //    try
        //    {
        //        ctx.Books.Update(book);
        //        ctx.SaveChanges();
        //        Console.WriteLine("book update");

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.InnerException.Message);

        //    }
        //}
        //private static void GetBook()

        //{

        //    var value = new BookContext();

        //    var book = value.Books;

        //    foreach (var b in book)

        //    {

        //        Console.WriteLine(b.author);

        //    }

        //}



    }
}


using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            //Test2();
            //Test3();
            //Test4();


        }

        private static void Test4()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            if (productManager.GetAll().Success)
            {
                foreach (var item in productManager.GetAll().Data)
                {
                    Console.WriteLine(item.ProductName);
                }
                Console.WriteLine(productManager.GetAll().Message);
            }
            else
            {
                Console.WriteLine(productManager.GetAll().Message);
            }
        }

        private static void Test3()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var item in productManager.GetProductDetails().Data)
            {
                Console.WriteLine("{0}   {1}   {2}   {3}", item.ProductId, item.ProductName, item.CategoryName, item.UnitsInStock);
            }
        }

        private static void Test2()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var item in categoryManager.GetAll())
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void Test1()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var item in productManager.GetAllByCategoryId(2).Data)
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}

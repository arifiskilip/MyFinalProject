using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InProductDal : IProductDal
    {
        List<Product> _products; // global değişken
        public InProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Glass",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=2,ProductName="Computer",UnitPrice=1000,UnitsInStock=20},
                new Product{ProductId=3,CategoryId=2,ProductName="Camera",UnitPrice=500,UnitsInStock=10},
                new Product{ProductId=4,CategoryId=2,ProductName="Keyboard",UnitPrice=100,UnitsInStock=12},
                new Product{ProductId=5,CategoryId=1,ProductName="Chair",UnitPrice=200,UnitsInStock=20}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
            Console.WriteLine("Product added.");
        }

        public void Delete(Product product)
        {
            Product productToDelete;
            productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
            Console.WriteLine("Product deleted.");
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {

           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate;
            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            Console.WriteLine("Product updated.");
        }
        public void test()
        {
            var result = from p in _products
                         where p.UnitPrice >= 200
                         orderby p.UnitPrice ,
                          p.ProductName
                         select p;
            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}

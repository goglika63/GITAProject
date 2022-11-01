using DataAccessLayer;
using System;
using System.Linq;

namespace BusinessLogicLayer
{
    public class ProductServices
    {
        DataContext context = new DataContext();

        public void GetAllProducts()
        {
            foreach (var item in context.Products.Where(p => p.ProductId > 0))
            {
                Console.WriteLine($"{item.ProductId}, {item.Name}");
            }
        }

        public void InsertProduct(Product p)
        {
            var name = context.Products.Where(n => n.Name == p.Name).FirstOrDefault();
            if (name != null)
            {
                Console.WriteLine("Name already exists");
            }
            if (p.StandardCost > p.UnitPrice)
            {
                Console.WriteLine("Unit price is less than standard cost");
            }
            else
            {
                context.Products.Add(p);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(int Id, Product product)
        {
            var updated = context.Products.FirstOrDefault(a => a.ProductId == Id);
            if (updated != null)
            {
                updated.Name = product.Name;
                updated.ProductNumber = product.ProductNumber;
                updated.Color = product.Color;
                updated.StandardCost = product.StandardCost;
                updated.UnitPrice = product.UnitPrice;
                updated.Size = product.Size;
                updated.Weight = product.Weight;
                updated.ProductCategoryId = product.ProductCategoryId;
                updated.SellStartDate = DateTime.Now;
                updated.SellEndDate = DateTime.Now;
                updated.DiscontinuedDate = DateTime.Now;
                updated.PhotoFileName = product.PhotoFileName;
                updated.ModifiedDate = DateTime.Now;

                context.SaveChanges();
            }
        }

        public void DeleteProduct(int Id)
        {
            OrderDetail od = new OrderDetail();
            if (od.ProductId == Id)
            {
                Console.WriteLine("Product can not be deleted");
            }
            else
            {
                var deleted = context.Products.First(a => a.ProductId == Id);
                context.Products.Remove(deleted);
                context.SaveChanges();
            }
        }

        public void GetAllCategory()
        {
            foreach (var item in context.Categories.Where(c => c.CategoryId > 0))
            {
                Console.WriteLine($"{item.CategoryId}, {item.Name}");
            }
        }

        public void InsertCategory(Category c)
        {
            var name = context.Categories.Where(n => n.Name == c.Name).FirstOrDefault();
            if (name != null)
            {
                Console.WriteLine("Category already exists");
            }
            else
            {
                context.Categories.Add(c);
                context.SaveChanges();
            }
        }

        public void UpdateCategory(int Id, Category category)
        {
            var updated = context.Categories.FirstOrDefault(n => n.CategoryId == Id);
            if (updated != null)
            {
                updated.ParentCategoryId = category.ParentCategoryId;
                updated.Name = category.Name;
                updated.ModifiedDate = DateTime.Now;

                context.SaveChanges();
            }
        }

        public void DeleteCategory(int Id)
        {
            var categoryId = context.Products.FirstOrDefault(c => c.ProductCategoryId == Id);
            if (categoryId != null)
            {
                Console.WriteLine("cant delete category");
            }
            else
            {
                var deleted = context.Categories.First(a => a.CategoryId == Id);
                context.Categories.Remove(deleted);
                context.SaveChanges();
            }
        }
    }
}

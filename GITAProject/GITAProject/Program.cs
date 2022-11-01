using BusinessLogicLayer;
using DataAccessLayer;
using System;

namespace GITAProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductServices productServices = new ProductServices();
            CustomerServices customerServices = new CustomerServices();
            OrderServices orderServices = new OrderServices();
            Product product = new Product();
            Category category = new Category();
            Customer customer = new Customer();
            Address address = new Address();
            Order order = new Order();
            OrderDetail orderDetail = new OrderDetail();
        }
    }
}

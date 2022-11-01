using DataAccessLayer;
using System;
using System.Linq;

namespace BusinessLogicLayer
{
    public class CustomerServices
    {
        DataContext context = new DataContext();

        public void GetAllCustomers()
        {
            foreach (var item in context.Customers.Where(c => c.CustomerId > 0))
            {
                Console.WriteLine($"{item.CustomerId}, {item.LastName}");
            }
        }

        public void InsertCustomer(Customer customer)
        {
            var name = context.Customers.Where(c => c.NameStyle == customer.NameStyle).FirstOrDefault();
            if (name != null)
            {
                Console.WriteLine("Name already exists");
            }
            else
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void UpdateCustomer(int Id, Customer customer)
        {
            var updated = context.Customers.FirstOrDefault(c => c.CustomerId == Id);
            if (updated != null)
            {
                updated.NameStyle = customer.NameStyle;
                updated.Title = customer.Title;
                updated.FirstName = customer.FirstName;
                updated.MiddleName = customer.MiddleName;
                updated.LastName = customer.LastName;
                updated.Suffix = customer.Suffix;
                updated.CompanyName = customer.CompanyName;
                updated.SalesPerson = customer.SalesPerson;
                updated.EmailAddress = customer.EmailAddress;
                updated.Phone = customer.Phone;
                updated.PasswordHash = customer.PasswordHash;
                updated.ModifiedDate = DateTime.Now;

                context.SaveChanges();
            }
        }

        public void DeleteCustomer(int Id)
        {
            var deleted = context.Customers.First(c => c.CustomerId == Id);
            context.Customers.Remove(deleted);
            context.SaveChanges();
        }

        public void GetAllAddresses()
        {
            foreach (var item in context.Addresses.Where(a => a.AddressId > 0))
            {
                Console.WriteLine($"{item.AddressId}, {item.AddresLine1}");
            }
        }

        public void InsertAddress(Address address)
        {
            context.Addresses.Add(address);
            context.SaveChanges();
        }

        public void UpdateAddress(int Id, Address address)
        {
            var updated = context.Addresses.FirstOrDefault(a => a.AddressId == Id);
            if (updated != null)
            {
                updated.AddresLine1 = address.AddresLine1;
                updated.AddressLine2 = address.AddressLine2;
                updated.City = address.City;
                updated.StateProvince = address.StateProvince;
                updated.CountryRegion = address.CountryRegion;
                updated.PostalCode = address.PostalCode;
                updated.ModifiedDate = DateTime.Now;

                context.SaveChanges();
            }
        }

        public void DeleteAddress(int Id)
        {
            var deleted = context.Addresses.First(a => a.AddressId == Id);
            context.Addresses.Remove(deleted);
            context.SaveChanges();
        }
    }
}

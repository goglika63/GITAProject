using DataAccessLayer;
using System;
using System.Linq;

namespace BusinessLogicLayer
{
    public class OrderServices
    {
        DataContext context = new DataContext();

        public void GetAllOrders()
        {
            foreach (var item in context.Orders.Where(o => o.OrderId > 0))
            {
                Console.WriteLine($"{item.OrderId}, {item.ShipMethod}");
            }
        }

        public void InsertOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void UpdateOrder(int Id, Order order)
        {
            var updated = context.Orders.FirstOrDefault(o => o.OrderId == Id);
            if (updated != null)
            {
                updated.RevisionNumber = order.RevisionNumber;
                updated.OrderDate = DateTime.Now;
                updated.ShipDate = DateTime.Now;
                updated.Status = order.Status;
                updated.OrderNumber = order.OrderNumber;
                updated.OnlineNumberFlag = order.OnlineNumberFlag;
                updated.AccountNumber = order.AccountNumber;
                updated.CustomerId = order.CustomerId;
                updated.ShipToAddressId = order.ShipToAddressId;
                updated.BillToAddressId = order.BillToAddressId;
                updated.ShipMethod = order.ShipMethod;
                updated.CreditCardApprovalMethod = order.CreditCardApprovalMethod;
                updated.SubTotal = order.SubTotal;
                updated.TaxAmt = order.TaxAmt;
                updated.Freight = order.Freight;
                updated.TotalDue = order.TotalDue;
                updated.Comment = order.Comment;
                updated.ModifiedDate = DateTime.Now;

                context.SaveChanges();
            }
        }

        public void DeleteOrder(int Id)
        {
            OrderDetail od = new OrderDetail();
            var deleted = context.Orders.First(a => a.OrderId == Id);
            context.Orders.Remove(deleted);
            DeleteOrderDetail(Id);
            context.SaveChanges();
        }

        public void GetAllOrderDetails()
        {
            foreach (var item in context.OrderDetails.Where(o => o.OrderDeatilId > 0))
            {
                Console.WriteLine($"{item.ProductId}, {item.OrderQty}, {item.UnitPrice}");
            }
        }

        public void InsertOrderDetail(OrderDetail orderDetail)
        {

            if (orderDetail.OrderQty < 1)
            {
                Console.WriteLine("Order Qty can not be negative or zero");
            }
            else
            {
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            }
        }

        public void UpdateOrderDetail(int Id, OrderDetail orderDetail)
        {
            var updated = context.OrderDetails.FirstOrDefault(o => o.OrderDeatilId == Id);
            if (updated != null)
            {
                updated.OrderId = orderDetail.OrderId;
                updated.OrderQty = orderDetail.OrderQty;
                updated.Product = orderDetail.Product;
                updated.UnitPrice = orderDetail.UnitPrice;
                updated.UnitPriceDiscount = orderDetail.UnitPriceDiscount;
                updated.LineTotal = orderDetail.LineTotal;
                updated.LineTotal = orderDetail.LineTotal;
                updated.ModifiedDate = DateTime.Now;

                context.SaveChanges();
            }
        }

        public void DeleteOrderDetail(int Id)
        {
            var deleted = context.OrderDetails.First(o => o.OrderDeatilId == Id);
            context.OrderDetails.Remove(deleted);
            context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Models;

namespace WepApi.Data
{
    public interface IRepository
    {
        // Saves changes from database
        bool SaveChanges();

        //------------- Products -----------------
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);

        //------------- Customers -----------------
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer custommer);
        void DeleteCustomer(int id);

        //------------- Shippers -----------------
        IEnumerable<Shipper> GetAllShippers();
        Shipper GetShipperById(int id);
        void CreateShipper(Shipper shipper);
        void UpdateShipper(Shipper shipper);
        void DeleteShipper(int id);
        //------------- Orders -----------------
        IEnumerable<Orders> GetAllOrders();
        Orders GetOrderById(int id);
        void CreateOrder(Orders order);
        void UpdateOrder(Orders order);
        void DeleteOrder(int id);

        //------------- OrderStatuses -----------------
        IEnumerable<OrderStatus> GetAllOrderStatuses();
        OrderStatus GetOrderStatusById(int id);
        void CreateOrderStatus(OrderStatus orderStatus);
        void UpdateOrderStatus(OrderStatus orderStatus);
        void DeleteOrderStatus(int id);

        //------------- OrderItems -----------------
        IEnumerable<OrderItem> GetAllOrderItems();
        void CreateOrderItem(OrderItem orderItem);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Models;

namespace WepApi.Data
{
    public class SqlRepository : IRepository
    {
        private readonly DataBaseContext _context;

        /*
         dbcontext instance, from contructor depedency
         returns our item from databse
        */
        public SqlRepository(DataBaseContext context)
        {
            _context = context;
        }

        //------------- Products -----------------
        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Product.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Product.ToList();
        }
        public Product GetProductById(int id)
        {
            return _context.Product.FirstOrDefault(p => p.Id == id);
        }
        // update method does not do anything yet
        public void UpdateProduct(Product product) { }

        public void DeleteProduct(Product product)
        {
            
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            
            _context.Product.Remove(product);
        }

        //------------- Customers -----------------
        public void CreateCustomer(Customer customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            _context.Customer.Add(customer);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customer.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customer.FirstOrDefault(c => c.Id == id);
        }

        // update method does not do anything yet
        public void UpdateCustomer(Customer custommer){}

        public void DeleteCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            _context.Customer.Remove(customer);
        }

        //------------- Shippers -----------------
        public void CreateShipper(Shipper shipper)
        {
            if (shipper == null)
            {
                throw new ArgumentNullException(nameof(shipper));
            }
            _context.Shipper.Add(shipper);
        }
        public IEnumerable<Shipper> GetAllShippers()
        {
            return _context.Shipper.ToList();
        }

        public Shipper GetShipperById(int id)
        {
            return _context.Shipper.FirstOrDefault(s => s.Id == id);
        }

        // update method does not do anything yet
        public void UpdateShipper(Shipper shipper) { }

        public void DeleteShipper(Shipper shipper)
        {
            if (shipper == null)
            {
                throw new ArgumentNullException(nameof(shipper));
            }
            _context.Shipper.Remove(shipper);
        }

        //------------- Orders -----------------
        public void CreateOrder(Orders order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _context.Orders.Add(order);
        }
        public IEnumerable<Orders> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public Orders GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        // update method does not do anything yet
        public void UpdateOrder(Orders order) {}

        public void DeleteOrder(Orders order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _context.Orders.Remove(order);
        }

        //------------- OrderStatuses -----------------
        public void CreateOrderStatus(OrderStatus orderStatus)
        {
            if (orderStatus == null)
            {
                throw new ArgumentNullException(nameof(orderStatus));
            }
            _context.OrderStatus.Add(orderStatus);
        }
        public IEnumerable<OrderStatus> GetAllOrderStatuses()
        {
            return _context.OrderStatus.ToList();
        }
        public OrderStatus GetOrderStatusById(int id)
        {
            return _context.OrderStatus.FirstOrDefault(ot => ot.Id == id);
        }

        // update method does not do anything yet
        public void UpdateOrderStatus(OrderStatus orderStatus) { }

        public void DeleteOrderStatus(OrderStatus orderStatus)
        {
            if (orderStatus == null)
            {
                throw new ArgumentNullException(nameof(orderStatus));
            }
            _context.OrderStatus.Remove(orderStatus);
        }

        //------------- OrderItems -----------------
        public void CreateOrderItem(OrderItem orderItem)
        {
            if (orderItem == null)
            {
                throw new ArgumentNullException(nameof(orderItem));
            }
            _context.OrderItem.Add(orderItem);
        }
        public IEnumerable<OrderItem> GetAllOrderItems()
        {
            return _context.OrderItem.ToList();
        }


        // saving the changes to DaseBase
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        
    }
}

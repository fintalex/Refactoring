using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Замена значения ссылкой 
namespace ChangeValueToReference
{
	class Customer
	{
		public Customer(String name)
		{
			_name = name;
		}
		public String getName()
		{
			return _name;
		}
		private String _name;
	}
	class Order
	{
		public Order(String customerName)
		{
			_customer = new Customer(customerName);
		}
		public void setCustomer(String customerName)
		{
			_customer = new Customer(customerName);
		}
		public String getCustomerName()
		{
			return _customer.getName();
		}
		private Customer _customer;

		private static int numberOfOrdersFor(List<Order> orders, String customer)
		{
			int result = 0;
			foreach (var curCustomer in orders)
			{
				if (curCustomer.getCustomerName().Equals(customer))
				{
					result++;
				}
			}
			return result;
		}
	}
}

//Необходимо внести такие изменения, чтобы при наличии нескольких заказов для одного и
//того же клиента в них использовался один и тот же экземпляр класса Сustomer.


namespace ChangeValueToReference2
{
    class Customer
    {
        //Замены конструктора фабричным методом, который возвращает заранее созданного клиента
        public static Customer getNamed(String name)
        {
            if (_instances.ContainsKey(name))
            {
                return _instances[name];
            }
            return null;
        }
        // сделали конструктор закрытым
        private Customer(String name)
        {
            _name = name;
        }

        public String getName()
        {
            return _name;
        }
        private String _name;


        private static Dictionary<string, Customer> _instances = new Dictionary<string, Customer>();
        //private static Hashtable _instances= new Hashtable();
        static void loadCustomers()
        {
            new Customer("Lemon Car Hire").store();
            new Customer("Associated Coffe Machine").store();
            new Customer("Bilston Gasworks").store();
        }
        private void store()
        {
            _instances.Add(this.getName(), this);
        }
    }
    class Order
    {
        public Order(String customerName)
        {
            _customer = Customer.getNamed(customerName);
        }
        public void setCustomer(String customerName)
        {
            _customer = Customer.getNamed(customerName);
        }
        public String getCustomerName()
        {
            return _customer.getName();
        }
        private Customer _customer;

        private static int numberOfOrdersFor(List<Order> orders, String customer)
        {
            int result = 0;
            foreach (var curCustomer in orders)
            {
                if (curCustomer.getCustomerName().Equals(customer))
                {
                    result++;
                }
            }
            return result;
        }
    }
}
	
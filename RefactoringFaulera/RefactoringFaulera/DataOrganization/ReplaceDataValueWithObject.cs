using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Замена значения данных объектом 
namespace ReplaceDataValueWithObject
{
	class Order
	{
		public Order(string customer)
		{
			_customer = customer;
		}
		public String getCustomer()
		{
			return _customer;
		}
		public void setCustomer(string arg)
		{
			_customer = arg;
		}

		private String _customer;

		private static int numberOfOrdersFor(List<Order> orders, String customer)
		{
			int result = 0;
			foreach (var curCustomer in orders)
			{
				if (curCustomer.getCustomer().Equals(customer))
				{
					result++;
				}
			}
			return result;
		}
	}
}

namespace ReplaceDataValueWithObject2
{
	class Customer
	{
		public Customer(string name)
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
		public Order(string customerName)
		{
			_customer = new Customer(customerName);
		}
		public String getCustomerName()
		{
			return _customer.getName();
		}
		public void setCustomer(string customerName)
		{
			_customer = new Customer(customerName);
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

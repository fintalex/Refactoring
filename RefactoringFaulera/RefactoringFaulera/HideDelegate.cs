using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideDelegate
{
	// есть класс Person, который просто хранит инфу об отделе
	// можно получать отдел через метод getDepartment
	class Person
	{
		Department _department;

		public Department getDepartment()
		{
			return _department;
		}
	}

	// а есть класс Отдел. 
	// и у него есть внутреннее свойство _manager
	// которое мы можем получить через метод getManager
	class Department
	{
		private String _chargeCode;
		private Person _manager;

		public Department(Person manager)
		{
			_manager = manager;
		}

		public Person getManager()
		{
			return _manager;
		}
	}
}

// для получения менеджера у какого либо сотрудника нам нужно обращаться через Department
// manager = person.GetDepartment().getManager();
// - и это открывает характер работы класса Department для клиента


namespace HideDelegate2
{
	class Person
	{
		// решаем проблему путем создания делегирующего метода
		public Person gerManager()
		{
			return _department.getManager();
		}

		Department _department;

		public Department getDeparment()
		{
			return _department;
		}
	}

	class Department
	{
		private String _chargeCode;
		private Person _manager;

		public Department(Person manager)
		{
			_manager = manager;
		}

		public Person getManager()
		{
			return _manager;
		}
	}
}

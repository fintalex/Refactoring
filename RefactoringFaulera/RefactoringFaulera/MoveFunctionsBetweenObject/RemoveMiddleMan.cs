using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// обратная процедура hide Delegate
// иногда такая инкапсуляция излишняя, и применяется удаление посредника
namespace RemoveMiddleMan
{
	class Person
	{
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
// получаем менеджера через manager = john.getManager();

namespace RemoveMiddleMan2
{
	class Person
	{
		Department _department;

		public Department getDepartment()
		{
			return _department;
		}
	}
	class Department
	{
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
// а теперь получаем менеджера как : manager = john.getDepartment().getManager();

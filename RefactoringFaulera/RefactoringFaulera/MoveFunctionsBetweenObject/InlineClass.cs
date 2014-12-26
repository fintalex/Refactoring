using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// встраивание класс
//  необходимо если после рефактоинга осталось мало функций в классе
namespace InlineClass
{
	class Person
	{
		private String _name;
		//private String _officeAreaCode;
		//private String _officeNumber;

		private TelephoneNumber _officeTelephone = new TelephoneNumber();

		public String getName()
		{
			return _name;
		}
		public String getTelephoneNumber()
		{
			return _officeTelephone.getTelephoneNumber();
		}
	}

	class TelephoneNumber
	{
		private String _areaCode;
		private String _number;

		public String getAreaCode()
		{
			return _areaCode;
		}
		public void setAreaCode(String arg)
		{
			_areaCode = arg;
		}

		public String getNumber()
		{
			return _number;
		}
		public void setNumber(String arg)
		{
			_number = arg;
		}

		public String getTelephoneNumber()
		{
			return ("(" + _areaCode + ") " + _number);
		}

	}
}


// процедура с точность наоборот ExtractClass
namespace InlineClass2
{
	class Person
	{
		private String _name;
		private String _areaCode;
		private String _number;

		public String getName()
		{
			return _name;
		}
		public String getAreaCode()
		{
			return _areaCode;
		}
		public void setAreaCode(String arg)
		{
			_areaCode = arg;
		}

		public String getNumber()
		{
			return _number;
		}
		public void setNumber(String arg)
		{
			_number = arg;
		}
		public String getTelephoneNumber()
		{
			return ("(" + _areaCode + ") " + _number);
		}
	}
}
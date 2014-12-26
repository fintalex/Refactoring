using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// выделение класса
// можно выделить класс чьи фун-ции относящиеся к номеру телефона
namespace ExtractClass
{
	class Person
	{
		private String _name;
		private String _officeAreaCode;
		private String _officeNumber;

		public String getName()
		{
			return _name;
		}
		public String getTelephoneNumber()
		{
			return ("(" + _officeAreaCode + ") " + _officeNumber);
		}

		String getOfficeAreaCode()
		{
			return _officeAreaCode;
		}
		void setOfficeAreaCode(String arg)
		{
			_officeAreaCode = arg;
		}

		String getOfficeNumner()
		{
			return _officeNumber;
		}
		void setOfficeNumber(String arg)
		{
			_officeNumber = arg;
		}
	}
}

// сначала переносим первое поле officeAreaCode в новый класс TelephoneNumber
namespace ExtractClass2
{
	class Person
	{
		private String _name;
		//private String _officeAreaCode;
		private String _officeNumber;

		private TelephoneNumber _officeTelephone = new TelephoneNumber();

		public String getName()
		{
			return _name;
		}
		public String getTelephoneNumber()
		{
			return ("(" + getOfficeAreaCode() + ") " + _officeNumber);
		}

		String getOfficeAreaCode()
		{
			return _officeTelephone.getAreaCode();
		}
		void setOfficeAreaCode(String arg)
		{
			_officeTelephone.setAreaCode(arg);
		}

		String getOfficeNumner()
		{
			return _officeNumber;
		}
		void setOfficeNumber(String arg)
		{
			_officeNumber = arg;
		}
	}

	class TelephoneNumber
	{
		public String getAreaCode()
		{
			return _areaCode;
		}
		public void setAreaCode(String arg)
		{
			_areaCode = arg;
		}
		private String _areaCode;
	}
}

// а теперь можно перенести и другое поле officeNumber в новый класс TelephoneNumber
// а также перенесем метод TelephoneNumber
namespace ExtractClass3
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

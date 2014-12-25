using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// перемещение поля 
// необходимо если данное поле используется чаще в другом классе чем в своем
namespace MoveField
{
	class Account
	{
		private AccountType _type;
		private double _interestRate;

		double interestForAmount_days(double amount, int days) 
		{
			return _interestRate * amount * days / 365;
		}
	}

	class AccountType
	{ 
	}
}


// перемещаем поле _interestRate
namespace MoveField2
{
	class Account
	{
		private AccountType _type;
		//private double _interestRate;

		double interestForAmount_days(double amount, int days)
		{
			return _type.getInterestRate() * amount * days / 365;
		}
	}

	class AccountType
	{
		private double _interestRate;
		public void setInterestRate(double arg)
		{
			_interestRate = arg;
		}

		public double getInterestRate()
		{
			return _interestRate;
		}
	}
}


// пример с самоинкапсуляцией
namespace MoveField3
{
	class Account
	{
		private AccountType _type;
		private double _interestRate;

		double interestForAmount_days(double amount, int days)
		{
			return getInterestRate() * amount * days / 365;
		}

		private void setInterestRate(double arg)
		{
			_type.setInterestRate(arg);
		}
		private double getInterestRate()
		{
			return _type.getInterestRate();
		}
	}

	class AccountType
	{
		private double _interestRate;
		public void setInterestRate(double arg)
		{
			_interestRate = arg;
		}

		public double getInterestRate()
		{
			return _interestRate;
		}
	}
}
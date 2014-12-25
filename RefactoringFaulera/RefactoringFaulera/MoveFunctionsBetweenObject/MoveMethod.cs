using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// перемещение метода необходимо если классы сильно связаны
// пытаемся найти методы котоыре часто обращаются к другому классу
namespace MoveMethod
{
	class Account
	{
		double overdraftCharge()
		{
			if (_type.isPremium())
			{
				double result = 10;
				if (_daysOverdrawn > 7) result += (_daysOverdrawn - 7) * 0.85;
				return result;
			}
			else return _daysOverdrawn * 1.75;
		}

		double bankCharge()
		{
			double result = 4.5;
			if (_daysOverdrawn > 0) result += overdraftCharge();
			return result;
		}

		private AccountType _type;
		private int _daysOverdrawn;
	}
	class AccountType
	{
		public bool isPremium()
		{
			return true;
		}
	}
}


namespace MoveMethod2
{
	class Account
	{
		//double overdraftCharge()
		//{
		//	if (_type.isPremium())
		//	{
		//		double result = 10;
		//		if (_daysOverdrawn > 7) result += (_daysOverdrawn - 7) * 0.85;
		//		return result;
		//	}
		//	else return _daysOverdrawn * 1.75;
		//}

		double bankCharge()
		{
			double result = 4.5;
			if (_daysOverdrawn > 0) result += _type.overdraftCharge(_daysOverdrawn);
			return result;
		}

		private AccountType _type;
		private int _daysOverdrawn;
	}
	class AccountType
	{
		public bool isPremium()
		{
			return true;
		}

		public double overdraftCharge(int daysOverdrawn)
		{
			if (this.isPremium())
			{
				double result = 10;
				if (daysOverdrawn > 7) result += (daysOverdrawn - 7) * 0.85;
				return result;
			}
			else return daysOverdrawn * 1.75;
		}
	}
}
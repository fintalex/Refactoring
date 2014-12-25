using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ВНЕДРЕНИЕ внешнего метода
// если есть класс запрещенный для редактирования
// но нужно добавить еще один метод (метод расширания)
namespace IntroduceForeignMethod
{
	//например если есть код - нужно открывать период выставления счетов
	class IFM
	{
		public void someMethod()
		{
			DateTime previousEnd = new DateTime(2014, 11, 11);
			DateTime newStart = new DateTime(previousEnd.Year, previousEnd.Month, previousEnd.Day + 1);
		}
	}
}

namespace IntroduceForeignMethod2
{
	//например если есть код - нужно открывать период выставления счетов
	class IFM
	{
		public void someMethod()
		{
			DateTime previousEnd = new DateTime(2014, 11, 11);
			DateTime newStart = nextDay(previousEnd);
		}

		// чтобы дополнить к классу новый метод, создаем внешний статический метод
		// тоесть делаем новый метод и первым параметром передаем нужный класс
		private static DateTime nextDay(DateTime arg)
		{
			return new DateTime(arg.Year, arg.Month, arg.Day + 1);
		}
	}
}
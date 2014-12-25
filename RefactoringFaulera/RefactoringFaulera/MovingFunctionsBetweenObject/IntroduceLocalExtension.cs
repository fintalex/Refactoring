using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// внедрение локального расширения
// необходимо создать новый класс с необходимыми методами
// и сделать его подклассом или оболочкой для исходного

// тоетьс это будет означать что наш новый класс 
// может делать тоже самое + новые дополнительные функции

// зачем: если дополнительных методов набирается много -
// их лучше вынести в отдельный класс(подкласс)

// пример не очень хороший, наверное лучше было бы сделать
// все это методами расширения
namespace IntroduceLocalExtension
{
	class First 
	{
		public void Method()
		{
			MfDateSub mfds = new MfDateSub(new DateTime());
			
		}
		
	}


	// создание подкласса
	class MfDateSub : DateTime
	{
		public MfDateSub(String dateString)
		{
			
		}

		public MfDateSub(DateTime arg)
		{

		}

		private static DateTime nextDay(DateTime arg)
		{
			return new DateTime(arg.Year, arg.Month, arg.Day + 1);
		}
	}


	// создание оболочки
	class MfDateWrap
	{
		private DateTime _original;

		public MfDateWrap(String dateString)
		{
			_original = Convert.ToDateTime(dateString);
		}
		public MfDateWrap(DateTime arg)
		{
			_original = arg;
		}
	}
}

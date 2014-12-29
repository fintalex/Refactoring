using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfEncapsulateField
{
	class IntRange
	{
		private int _low, _high;

		bool includes(int arg)
		{
			return arg >= _low && arg <= _high;
		}
		void grow(int factor)
		{
			_high = _high * factor;
		}
		IntRange(int low, int high)
		{
			_low = low;
			_high = high;
		}

	}
}

namespace SelfEncapsulateField2
{
	class IntRange
	{
		bool includes(int arg)
		{
			return arg >= getLow() && arg <= getHigh();
		}
		void grow(int factor)
		{
			setHigh(getHigh() * factor);
		}
		
		private int _low, _high;
		int getLow()
		{
			return _low;
		}
		int getHigh() 
		{
			return _high;
		}
		void setLow(int arg)
		{
			_low = arg;
		}
		void setHigh(int arg)
		{
			_high = arg;
		}

	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCusomer
{
    // класс который представляет данные о фильме
    public class Movie
    {
        public const int CHILDREN = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        private String _title;
        private int _priceCode;

        public Movie (String title, int priceCode)
        { 
            _title = title;
            _priceCode = priceCode;
        }
        public int getPriceCode()
        {
            return _priceCode;
        }
        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }
        public  String getTitle()
        {
            return _title;
        }
    }

    // класс представляющий данные о прокате фильма
    class Rental
    {
        private Movie _movie;
        private int _daysRented;
        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }
        public int getDaysRented()
        {
            return _daysRented;
        }
        public Movie getMovie()
        {
            return _movie;
        }
    }

    // класс, представляющий клиента магазина
    class Customer
    {
        private string _name;
        private List<Rental> _rental = new List<Rental>();
        public Customer (String name)
        {
            _name = name;
        }
        public void addRental(Rental arg)
        {
            _rental.Add(arg);
        }
        public String getName()
        {
            return _name;
        }
        public string statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            List<Rental> rentals = new List<Rental> ();
            string result = "Учет аренды для " + getName() + "\n";
            foreach (Rental each in rentals)
            {
                double thisAmount = 0;
                // определить сумму для каждой строки
                switch (each.getMovie().getPriceCode())
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.getDaysRented()>2) 
                            thisAmount += (each.getDaysRented() - 2) *1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.getDaysRented()*3;
                        break;
                    case Movie.CHILDREN:
                        thisAmount += 1.5;
                        if (each.getDaysRented()>3)
                            thisAmount += (each.getDaysRented()-3)*1.5;
                        break;
                }
                 // добавить очки для активного арендатора
                frequentRenterPoints++;
                //бонус за аренду новинки на два дня
                if ((each.getMovie().getPriceCode() == Movie.NEW_RELEASE) && each.getDaysRented()>1)
                    frequentRenterPoints ++;
                // показать результаты для этой аренды
                result += "\t" + each.getMovie().getTitle() + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }

            // добавить нижний колонтитул 
            result += "Сумма задолженности составляет " + totalAmount.ToString() + "\n";
            result += "Вы заработали " + frequentRenterPoints.ToString() + " oчков за активность";
            return result;
        }
    }

}

namespace MovieRentalCusomer2
{
    // класс который представляет данные о фильме
    public class Movie
    {
        public const int CHILDREN = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        private String _title;
        //private int _priceCode;

		//заменяем поле кода цены полем цены и изменяем функцию доступа. (так сказать своеобразная фабрика получается)
		private Price _price;

        public Movie(String title, int priceCode)
        {
            _title = title;
			setPriceCode(priceCode);
        }
        public int getPriceCode()
        {
            //return _priceCode;
			return _price.getPriceCode();
        }
        public void setPriceCode(int arg)
        {
            //_priceCode = arg;
			switch (arg)
			{ 
				case REGULAR:
					_price = new RegularPrice();
					break;
				case CHILDREN:
					_price = new ChildrensPrice();
					break;
				case NEW_RELEASE:
					_price = new NewReleasePrice();
					break;
				default:
					throw new Exception();

			}
        }
        public String getTitle()
        {
            return _title;
        }

		// перенеся два метода 
		// они сведены в класс, кодторый содержит этот тип
		public double getCharge(int daysRented)
		{
			return _price.getCharge(daysRented);
		}
		public  int getFrequentRenterPoints(int daysRented)
		{
			return _price.getFrequentRenterPoints(daysRented);
		}
    }
	// замена кода типа состоянием-стратегией

	abstract class Price
	{
		public abstract int getPriceCode();
		// переместили метод в Price
		public abstract double getCharge(int daysRented);
		// так как этот метод не был в условном операторе для всех подклассов
		// то разбиваем только для одного полкласса - определяя в нем такой же метод как и в родительском.
		// в остальных подклассах будет использоваться родительский метод
		public int getFrequentRenterPoints(int daysRented)
		{
			return 1;
		}
	}
	class ChildrensPrice : Price
	{
		public override int getPriceCode()
		{
			return Movie.CHILDREN;
		}
		public override double getCharge(int daysRented)
		{
			double result = 1.5;
			if (daysRented > 3)
				result += (daysRented - 3) * 1.5;
			return result;
		}
	}
	class NewReleasePrice : Price
	{
		public override int getPriceCode()
		{
			return Movie.NEW_RELEASE;
		}
		public override double getCharge(int daysRented)
		{
			return daysRented * 3;
		}
		public int getFrequentRenterPoints(int daysRented)
		{
			//бонус за аренду новинки на два дня
			if ((getPriceCode() == Movie.NEW_RELEASE) && daysRented > 1)
				return 2;
			return 1;

			return (daysRented > 1) ? 2 : 1;
		}
	}
	class RegularPrice : Price
	{
		public override int getPriceCode()
		{
			return Movie.REGULAR;
		}
		public override double getCharge(int daysRented)
		{
			double result = 2;
			if (daysRented > 2)
				result += (daysRented - 2) * 1.5;
					
			return result;
		}
	}

    // класс представляющий данные о прокате фильма
    class Rental
    {
        private Movie _movie;
        private int _daysRented;
        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }
        public int getDaysRented()
        {
            return _daysRented;
        }
        public Movie getMovie()
        {
            return _movie;
        }
		public double getCharge()
		{
			return _movie.getCharge(_daysRented);
		}
        
		public int getFrequentRenterPoints()
		{
			return _movie.getFrequentRenterPoints(_daysRented);
		}
    }

    // класс, представляющий клиента магазина
    class Customer
    {
        private string _name;
        private List<Rental> _rental = new List<Rental>();
        public Customer(String name)
        {
            _name = name;
        }
        public void addRental(Rental arg)
        {
            _rental.Add(arg);
        }
        public String getName()
        {
            return _name;
        }
        public string statement()
        {
			return new TextStatement().value(this);
        }
		// замена временной переменной методом
		private double getTotalCharge() 
		{
			double result = 0;
			foreach (Rental each in _rental)
			{
				result += each.getCharge();
			}
			return result;
		}
		// замена временной переменной методом
		private int getTotalFrequentRenterPoints()
		{
			int result = 0;
			foreach (Rental each in _rental)
			{
				result += each.getFrequentRenterPoints();
			}
			return result;
		}
		
		// написание нового метода
		public string htmlStatement()
		{

			return new HtmlStatement().value(this);
		}

		// необходимо чтобы методы  htmlStatement и statement 
		// появились в подклассах некоторого общего родительского класса
		// создадим отдельную иерархию стратегий для вывода выписок.
		// После того как выделили методы footerString,eachRentalString, headerString
		// методы value стали похожими.
		// Применим к нему подъем метода. А также добавим абстрактные методы.
		public abstract class Statement 
		{
			public String value(Customer aCustomer)
			{
				string result = headerString(aCustomer);
				foreach (Rental each in aCustomer._rental)
				{
					// показать результаты для этой аренды
					result += eachRentalString(each);
				}

				// добавить нижний колонтитул 
				result += footerString(aCustomer);
				return result;
			}
			public abstract string footerString(Customer aCustomer);
			//{ return ""; }
			public abstract string eachRentalString(Rental each);
			//{ return ""; }
			public abstract string headerString(Customer aCustomer);
			//{ return ""; }
		}
		class TextStatement : Statement 
		{
			public override string footerString(Customer aCustomer)
			{
				return "Сумма задолженности составляет " + aCustomer.getTotalCharge() + "\n" +
					 "Вы заработали " + aCustomer.getTotalFrequentRenterPoints() + " oчков за активность";
			}

			public override string eachRentalString(Rental each)
			{
				return "\t" + each.getMovie().getTitle() + "\t" + each.getCharge() + "\n";
			}

			public override string headerString(Customer aCustomer)
			{
				return "Учет аренды для " + aCustomer.getName() + "\n";
			}
		}
		class HtmlStatement : Statement 
		{
			public override string footerString(Customer aCustomer)
			{
				return "<P> Ваша задолженность составляет <EM>" + aCustomer.getTotalCharge() + " </EM><P>\n" + 
					 "На этой аренде вы заработали <EM>" + aCustomer.getTotalFrequentRenterPoints() + "</EM> очков за активность<P>";
			}

			public override string eachRentalString(Rental each)
			{
				return each.getMovie().getTitle() + ": " + each.getCharge() + "<BR>\n";
			}

			public override string headerString(Customer aCustomer)
			{
				return "<H1>Операция аренды для <EM>" + aCustomer.getName() + "</EM></H1><P>\n";
			}
		}
      
    }

}
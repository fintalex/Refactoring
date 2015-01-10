using System;
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
        private int _priceCode;

        public Movie(String title, int priceCode)
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
        public String getTitle()
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
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            List<Rental> rentals = new List<Rental>();
            string result = "Учет аренды для " + getName() + "\n";
            foreach (Rental each in rentals)
            {
                double thisAmount = 0;
                // определить сумму для каждой строки
                thisAmount = amountFor(each);
                // добавить очки для активного арендатора
                frequentRenterPoints++;
                //бонус за аренду новинки на два дня
                if ((each.getMovie().getPriceCode() == Movie.NEW_RELEASE) && each.getDaysRented() > 1)
                    frequentRenterPoints++;
                // показать результаты для этой аренды
                result += "\t" + each.getMovie().getTitle() + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }

            // добавить нижний колонтитул 
            result += "Сумма задолженности составляет " + totalAmount.ToString() + "\n";
            result += "Вы заработали " + frequentRenterPoints.ToString() + " oчков за активность";
            return result;
        }

        private static double amountFor(Rental each)
        {
            double thisAmount=0;
            switch (each.getMovie().getPriceCode())
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (each.getDaysRented() > 2)
                        thisAmount += (each.getDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += each.getDaysRented() * 3;
                    break;
                case Movie.CHILDREN:
                    thisAmount += 1.5;
                    if (each.getDaysRented() > 3)
                        thisAmount += (each.getDaysRented() - 3) * 1.5;
                    break;
            }
            return thisAmount;
        }
    }

}
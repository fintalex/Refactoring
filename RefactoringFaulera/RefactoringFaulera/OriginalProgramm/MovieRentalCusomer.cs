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
        public static readonly int CHILDREN = 2;
        public static readonly int REGULAR = 0;
        public static readonly int NEW_RELEASE = 1;
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

    }

}

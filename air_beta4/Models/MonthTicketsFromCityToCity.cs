using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{
    public class MonthTicketsFromCityToCity
    {
        public string city;
        public List<MonthTicketsResult> monthTicketsTo, monthTicketsFrom;
        public double averagePrice; 

        private double getAveragePrice(List<MonthTicketsResult> list)
        {
            double sum = 0;
            foreach (MonthTicketsResult c in list)
            {
                sum += c.price;
            }
            return sum / list.Count;
        }
        public MonthTicketsFromCityToCity(string city, List<MonthTicketsResult> monthTicketsTo, List<MonthTicketsResult> monthTicketsFrom) 
        {
            this.city = city;
            this.monthTicketsTo = monthTicketsTo;
            this.monthTicketsFrom = monthTicketsFrom;
          
            double averagePriceTo = getAveragePrice(monthTicketsTo);
            double averagePriceFrom = getAveragePrice(monthTicketsFrom);
            this.averagePrice = averagePriceTo + averagePriceFrom;
        }
    }
}
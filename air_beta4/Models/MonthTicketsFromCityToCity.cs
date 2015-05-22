using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{
    public class MonthTicketsFromCityToCity
    {
        public string city;
        public List<MonthTicketsResult> monthTickets3;
        public List<MonthTicketsResult> monthTickets7;
        public List<MonthTicketsResult> monthTickets15;

        public MonthTicketsFromCityToCity(string city, List<MonthTicketsResult> monthTickets3, List<MonthTicketsResult> monthTickets7, List<MonthTicketsResult> monthTickets15) 
        {
            this.city = city;
            this.monthTickets3 = monthTickets3;
            this.monthTickets7 = monthTickets7;
            this.monthTickets15 = monthTickets15;
        }
    }
}
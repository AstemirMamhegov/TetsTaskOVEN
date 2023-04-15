using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetsTaskOVEN.Models;

namespace TetsTaskOVEN
{
    public class DBController
    {
        private static DBController _instance = new DBController();
        private FlightContext _flightContext = new FlightContext();

        public static DBController Instance
        {
            get
            {
                return _instance;
            }
        }

        private DBController() { }

        public List<FlightInfo> Flights => _flightContext.Flights.ToList();

        public void Update(FlightInfo country)
        {
            if (country.Id == 0)
                _flightContext.Flights.Add(country);
            _flightContext.SaveChanges();
        }

        public void Remove(FlightInfo country)
        {
            _flightContext.Flights.Remove(country);
            _flightContext.SaveChanges();
        }
    }
}

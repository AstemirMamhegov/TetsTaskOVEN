using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetsTaskOVEN.Models;

namespace TetsTaskOVEN
{
    public class FlightContext : DbContext
    {
        static FlightContext()
        {
            Database.SetInitializer(new MyContextInitializer());
        }

        public FlightContext() : base("DBConnection") 
        {
        }

        public DbSet<FlightInfo> Flights { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetsTaskOVEN.Models
{
    [Table("FlightInfo")]
    public class FlightInfo
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public int RouteNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string FIO
        {
            get
            {
                return $"{LastName} {FirstName} {MiddleName}";
            }
        }

        public override string ToString()
        {
            return FIO;
        }
    }
}

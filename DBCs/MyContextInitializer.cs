using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TetsTaskOVEN
{
    public class MyContextInitializer : DropCreateDatabaseIfModelChanges<FlightContext>
    {
        protected override void Seed(FlightContext context)
        {
            base.Seed(context);
            context.SaveChanges();
        }
    }
}

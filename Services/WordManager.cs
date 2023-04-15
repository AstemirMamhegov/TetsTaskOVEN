using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetsTaskOVEN.Models;

namespace TetsTaskOVEN
{
    public static class WordManager
    {
        public static void Export(FlightInfo flight, string filename)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filename, true))
            {
                var contentControls = wordDoc.MainDocumentPart.Document.Descendants<SdtElement>();

                foreach (var item in contentControls)
                {
                    string tag = item.SdtProperties.GetFirstChild<Tag>().Val.Value;

                    Text text = item.Descendants<Text>().First();
                    foreach (var itemText in item.Descendants<Text>())
                    {
                        itemText.Text = "";
                    }

                    switch (tag)
                    {
                        case "_firstName":
                            text.Text = flight.FirstName; break;
                        case "_lastName":
                            text.Text = flight.LastName; break;
                        case "_middleName":
                            text.Text = flight.MiddleName; break;
                        case "_departureTime":
                            text.Text = flight.DepartureTime.ToShortDateString(); break;
                        case "_routeNumber":
                            text.Text = flight.RouteNumber.ToString(); break;

                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetsTaskOVEN.Models;

namespace TetsTaskOVEN
{
    public partial class NewAddPassenger_Form : Form
    {
        private FlightInfo _flightInfo;

        public NewAddPassenger_Form(FlightInfo flightInfo = null)
        {
            InitializeComponent();
            if(flightInfo != null )
            {
                _flightInfo = flightInfo;

                routeNumericUpDown.Value = flightInfo.RouteNumber;
                departureDateTimePicker.Value = flightInfo.DepartureTime;
                FirstNameTextBox.Text = flightInfo.FirstName;
                LastNameTextBox.Text = flightInfo.LastName;
                MiddleNameTextBox.Text = flightInfo.MiddleName;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if( _flightInfo == null )
            {
                _flightInfo = new FlightInfo();
            }

            _flightInfo.RouteNumber = (int)routeNumericUpDown.Value;
            _flightInfo.DepartureTime = departureDateTimePicker.Value;
            _flightInfo.FirstName = FirstNameTextBox.Text;
            _flightInfo.LastName = LastNameTextBox.Text;
            _flightInfo.MiddleName = MiddleNameTextBox.Text;

            DBController.Instance.Update(_flightInfo);
            DialogResult = DialogResult.OK;
        }
    }
}

using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetsTaskOVEN.Models;
using TetsTaskOVEN.Services;

namespace TetsTaskOVEN
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateGrid()
        {
            var flights = DBController.Instance.Flights;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = flights;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewAddPassenger_Form form = new NewAddPassenger_Form();
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateGrid();
            }
        }

       

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFlightInfo();
        }

        private void OpenFlightInfo()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FlightInfo flights = dataGridView1.SelectedRows[0].DataBoundItem as FlightInfo;

                NewAddPassenger_Form form = new NewAddPassenger_Form(flights);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateGrid();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FlightInfo flights = dataGridView1.SelectedRows[0].DataBoundItem as FlightInfo;

                DBController.Instance.Remove(flights);
                UpdateGrid();
            }
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FlightInfo flights = dataGridView1.SelectedRows[0].DataBoundItem as FlightInfo;

                saveFileDialog1.FileName = flights.FIO;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog1.FileName;

                    if (File.Exists(filename))
                        File.Delete(filename);

                    File.Copy("Личная карта студента.docx", filename);

                    WordManager.Export(flights, filename);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenFlightInfo();
        }

        private void excelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<FlightInfo> flights = (List<FlightInfo>)dataGridView1.DataSource;

                ExcelManager.ExportFlightInfo(saveFileDialog1.FileName, flights);
            }
        }

        private void excelImportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                List<FlightInfo> flights = (List<FlightInfo>)dataGridView1.DataSource;

                ExcelManager.ImportFlightInfo(openFileDialog1.FileName, flights, dataGridView1);
            
        }
    }
}

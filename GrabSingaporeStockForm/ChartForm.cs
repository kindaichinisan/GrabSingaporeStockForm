using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GrabSingaporeStockForm
{
    public partial class ChartForm : Form
    {
        private List<YahooStockData> ysd;
        private string stockname;

        public ChartForm()
        {
            InitializeComponent();
        }

        public ChartForm(List<YahooStockData> ysd,string stockname) : this()
        {
            this.ysd = ysd;
            this.stockname = stockname;
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("C");
            List<DateTime> xvals = new List<DateTime>();
            List<float> yvals = new List<float>();

            for (int i = 0; i < ysd.Count; i++)
            {
                xvals.Add(ysd[i].date);
                yvals.Add(ysd[i].close);
            }

            Chart chart=changeStockDateRange(xvals, yvals);

            stockchart.Controls.Add(chart);

            StartdateTimePicker.MinDate = xvals[0];
            //StartdateTimePicker.MaxDate = xvals[xvals.Count - 1];
            StartdateTimePicker.Value = xvals[0];

            EnddateTimePicker.MinDate = xvals[0];
            EnddateTimePicker.MaxDate = xvals[xvals.Count - 1];
            EnddateTimePicker.Value = xvals[xvals.Count - 1];
        }

        private void StartdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("aaaaaaaa");
            //List<DateTime> xvals = new List<DateTime>();
            //List<float> yvals = new List<float>();

            //for (int i = 0; i < ysd.Count; i++)
            //{
            //        xvals.Add(ysd[i].date);
            //        yvals.Add(ysd[i].close);
 
            //}

            //var chart = new Chart();
            //chart.Size = new Size(800, 250);
            //chart.Titles.Add(stockname);

            //var chartArea = new ChartArea();
            //chartArea.AxisX.LabelStyle.Format = "dd/MMM/yy";
            //chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            //chartArea.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            //chartArea.AxisX.Title = "Date";
            //chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            //chartArea.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            //chartArea.AxisY.Title = "Price (SGD)";

            //chart.ChartAreas.Add(chartArea);

            //var series = new Series();
            //series.Name = "Series1";
            //series.ChartType = SeriesChartType.FastLine;
            //series.XValueType = ChartValueType.DateTime;
            //chart.Series.Add(series);

            //// bind the datapoints
            //chart.Series["Series1"].Points.DataBindXY(xvals, yvals);

            //// copy the series and manipulate the copy
            //chart.DataManipulator.CopySeriesValues("Series1", "Series2");
            //chart.DataManipulator.FinancialFormula(
            //    FinancialFormula.WeightedMovingAverage,
            //    "Series2"
            //);
            //chart.Series["Series2"].ChartType = SeriesChartType.FastLine;

            //// draw!
            //chart.Invalidate();

            //// write out a file
            //chart.SaveImage("chart.png", ChartImageFormat.Png);

            //stockchart.Controls.Add(chart);

            //StartdateTimePicker.MinDate = xvals[0];
            //StartdateTimePicker.MaxDate = xvals[xvals.Count - 1];
            //StartdateTimePicker.Value = xvals[0];

            //EnddateTimePicker.MinDate = xvals[0];
            //EnddateTimePicker.MaxDate = xvals[xvals.Count - 1];
            //EnddateTimePicker.Value = xvals[xvals.Count - 1];
        }

        private void StartdateTimePicker_CloseUp(object sender, EventArgs e)
        {
            //MessageBox.Show("b");
            DateTime dt=StartdateTimePicker.Value;

            List<DateTime> xvals = new List<DateTime>();
            List<float> yvals = new List<float>();

            for (int i = 0; i < ysd.Count; i++)
            {
                if (ysd[i].date >= dt)
                {
                    xvals.Add(ysd[i].date);
                    yvals.Add(ysd[i].close);
                }
            }

            Chart chart=changeStockDateRange(xvals, yvals);

            stockchart.Controls.Clear();
            
            stockchart.Controls.Add(chart);

        }

        private Chart changeStockDateRange(List<DateTime> xvals, List<float> yvals)
        {
            var chart = new Chart();
            chart.Size = new Size(800, 250);
            chart.Titles.Add(stockname);

            var chartArea = new ChartArea();
            chartArea.AxisX.LabelStyle.Format = "dd/MMM/yy";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea.AxisX.Title = "Date";
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chartArea.AxisY.Title = "Price (SGD)";

            chart.ChartAreas.Add(chartArea);

            var series = new Series();
            series.Name = "Series1";
            series.ChartType = SeriesChartType.FastLine;
            series.XValueType = ChartValueType.DateTime;
            chart.Series.Add(series);

            // bind the datapoints
            chart.Series["Series1"].Points.DataBindXY(xvals, yvals);

            // copy the series and manipulate the copy
            chart.DataManipulator.CopySeriesValues("Series1", "Series2");
            chart.DataManipulator.FinancialFormula(
                FinancialFormula.WeightedMovingAverage,
                "Series2"
            );
            chart.Series["Series2"].ChartType = SeriesChartType.FastLine;

            // draw!
            chart.Invalidate();

            // write out a file
            chart.SaveImage("chart.png", ChartImageFormat.Png);

            return chart;
        }
    }
}

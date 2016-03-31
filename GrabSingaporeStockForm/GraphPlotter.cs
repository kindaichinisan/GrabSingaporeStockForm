using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace GrabSingaporeStockForm
{
    class GraphPlotter
    {
        public static Chart plotGraph(List<YahooStockData> ysd)
        {
            List<DateTime> xvals = new List<DateTime>();
            List<float> yvals = new List<float>();
            for (int i = 0; i < ysd.Count; i++)
            {
                xvals.Add(ysd[i].date);
                yvals.Add(ysd[i].close);
            }

            // create the chart
            var chart = new Chart();
            chart.Size = new Size(600, 250);
            var chartArea = new ChartArea();
            chartArea.AxisX.LabelStyle.Format = "dd/MMM/yy";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea.AxisY.LabelStyle.Font = new Font("Consolas", 8);
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

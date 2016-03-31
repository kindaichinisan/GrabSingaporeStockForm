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
using System.Windows.Forms.DataVisualization.Charting;

namespace GrabSingaporeStockForm
{
    public partial class Form1 : Form
    {
        public const string datainfolder = @"data_in\";
        const string dataoutfolder = @"data_out\";
        const string WJSTOCKDATA_EXT=".wjstockdata";

        public Form1()
        {
            InitializeComponent();

            StockDatadataGridView.Columns.Add("Stock","Stock");
            StockDatadataGridView.CellClick += new DataGridViewCellEventHandler(StockDatadataGridView_CellClick);

            DirectoryInfo di = new DirectoryInfo(dataoutfolder);
            FileInfo[] TXTFiles = di.GetFiles("*"+WJSTOCKDATA_EXT);

            for (int i = 0; i < TXTFiles.Length; i++)
            {
                int ext_idx = TXTFiles[i].Name.LastIndexOf('.');

                StockDatadataGridView.Rows.Add(TXTFiles[i].Name.Substring(0,ext_idx));
            }
        }

        private void StockDatadataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) 
                return; // header clicked

            // Your logic here. You can gain access to any cell value via DataGridViewCellEventArgs
            string address = StockDatadataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();

            logTextBox.Text = address + " was clicked." + Environment.NewLine + logTextBox.Text;
            logTextBox.Refresh();

            List<YahooStockData> ysd=WJStockDataReader.readStockData(dataoutfolder, address + WJSTOCKDATA_EXT);

            
            ChartForm cf = new ChartForm(ysd,address);
            //DialogResult dr=
                cf.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            StockFileReader sfr = new StockFileReader(datainfolder, "stocks.txt");

            List<string> stockcode = sfr.getStockCode();
            List<string> stockname = sfr.getStockName();

            YahooStockHistoryDownload yshd = new YahooStockHistoryDownload();
            YahooStockCSVParser yscp = new YahooStockCSVParser();
            WJStockDataWriter wsdw = new WJStockDataWriter();
            WJStockDataReader wsdr = new WJStockDataReader();

            for (int i = 0; i < stockcode.Count; i++)
            {
                string stockcsvfilename = stockname[i] + ".csv";
                string stockwjdatafilename = stockname[i] + WJSTOCKDATA_EXT;
                Constant.DOWNLOAD_STATUS dl_status = yshd.downloadFile(stockcode[i], dataoutfolder, stockcsvfilename);
                if (dl_status == Constant.DOWNLOAD_STATUS.PASS)
                {
                    if (File.Exists(dataoutfolder + stockwjdatafilename))
                    {
                        DateTime latest_date = WJStockDataReader.readStockDataLatestDate(dataoutfolder, stockwjdatafilename);
                        List<YahooStockData> ysd = yscp.parseUpdatedCSV(dataoutfolder, stockcsvfilename, latest_date);
                        wsdw.appendStockData(dataoutfolder, stockwjdatafilename, ysd);
                        logTextBox.Text = "Updating new stock data " + stockname[i]+Environment.NewLine+logTextBox.Text;
                        logTextBox.Refresh();
                    }
                    else
                    {
                        List<YahooStockData> ysd = yscp.parseAllCSV(dataoutfolder, stockcsvfilename);
                        wsdw.writeStockData(dataoutfolder, stockwjdatafilename, ysd);
                        logTextBox.Text = "Creating new stock data " + stockname[i] + Environment.NewLine + logTextBox.Text;
                        logTextBox.Refresh();
                    }
                }
                else
                {
                    logTextBox.Text = "Error downloading stock data " + stockname[i] + Environment.NewLine + logTextBox.Text;
                    logTextBox.Refresh();
                }
                File.Delete(dataoutfolder + stockcsvfilename);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GrabSingaporeStockForm
{
    class YahooStockCSVParser
    {
        public YahooStockCSVParser()
        {
        }

        public List<YahooStockData> parseAllCSV(string folder,string filename)
        {
            var reader = new StreamReader(File.OpenRead(folder+filename));
            
            List<YahooStockData> ysd = new List<YahooStockData>();

            var line = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                var values = line.Split(',');

                YahooStockData tmp_ysd = new YahooStockData();
                tmp_ysd.date = Convert.ToDateTime(values[0]);
                tmp_ysd.open = Convert.ToSingle(values[1]);
                tmp_ysd.high = Convert.ToSingle(values[2]);
                tmp_ysd.low = Convert.ToSingle(values[3]);
                tmp_ysd.close = Convert.ToSingle(values[4]);
                tmp_ysd.volume = Convert.ToUInt64(values[5]);
                tmp_ysd.adjusted_close = Convert.ToSingle(values[6]);

                ysd.Add(tmp_ysd);

            }

            ysd.Reverse(); //from earliest to latest.

            reader.Close();

            return ysd;
        }

        public List<YahooStockData> parseUpdatedCSV(string folder,string filename,DateTime latest_date)
        {
            var reader = new StreamReader(File.OpenRead(folder+filename));

            List<YahooStockData> ysd = new List<YahooStockData>();

            var line = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                var values = line.Split(',');

                YahooStockData tmp_ysd = new YahooStockData();
                tmp_ysd.date = Convert.ToDateTime(values[0]);

                if (tmp_ysd.date == latest_date)
                    break;
                tmp_ysd.open = Convert.ToSingle(values[1]);
                tmp_ysd.high = Convert.ToSingle(values[2]);
                tmp_ysd.low = Convert.ToSingle(values[3]);
                tmp_ysd.close = Convert.ToSingle(values[4]);
                tmp_ysd.volume = Convert.ToUInt64(values[5]);
                tmp_ysd.adjusted_close = Convert.ToSingle(values[6]);

                ysd.Add(tmp_ysd);

            }

            ysd.Reverse(); //from earliest to latest.

            reader.Close();

            return ysd;
        }
    }
}

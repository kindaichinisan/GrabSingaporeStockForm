using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GrabSingaporeStockForm
{
    class WJStockDataReader
    {
        public WJStockDataReader()
        {
        }

        public static DateTime readStockDataLatestDate(string folder,string filename)
        {
            string[] lines=File.ReadAllLines(folder+filename);
            string[] line=lines[lines.Length-1].Split(',');
            DateTime date = Convert.ToDateTime(line[0]);
            return date;
        }

        public static List<YahooStockData> readStockData(string folder, string filename)
        {
            List<YahooStockData> ysd = new List<YahooStockData>();

            string[] lines = File.ReadAllLines(folder + filename);
            

            for (int i = 0; i < lines.Length; i++)
            {
                YahooStockData tmp_ysd = new YahooStockData();
                string[] line = lines[i].Split(','); 
                
                tmp_ysd.date = Convert.ToDateTime(line[0]);
                tmp_ysd.open = Convert.ToSingle(line[1]);
                tmp_ysd.high = Convert.ToSingle(line[2]);
                tmp_ysd.low = Convert.ToSingle(line[3]);
                tmp_ysd.close = Convert.ToSingle(line[4]);
                tmp_ysd.volume = Convert.ToUInt64(line[5]);
                tmp_ysd.adjusted_close = Convert.ToSingle(line[6]);

                ysd.Add(tmp_ysd);
            }

            return ysd;
        }
    }
}

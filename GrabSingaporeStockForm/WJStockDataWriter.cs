using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GrabSingaporeStockForm
{
    class WJStockDataWriter
    {
        public WJStockDataWriter()
        {
        }

        public void writeStockData(string folder,string filename,List<YahooStockData> ysd)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(folder+filename))
            {
                for (int i = 0; i < ysd.Count; i++)
                {
                    file.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},",
                        ysd[i].date.ToShortDateString(),ysd[i].open.ToString(),ysd[i].high.ToString(),
                        ysd[i].low.ToString(),ysd[i].close.ToString(),ysd[i].volume.ToString(),ysd[i].adjusted_close.ToString()));
                }
            }

        }

        public void appendStockData(string folder,string filename, List<YahooStockData> ysd)
        {
            using (System.IO.StreamWriter file = File.AppendText(folder+filename))
            {
                for (int i = 0; i < ysd.Count; i++)
                {
                    file.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},",
                        ysd[i].date.ToShortDateString(), ysd[i].open.ToString(), ysd[i].high.ToString(),
                        ysd[i].low.ToString(), ysd[i].close.ToString(), ysd[i].volume.ToString(), ysd[i].adjusted_close.ToString()));
                }
            }

        }

    }
}

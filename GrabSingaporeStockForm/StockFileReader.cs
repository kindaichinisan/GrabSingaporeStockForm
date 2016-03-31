using System;
using System.Collections.Generic;
using System.Text;

namespace GrabSingaporeStockForm
{
    class StockFileReader
    {
        public List<string> stockcode=new List<string>();
        public List<string> stockname = new List<string>();

        public StockFileReader(string folder, string filename)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(folder+filename);
            while ((line = file.ReadLine()) != null)
            {
                if (line.Length!=0 && line[0].CompareTo('%') != 0)
                {
                    string[] words=line.Split(',');
                    stockcode.Add(words[0]);
                    stockname.Add(words[1]);
                    Console.WriteLine(line);
                }
            }
            file.Close();
        }

        public List<string> getStockCode()
        {
            return stockcode;
        }
        public List<string> getStockName()
        {
            return stockname;
        }
    }
}

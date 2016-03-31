using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace GrabSingaporeStockForm
{
    class YahooStockHistoryDownload
    {
        
        public YahooStockHistoryDownload()
        {
        }

        public Constant.DOWNLOAD_STATUS downloadFile(string stockcode,string outfolder,string filename)
        {
            using (var client = new WebClient())
            {
                var contents = client.DownloadString("http://finance.yahoo.com/q/hp?s=" + stockcode + "+Historical+Prices");
                //Console.WriteLine(contents);
                int a = contents.IndexOf("Download to Spreadsheet");
                //Console.WriteLine(a.ToString());
                if (a != -1)
                {
                    int b = contents.LastIndexOf("<a href=\"", a);
                    //Console.WriteLine(b.ToString());
                    int c = contents.IndexOf(".csv\"", b);
                    string d = contents.Substring(b + 9, c + 3 - b - 9 + 1);
                    //Console.WriteLine(d);

                    client.DownloadFile(d, outfolder+filename);
                    return Constant.DOWNLOAD_STATUS.PASS;
                }
                else
                {
                    return Constant.DOWNLOAD_STATUS.FAIL;
                }
            }
        }
    }
}

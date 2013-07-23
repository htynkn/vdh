using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using RestSharp;

namespace VideoDownloadHelper
{
    public class ProgramHelper
    {
        public static int number = 12; //1.9版本

        public static String CheckFiles(String[] names)
        {
            StringBuilder sb = new StringBuilder();
            String ss = Directory.GetCurrentDirectory();
            String[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            Boolean isHave = false;
            foreach (String name in names)
            {
                foreach (String file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (fileInfo.Name.Equals(name))
                    {
                        isHave = true;
                        break;
                    }
                }
                if (!isHave)
                {
                    sb.Append(" 没有找到文件" + name);
                }
                isHave = false;
            }

            return sb.ToString();
        }

        public static String UpdateCheck()
        {
            var client = new RestClient();
            client.BaseUrl = "http://vdhelper.sinaapp.com";

            var request = new RestRequest();
            request.Resource = "/program/update.xml";
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.97 Safari/537.11 VdhUpdater/1.6");

            IRestResponse<UpdateModel> response = client.Execute<UpdateModel>(request);
            return response.Data.ToString();
        }

        private class UpdateModel
        {
            public String Version { get; set; }
            public String Number { get; set; }
            public String Description { get; set; }
            public String Downlink { get; set; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(this.Version).Append(",");
                sb.Append(this.Number).Append(",");
                sb.Append(this.Description).Append(",");
                sb.Append(this.Downlink);
                return sb.ToString();
            }
        }
    }
}

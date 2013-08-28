using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSoup.Nodes;
using NSoup;
using NSoup.Select;
using VideoDownloadHelper.YoukuUserHome;
using Mono.Addins;
using System.Text.RegularExpressions;
using VideoDownloadHelper.Helper;

[assembly: Addin]
[assembly: AddinDependency("VideoDownloadHelper", "1.9")]

namespace VideoDownloadHelper.YoukuUserHome
{
    [Extension]
    public class YoukuUserHome : IPlugin
    {
        public int GetVersionNumber()
        {
            return 5;
        }

        public string GetVersion()
        {
            return "V2.1";
        }

        public bool isVaild(string url)
        {
            Regex regex = new Regex(@"http://i.youku.com/u/[^s]*/videos([^s]*|)");
            Match m = regex.Match(url);
            if (m.Success)
            {
                this.Url = url;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<BaseItem> GetList()
        {
            this.Items = new List<BaseItem>();

            String temp = WebHelper.GetHtmlCodeByWebClientWithGzip(this.Url, "utf-8");
            Document doc = NSoupClient.Parse(temp);
            Elements list = doc.Select("div.items>ul");
            foreach (Element item in list)
            {
                Element e1 = item.Select("li.v_title").Select("a").First();
                String url = e1.Attr("href");
                String title = e1.Attr("title");

                BaseItem b = new BaseItem() { Url = url, Name = title, Time = "未知", Owner = "未知" };

                this.Items.Add(b);
            }

            return this.Items;
        }

        public String Down(int index)
        {
            String baseUrl = "iku://|video|http://v.youku.com/v_show/id_{0}.html|quality=flv|";
            Regex regex = new Regex(@"http://v.youku.com/v_show/id_([^s]*).htm*");
            Match match = regex.Match(this.items[index].Url);
            String id = match.Groups[1].Value;
            return String.Format(baseUrl, id);
        }

        public List<BaseItem> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
            }
        }

        private List<BaseItem> items;

        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
            }
        }

        private String url;
    }
}

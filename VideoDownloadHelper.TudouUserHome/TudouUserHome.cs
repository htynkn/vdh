using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSoup.Nodes;
using NSoup;
using NSoup.Select;
using Mono.Addins;

[assembly: Addin]
[assembly: AddinDependency("VideoDownloadHelper", "1.5")]

namespace VideoDownloadHelper.TudouUserHome
{
    [Extension]
    public class TudouUserHome : IPlugin
    {

        public int GetVersionNumber()
        {
            return 1;
        }

        public string GetVersion()
        {
            return "V1.0";
        }

        public bool isVaild(string url)
        {
            if (url.StartsWith("http://www.tudou.com/home/_"))
            {
                if (!url.EndsWith("/"))
                {
                    url = url + "/";
                }
                String number = WordHelper.CutWordByKeyword(url, "http://www.tudou.com/home/_", "/");
                url = String.Format("http://www.tudou.com/home/item_u{0}s0p1.html", number);
            }

            if (url.StartsWith("http://www.tudou.com/home/item_") && url.EndsWith(".html"))
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

            String temp = WebHelper.GetHtmlCodeByWebClientWithGzip(this.Url, "gbk");
            Document doc = NSoupClient.Parse(temp);
            Elements items = doc.Select("div[class=showcase]").First.Select("div[class=item]");
            foreach (Element item in items)
            {
                Element item1 = item.Select("h1[class=caption] a").First;
                String title = item1.Attr("title");
                String url = item1.Attr("href");
                Element item2 = item.Select("ul[class=info] li").First;
                String time = item2.OwnText();

                BaseItem b = new BaseItem() { Name = title, Url = url, Time = time, Owner = "未知" };

                this.Items.Add(b);
            }

            return this.Items;
        }

        public void Down(int index)
        {
            String temp = WebHelper.GetHtmlCodeByWebClientWithGzip(items[index].Url, "gbk");
            Document doc = NSoupClient.Parse(temp);
            Element script = doc.Select("body>script").First();
            String target = script.OuterHtml();
            String iid = WordHelper.CutWordByKeyword(target, "iid: ", ",").Trim();
            System.Diagnostics.Process.Start("tudou://" + iid + "/");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSoup.Nodes;
using NSoup;
using NSoup.Select;
using Mono.Addins;
using System.Text.RegularExpressions;

[assembly: Addin]
[assembly: AddinDependency("VideoDownloadHelper", "1.9")]

namespace VideoDownloadHelper.TudouUserHome
{
    [Extension]
    public class TudouUserHome : IPlugin
    {

        public int GetVersionNumber()
        {
            return 3;
        }

        public string GetVersion()
        {
            return "V1.2";
        }

        public bool isVaild(string url)
        {
            Regex regex = new Regex(@"http://www.tudou.com/home/item_u(\d*)s(\d*)p(\d*).html");
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

        public String Down(int index)
        {
            String temp = WebHelper.GetHtmlCodeByWebClientWithGzip(items[index].Url, "gbk");
            Document doc = NSoupClient.Parse(temp);
            Element script = doc.Select("body>script").First();
            String target = script.OuterHtml();
            String iid = WordHelper.CutWordByKeyword(target, "iid: ", ",").Trim();
            return "tudou://" + iid + ":st=2/";
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

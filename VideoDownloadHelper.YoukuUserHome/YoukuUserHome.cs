using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSoup.Nodes;
using NSoup;
using NSoup.Select;
using VideoDownloadHelper.YoukuUserHome;
using Mono.Addins;

[assembly: Addin]
[assembly: AddinDependency("VideoDownloadHelper", "1.4")]

namespace VideoDownloadHelper.YoukuUserHome
{
    [Extension]
    public class YoukuUserHome : IPlugin
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
            if (url.StartsWith("http://u.youku.com/user_video/id_") && url.EndsWith(".html"))
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
            Element et = doc.Select("div[class=vList]").First;
            Elements list = et.Select("ul[class=video]");
            foreach (Element item in list)
            {
                Element e1 = item.Select("li")[2].Select("a").First();
                String url = e1.Attr("href");
                String title = e1.Attr("title");

                BaseItem b = new BaseItem() { Url = url, Name = title, Time = "未知", Owner = "未知" };

                this.Items.Add(b);
            }

            return this.Items;
        }

        public void Down(int index)
        {
            String temp = WebHelper.GetHtmlCodeByWebClientWithGzip(this.Items[index].Url, "utf-8");
            Document doc = NSoupClient.Parse(temp);
            Element et = doc.Select("div[id=fn_favodownload] a[id=fn_download]").First;
            String down = et.Attr("_href");
            Console.WriteLine(down);
            System.Diagnostics.Process.Start(down);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoDownloadHelper.YoukuAlbum;
using Mono.Addins;
using NSoup.Nodes;
using NSoup.Select;
using NSoup;

[assembly: Addin]
[assembly: AddinDependency("VideoDownloadHelper", "1.3")]

namespace VideoDownloadHelper.YoukuAlbum
{
     [Extension]
    public class YoukuAlbum : IPlugin
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
            if (url.StartsWith("http://www.youku.com/playlist_show/id_") && url.EndsWith(".html"))
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

            String temp = WebHelper.GetHtmlCodeByWebClient(this.Url, "utf-8");
            Document doc = NSoupClient.Parse(temp);
            Element et = doc.Select("div[class=collgrid4w] div[class=items]").First;
            Elements list = et.Select("ul[class=v]");
            foreach (Element item in list)
            {
                Element e1 = item.Select("li[class=v_link] a").First;
                String url = e1.Attr("href");
                String title = e1.Attr("title");
                Element e2 = item.Select("li[class=v_user] a").First;
                String upOwner = e2.OwnText();
                Element e3 = item.Select("li[class=v_time] span[class=num]").First;
                String time = e3.OwnText();

                BaseItem b = new BaseItem() { Name = title, Url = url, Time = time, Owner = upOwner };

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoDownloadHelper.YoukuAlbum;
using Mono.Addins;
using NSoup.Nodes;
using NSoup.Select;
using NSoup;
using System.Text.RegularExpressions;
using VideoDownloadHelper.Helper;

[assembly: Addin]
[assembly: AddinDependency("VideoDownloadHelper", "2.0")]

namespace VideoDownloadHelper.YoukuAlbum
{
    [Extension]
    public class YoukuAlbum : IPlugin
    {
        public int GetVersionNumber()
        {
            return 3;
        }

        public string GetVersion()
        {
            return "V2.1";
        }

        public bool isVaild(string url)
        {
            Regex regex = new Regex(@"http://www.youku.com/playlist_show/id_[^S]*.html");
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

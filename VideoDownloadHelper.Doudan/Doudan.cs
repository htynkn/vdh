using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Addins;
using NSoup.Select;
using NSoup.Nodes;
using NSoup;
using System.Net;


[assembly: Addin]
[assembly: AddinDependency("VideoDownloadHelper", "1.6")]

namespace VideoDownloadHelper.Doudan
{

    [Extension]
    public class Doudan : IPlugin
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
            if (url.StartsWith("http://www.tudou.com/playlist/id/"))
            {
                this.Url = url;
                return true;
            }
            else if (url.StartsWith("http://www.tudou.com/playlist/id") && url.EndsWith(".html"))
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
            Elements items = doc.Select("div[class=pack pack_video_card]");
            foreach (Element item in items)
            {
                Element e1 = item.Select("h1[class=caption] a").First;
                Element e2 = item.Select("ul[class=info]").First;
                String title = e1.Attr("title");
                String url = e1.Attr("href");
                String time = e2.Select("li").First.OwnText().Substring("时长:".Length);
                String upOwner = e2.Select("li a").First.Attr("title");
                String key = url.Substring(url.LastIndexOf("/") + 1);
                key = key.Remove(key.IndexOf("."));

                BaseItem b = new BaseItem() { Url = "http://www.tudou.com/programs/view/" + key + "/", Name = title, Time = time, Owner = upOwner };

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
            String iid = WordHelper.CutWordByKeyword(target, "iid:", ",").Trim();
            return "tudou://" + iid + "/";
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

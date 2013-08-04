using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSoup.Nodes;
using NSoup.Select;
using NSoup;
using Mono.Addins;
using System.Data;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using RestSharp;

[assembly: Addin]
[assembly: AddinDependency("VideoDownloadHelper", "1.9")]

namespace VideoDownloadHelper.TudouAlbum
{
    [Extension]
    public class TudouAlbum : IPlugin
    {

        public int GetVersionNumber()
        {
            return 5;
        }

        public string GetVersion()
        {
            return "V3.0";
        }

        public bool isVaild(string url)
        {
            Regex regex = new Regex(@"(http://www.tudou.com/albumcover/)([^s]*)(.html)");
            Match m = regex.Match(url);
            if (m.Success)
            {
                this.key = m.Groups[2].Value;
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

            String pageUrl = String.Format("http://www.tudou.com/albumplay/{0}", this.key);
            String temp = WebHelper.GetHtmlCodeByWebClientWithGzip(pageUrl, "gbk");
            Document doc = NSoupClient.Parse(temp);
            String script = doc.Select("body>script").First.Html();
            Match aidMatch=Regex.Match(script,@",aid=(\d*)");
            String aid=aidMatch.Groups[1].Value;

            RestClient rc = new RestClient();
            var request=new RestRequest("http://www.tudou.com/tvp/alist.action?a={aid}");
            request.AddUrlSegment("aid", aid);
            ItemList dataItems = JsonConvert.DeserializeObject<ItemList>(rc.Execute(request).Content);
            foreach (Item item in dataItems.items)
            {
                this.items.Add(new BaseItem() { Time = item.time, Name = item.kw, Url = item.iid, Owner = "官方" });
            }

            return this.Items;
        }

        private String key;

        public String Down(int index)
        {
            return "tudou://" + this.items[index].Url + ":st=2/";
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

        public string Aid
        {
            get
            {
                return this.aid;
            }
            set
            {
                this.aid = value;
            }
        }

        private String aid;
    }

    public class ItemList
    {
        public List<Item> items;
    }

    public class Item
    {
        public String iid;
        public String kw;
        public String time;
    }
}

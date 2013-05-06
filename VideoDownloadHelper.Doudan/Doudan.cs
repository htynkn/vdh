using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Addins;
using NSoup.Select;
using NSoup.Nodes;
using NSoup;
using System.Net;
using System.Text.RegularExpressions;
using RestSharp;
using VideoDownloadHelper.Toudan;
using Newtonsoft.Json;


[assembly: Addin]
[assembly: AddinDependency("VideoDownloadHelper", "1.8")]

namespace VideoDownloadHelper.Doudan
{

    [Extension]
    public class Doudan : IPlugin
    {
        public int GetVersionNumber()
        {
            return 4;
        }

        public string GetVersion()
        {
            return "V1.3";
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
            else if (url.StartsWith("http://www.tudou.com/plcover/"))
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

            Regex r1 = new Regex(@"var lid = '\d+';");
            Match m1 = r1.Match(doc.Html());
            Regex r2 = new Regex(@"\d+");
            String lid = r2.Match(m1.ToString()).ToString();
            String baseUrl = "plcover/coverPage/getIndexItems.html?lid={id}&page=1&pageSize=500";

            var request = new RestRequest(baseUrl, RestSharp.Method.GET);
            request.AddUrlSegment("id", lid);
            RestClient rc = new RestClient("http://www.tudou.com/");
            DataItem dataItems = JsonConvert.DeserializeObject<DataItem>(rc.Execute(request).Content);

            List<DoudanItem> items = dataItems.message.items;
            foreach (DoudanItem d in items)
            {
                //这里的Url实际上是lid
                this.Items.Add(new BaseItem() { Name = d.title, Owner = d.ownerNickname, Time = d.time, Url = d.itemId });
            }

            return this.Items;
        }

        public String Down(int index)
        {
            String iid = this.Items[index].Url;
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

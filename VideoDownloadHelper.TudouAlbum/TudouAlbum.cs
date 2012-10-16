﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSoup.Nodes;
using NSoup.Select;
using NSoup;
using Mono.Addins;
using System.Data;
using Newtonsoft.Json;

[assembly: Addin]
[assembly: AddinDependency("VideoDownloadHelper", "1.4")]

namespace VideoDownloadHelper.TudouAlbum
{
    [Extension]
    public class TudouAlbum : IPlugin
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
            if (url.StartsWith("http://www.tudou.com/albumcover/") && url.EndsWith(".html"))
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
            lists = null;

            String temp = WebHelper.GetHtmlCodeByWebClientWithGzip(this.Url, "gbk");
            if (String.IsNullOrEmpty(temp))
            {
                temp = WebHelper.GetHtmlCodeByWebClient(this.Url, "gbk");
            }
            Document doc = NSoupClient.Parse(temp);
            Element et = doc.Select("div#playItems").First;
            Elements list = et.Select("div.pack_video_card>div.txt a");

            Element scripts = doc.Select("script")[2];
            this.Aid = WordHelper.CutWordByKeyword(scripts.Html(), "aid: \'", "\',");

            foreach (Element item in list)
            {
                String url = item.Attr("href");
                String title = item.Attr("title");
                BaseItem b = new BaseItem() { Name = title, Url = url, Time = "未知", Owner = "官方" };

                this.Items.Add(b);
            }

            return this.Items;
        }

        String defaultCode = String.Empty;
        List<ItemDown> lists;

        public void Down(int index)
        {
            if (lists == null)
            {
                String targetUrl=String.Format("http://www.tudou.com/tva/srv/alist.action?app=4&a={0}",this.Aid);
                String temp = WebHelper.GetHtmlCodeByWebClientWithGzip(targetUrl, "gbk");
                
                lists = JsonConvert.DeserializeObject<List<ItemDown>>(temp);
            }

            String[] targets = this.Items[index].Url.Split('/');
            String code = defaultCode;
            if (targets.Length == 6)
            {
                code = targets[5].Remove(targets[5].LastIndexOf(".")).ToLower();
            }

            foreach (ItemDown down in lists)
            {
                if (code.Equals(down.icode))
                {
                    System.Diagnostics.Process.Start("tudou://"+down.iid);
                    break;
                }
            }
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

    public class ItemDown
    {
        private String _icode;
        private String characterlist;

        public String icode
        {
            get { return _icode; }
            set { _icode = value.ToLower(); }
        }
        public String iid;
    }
}

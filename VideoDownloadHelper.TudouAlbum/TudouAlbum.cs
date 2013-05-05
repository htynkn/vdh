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

[assembly: Addin]
[assembly: AddinDependency("VideoDownloadHelper", "1.7")]

namespace VideoDownloadHelper.TudouAlbum
{
    [Extension]
    public class TudouAlbum : IPlugin
    {

        public int GetVersionNumber()
        {
            return 4;
        }

        public string GetVersion()
        {
            return "V2.1";
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

            Elements list = new Elements();
            Elements ets = doc.Select("div.playitems");

            foreach (Element et in ets)
            {
                if (et.Select("textarea.lazyContent").Count > 0)
                {
                    throw new Exception("暂时不支持这种网址");
                }

                Elements tempList = et.Select("div.pack_video_card>div.txt a");
                list.AddRange(tempList);
            }

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

        ItemList lists;

        public String Down(int index)
        {
            if (lists == null)
            {
                String targetUrl = String.Format("http://www.tudou.com/tva/srv/alist.action?app=4&a={0}", this.Aid);
                String temp = WebHelper.GetHtmlCodeByWebClient(targetUrl, "UTF-8");
                lists = JsonConvert.DeserializeObject<ItemList>(temp);
            }

            String code = String.Empty;
            if (index == 0)
            {
                code = lists.items[0].icode;
            }
            else
            {
                String url = this.Items[index].Url;
                String[] tempCode = url.Split('/');
                code = tempCode[tempCode.Length - 1];
                if (code.Contains("html"))
                {
                    code = code.Split('.')[0];
                }
            }
            foreach (Item item in lists.items)
            {
                if (code.Equals(item.icode))
                {
                    return "tudou://" + item.iid + ":st=2/";
                }
            }
            return String.Empty;
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
        public String updatedIid;
    }

    public class Item
    {
        public String iid;
        public String acode;
        public String icode;
    }
}

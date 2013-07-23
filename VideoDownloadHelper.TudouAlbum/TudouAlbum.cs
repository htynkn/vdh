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
            if (m.Success&&m.Groups.Count==4)
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

            String jsonUrl = "http://www.tudou.com/tvp/alist.action?jsoncallback=__TVP_alist&a={0}";

            return this.Items;
        }

        private String key;

        public String Down(int index)
        {
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

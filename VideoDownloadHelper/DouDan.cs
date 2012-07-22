using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using NSoup.Nodes;
using NSoup;
using NSoup.Select;

namespace VideoDownloadHelper
{
    public class DouDan
    {
        private string url;

        public string Url
        {
            get { return url; }
            set
            {
                if (value.Trim().IndexOf("http://www.tudou.com/playlist/playindex.do?lid=") == 0)
                {
                    if (value.Contains("&iid="))
                    {
                        url = "http://www.tudou.com/playlist/id/" + WordHelper.CutWordByKeyword(value, "http://www.tudou.com/playlist/playindex.do?lid=", "&iid=");
                    }
                    else
                    {
                        url = "http://www.tudou.com/playlist/id/" + value.Substring(47);
                    }
                }
                else if (value.Trim().IndexOf("http://www.tudou.com/playlist/p/l") == 0 && value.Length > 33)
                {
                    url = "http://www.tudou.com/playlist/id/" + WordHelper.CutWordByKeyword(value, "http://www.tudou.com/playlist/p/l", ".html");
                }
                else
                {
                    url = value;
                }
            }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private int videoNum;

        public int VideoNum
        {
            get { return videoNum; }
            set { videoNum = value; }
        }

        public DouDan(string url)
        {
            this.Url = url;
        }
        public DouDan(string url, string title, int videoNum)
        {
            this.Url = url;
            this.Title = title;
            this.VideoNum = videoNum;
        }

        private DouDanType danType;

        public DouDanType DanType
        {
            get
            {
                return danType;
            }
            set { danType = value; }
        }

        public bool isLegal()
        {
            if (Url.IndexOf("http://www.tudou.com/playlist/id") == 0)
            {
                danType = DouDanType.SimpleDouDan;
                return true;
            }
            else if (url.IndexOf("http://www.tudou.com/playlist/album/id") == 0)
            {
                danType = DouDanType.OfficeDouDan;
                return true;
            }
            else if (url.StartsWith("http://www.tudou.com/home/"))
            {
                danType = DouDanType.UserHome;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isLegal(string url)
        {
            return new DouDan(url).isLegal();
        }

        public List<TudouUrl> GetAllTudouUrl()
        {
            String temp = WebHelper.GetHtmlCodeByWebClientWithGzip(this.url, "gbk");
            return GetAllTudouUrl(temp);
        }

        public List<TudouUrl> GetAllTudouUrl(string temp)
        {
            switch (this.danType)
            {
                case DouDanType.UserHome:
                    return GetAllTudouUrlByHome(temp);
                case DouDanType.SimpleDouDan:
                    return GetAllTudouUrlBySimpleDouDan(temp);
                default:
                    return GetAllTudouUrlByOfficeDouDan(temp);
            }
        }

        private List<TudouUrl> GetAllTudouUrlByHome(string temp)
        {
            List<TudouUrl> tds = new List<TudouUrl>();
            Document doc = NSoupClient.Parse(temp);
            Elements items = doc.Select("div[class=showcase]").First.Select("div[class=item]");
            foreach (Element item in items)
            {
                Element item1 = item.Select("h1[class=caption] a").First;
                String title = item1.Attr("title");
                String url = item1.Attr("href");
                Element item2 = item.Select("ul[class=info] li").First;
                String time = item2.OwnText();
                TudouUrl td = new TudouUrl(url, title, time, "未知");
                tds.Add(td);
            }
            return tds;
        }

        private List<TudouUrl> GetAllTudouUrlByOfficeDouDan(String temp)
        {
            List<TudouUrl> tds = new List<TudouUrl>();
            Document doc = NSoupClient.Parse(temp);
            Elements items = doc.Select("div[class=pack pack_video_card]");
            foreach (Element item in items)
            {
                Element e1 = item.Select("div[class=pic] a").First;
                Element e2 = e1.Select("span[class=vinf]").First;
                String title = e1.Attr("title");
                String url = e1.Attr("href");
                String time = e2.Select("li").First.OwnText().Substring("时长:".Length);
                String upOwner = e2.Select("li a").First.Attr("title");
                tds.Add(new TudouUrl(url, title, time, upOwner));
            }
            return tds;
        }

        private List<TudouUrl> GetAllTudouUrlBySimpleDouDan(string temp)
        {
            List<TudouUrl> tds = new List<TudouUrl>();
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
                tds.Add(new TudouUrl(url, title, time, upOwner));
            }
            return tds;
        }

        public static List<DouDan> GetDouDan(string htmlCode)
        {
            List<DouDan> douDanList = new List<DouDan>();
            if (htmlCode.Contains("<div class=\"notfound\">"))
            {

            }
            else
            {
                string temp = WordHelper.CutWordByKeyword(htmlCode, "<ul class=\"list list_2\">", "<div class=\"search_cate\">");
                string[] templist = WordHelper.GetWords(temp, "<li class=\"item\">", "<div class=\"extra\">");
                for (int i = 0; i < templist.Length; i++)
                {
                    temp = templist[i];
                    douDanList.Add(new DouDan(
                        WordHelper.CutWordByKeyword(temp, "<a href=\"", "\" target=\"new\""),
                        WordHelper.CutWordByKeyword(temp, "target=\"new\" title=\"", "\""),
                        int.Parse(WordHelper.CutWordByKeyword(temp, "视频数:", "</p></div>"))));
                }
            }
            return douDanList;
        }
    }
}
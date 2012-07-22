using System;
using System.Collections.Generic;
using System.Text;
using NSoup.Nodes;
using NSoup;

namespace VideoDownloadHelper
{
    public class TudouUrl
    {
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string upOwner;

        public string UpOwner
        {
            get { return upOwner; }
            set { upOwner = value; }
        }

        private string videoTime;

        public string VideoTime
        {
            get { return videoTime; }
            set { videoTime = value; }
        }

        public TudouUrl(string Url, string Title, string VideoTime, string UpOwner)
        {
            this.Url = Url;
            this.Title = Title;
            this.VideoTime = VideoTime;
            this.UpOwner = UpOwner;
        }
        public string GetDownNumber()
        {
            string temp = this.Url;
            temp = WordHelper.CutWordByKeyword(temp, "playlist");
            return WordHelper.CutWordByKeyword(temp, "i", ".html");
        }
        public void Down()
        {
            if (url.IndexOf("playlist") > 0 && url.IndexOf("i") > 0)
            {
                System.Diagnostics.Process.Start("tudou://" + this.GetDownNumber());
            }
            else
            {
                String temp = WebHelper.GetHtmlCodeByWebClientWithGzip(url, "gbk");
                Document doc = NSoupClient.Parse(temp);
                Element et = doc.Select("body script").First;
                String tempp = et.OuterHtml();
                String[] temppp = tempp.Split(',');
                String number = "";
                foreach (String item in temppp)
                {
                    if (item.StartsWith("iid"))
                    {
                        number = item.Substring(item.IndexOf("=") + 1).Trim();
                        break;
                    }
                }
                System.Diagnostics.Process.Start("tudou://" +number);
            }
        }
    }
}

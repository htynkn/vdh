using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoDownloadHelper
{
    public class BaseItem
    {
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String url;

        public String Url
        {
            get { return url; }
            set { url = value; }
        }

        private String time;

        public String Time
        {
            get { return time; }
            set { time = value; }
        }

        private String owner;

        public String Owner
        {
            get { return owner; }
            set { owner = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace VideoDownloadHelper.Helper
{
    public class Askform
    {
        private static Askform instance = null;
        private String title;

        private String fromGuide;

        public String FromGuide
        {
            get { return fromGuide; }
            set { fromGuide = value; }
        }
        private int formType;

        public int FormType
        {
            get { return formType; }
            set { formType = value; }
        }

        public static void init(String guide,int type)
        {
            if (instance == null)
            {
                instance = new Askform();
            }
            instance.FromGuide = guide;
            instance.FormType = type;
        }

        public static String post(String title, String content)
        {
            RestClient rc = new RestClient("http://app.askform.cn");
            RestRequest request = new RestRequest("{guide}.aspx?Type={type}");
            request.AddUrlSegment("guide", instance.FromGuide);
            request.AddUrlSegment("type", instance.FormType.ToString());
            request.AddParameter("Survey.F77960001-2", title);
            request.AddParameter("Survey.F77960001-3", content);
            request.AddParameter("Survey_duration", "0");
            IRestResponse respone= rc.Post(request);
            return respone.StatusCode.ToString();
        }

        private Askform()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace VideoDownloadHelper
{
    public class ProgramHelper
    {
        public static int number = 8; //1.6版本

        public static String CheckFiles(String[] names)
        {
            StringBuilder sb = new StringBuilder();
            String ss = Directory.GetCurrentDirectory();
            String[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            Boolean isHave = false;
            foreach (String name in names)
            {
                foreach (String file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (fileInfo.Name.Equals(name))
                    {
                        isHave = true;
                        break;
                    }
                }
                if (!isHave)
                {
                    sb.Append(" 没有找到文件" + name);
                }
                isHave = false;
            }

            return sb.ToString();
        }

        public static String UpdateCheck()
        {
            StringBuilder sb = new StringBuilder();

            String url = "http://htynkn.github.com/vdh/program/update.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);
            XmlNode root = xmlDoc.SelectSingleNode("update");
            XmlNode node1 = root.SelectSingleNode("version");
            sb.Append(node1.FirstChild.Value).Append(",");
            XmlNode node2 = root.SelectSingleNode("number");
            sb.Append(node2.FirstChild.Value).Append(",");
            XmlNode node3 = root.SelectSingleNode("description");
            sb.Append(node3.FirstChild.Value).Append(",");
            XmlNode node4 = root.SelectSingleNode("downlink");
            sb.Append(node4.FirstChild.Value);
            return sb.ToString();
        }
    }
}

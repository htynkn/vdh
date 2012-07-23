using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.Compression;

namespace VideoDownloadHelper
{
    public class WebHelper
    {
        /// <summary>
        /// 通过WebClient获取网页源代码
        /// </summary>
        /// <param name="Url">对象网址</param>
        /// <returns>网页源代码（自动分析字符集，无乱码问题）</returns>
        public static string GetHtmlCodeByWebClient(string url)
        {
            WebClient wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            byte[] dataBuffer = wc.DownloadData(url);
            string strWebData = Encoding.Default.GetString(dataBuffer);
            Match charSetMatch = Regex.Match(strWebData, "<meta([^<]*)charset=([^<]*)\"", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string webCharSet = charSetMatch.Groups[2].Value;
            strWebData = Encoding.GetEncoding(webCharSet).GetString(dataBuffer);
            return strWebData;
        }

        public static string GetHtmlCodeByWebClient(string url, string encoding)
        {
            WebClient wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            wc.Headers.Add("Accept-Language", "zh-cn,zh;q=0.5");
            wc.Headers.Add("Accept-Charset", "GB2312,utf-8;q=0.7,*;q=0.7");
            wc.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
            byte[] dataBuffer = wc.DownloadData(url);
            string strWebData = Encoding.GetEncoding(encoding).GetString(dataBuffer);
            strWebData = Encoding.GetEncoding(encoding).GetString(dataBuffer);
            return strWebData;
        }

        public static string GetHtmlCodeByWebRequest(string url, string encoding)
        {
            string temp = "";
            WebRequest request = WebRequest.Create(url); //WebRequest.Create方法，返回WebRequest的子类HttpWebRequest
            WebResponse response = request.GetResponse(); //WebRequest.GetResponse方法，返回对 Internet 请求的响应
            using (Stream resStream = response.GetResponseStream()) //WebResponse.GetResponseStream 方法，从 Internet 资源返回数据流。 
            {
                Encoding enc = Encoding.GetEncoding(encoding); // 如果是乱码就改成 utf-8 / GB2312
                using (StreamReader sr = new StreamReader(resStream, enc)) //命名空间:System.IO。 StreamReader 类实现一个 TextReader (TextReader类，表示可读取连续字符系列的读取器)，使其以一种特定的编码从字节流中读取字符。 
                {
                    temp = sr.ReadToEnd(); //输出(HTML代码)，ContentHtml为Multiline模式的TextBox控件
                    resStream.Close();
                    sr.Close();
                }
            }
            return temp;
        }

        public static string GetHtmlCodeByWebClientWithGzip(string url, string encoding)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("Accept", "application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5");
            wc.Headers.Add("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");
            wc.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            wc.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            wc.Headers.Add("Cache-Control", "max-age=0");
            String temp = "";
            try
            {
                using (MemoryStream ms = new MemoryStream(wc.DownloadData(url)))
                {
                    using (GZipStream zipStream = new GZipStream(ms, CompressionMode.Decompress))
                    {
                        using (StreamReader sr = new StreamReader(zipStream, Encoding.GetEncoding(encoding)))
                        {
                            temp = sr.ReadToEnd();
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return temp;
        }


        /// <summary>
        /// 下载文件到本地
        /// </summary>
        /// <param name="url">远端文件地址</param>
        /// <param name="localPath">本地保存路径</param>
        /// <returns>是否下载成功</returns>
        public static bool DownFileFromWeb(string url, string localPath)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string FileName = "temp" + new Random().Next(1, 99);
                    client.DownloadFile(url, FileName);
                    File.Move(FileName, localPath);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static String GetUrl(String url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            webRequest.AllowAutoRedirect = false;
            HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
            return httpWebResponse.Headers.Get("Location") == null ? url : httpWebResponse.Headers.Get("Location");
        }
    }
}

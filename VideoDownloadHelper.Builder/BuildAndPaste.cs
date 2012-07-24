using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace VideoDownloadHelper.Builder
{
    [TestFixture]
    public class BuildAndPaste
    {
        [Test]
        public void Start()
        {
            //Type t = typeof(IPlugin);
            //String location = t.Assembly.Location;
            //location = location.Remove(location.LastIndexOf("\\") + 1);
            String location = @"D:\我的资料库\Documents\Visual Studio 2010\Projects\tyvdh\VideoDownloadHelper\bin\Release\plugsins\";
            String location2 = @"D:\我的资料库\Documents\Visual Studio 2010\Projects\tyvdh\VideoDownloadHelper\bin\Debug\plugsins\";

            if (!Directory.Exists(location))
            {
                Directory.CreateDirectory(location);
            }
            if (!Directory.Exists(location2))
            {
                Directory.CreateDirectory(location2);
            }

            Console.WriteLine("目标位置 : {0}", location);

            Type[] types = new Type[] { typeof(VideoDownloadHelper.Doudan.Doudan),typeof(VideoDownloadHelper.TudouUserHome.TudouUserHome),typeof(VideoDownloadHelper.TudouAlbum.TudouAlbum),typeof(VideoDownloadHelper.YoukuAlbum.YoukuAlbum),typeof(VideoDownloadHelper.YoukuUserHome.YoukuUserHome)};
            foreach (Type type in types)
            {
                String targetPath = location + type.FullName + ".dll";
                String targetPath2 = location2 + type.FullName + ".dll";
               
                File.Copy(type.Assembly.Location, targetPath, true) ;
                Console.WriteLine("复制文件 {0} 到 {1}", type.Name + ".dll", targetPath);
                File.Copy(type.Assembly.Location, targetPath2, true);
                Console.WriteLine("复制文件 {0} 到 {1}", type.Name + ".dll", targetPath2);
            }
        }
    }
}

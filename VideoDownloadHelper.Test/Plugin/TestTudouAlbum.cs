using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace VideoDownloadHelper.Test.Plugin
{
    [TestFixture]
    public class TestTudouAlbum : ITest
    {
        IPlugin plugin;
        String[] urls = new String[] { "http://www.tudou.com/albumcover/fmxHfffw_Tc.html", "http://www.tudou.com/albumcover/ZjwXrvQ7k8U.html", "http://www.tudou.com/albumcover/Wr4ODPduQFs.html" };
        Boolean[] table = new Boolean[] { true, true,true };
        int[] count = new int[] { 16, 52, 38 };
        String[] down = new String[] { "tudou://150556869/", "tudou://50968420/", "tudou://130672983/" };

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            plugin = new VideoDownloadHelper.TudouAlbum.TudouAlbum();
        }

        [Test]
        public void TestGetVersionNumber()
        {
            Assert.AreEqual(3, plugin.GetVersionNumber());
        }
        [Test]
        public void TestGetVersion()
        {
            Assert.AreEqual("V2.0", plugin.GetVersion());
        }
        [Test]
        public void TestisVaild()
        {
            for(int i=0;i<urls.Length;i++)
            {
                Assert.AreEqual(table[i],plugin.isVaild(urls[i]));
            }
        }

        [Test]
        public void TestGetList()
        {
            for (int i = 0; i < urls.Length; i++)
            {
                plugin.isVaild(urls[i]);
                Assert.AreEqual(count[i], plugin.GetList().Count);
            }
        }

        [Test]
        public void TestDown()
        {
            for (int i = 0; i < urls.Length; i++)
            {
                plugin.isVaild(urls[i]);
                plugin.GetList();
                Assert.AreEqual(down[i], plugin.Down(0));
            }
        }
    }
}

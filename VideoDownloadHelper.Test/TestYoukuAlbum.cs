using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace VideoDownloadHelper.Test
{
    [TestFixture]
    public class TestYoukuAlbum : ITest
    {
        IPlugin plugin = new VideoDownloadHelper.YoukuAlbum.YoukuAlbum();
        String testUrl="http://www.youku.com/playlist_show/id_2256623.html";

        [Test]
        public void TestGetVersionNumber()
        {
            Assert.AreEqual(1, plugin.GetVersionNumber());
        }

        [Test]
        public void TestGetVersion()
        {
            Assert.AreEqual("V1.0", plugin.GetVersion());
        }

        [Test]
        public void TestisVaild()
        {
            Assert.True(plugin.isVaild(testUrl));
        }

        [Test]
        public void TestGetList()
        {
            plugin.isVaild(testUrl);
            List<BaseItem> list = plugin.GetList();
            Assert.AreEqual(20, list.Count);
        }

        [Test]
        public void TestDown()
        {
            plugin.isVaild(testUrl);
            plugin.GetList();
            plugin.Down(0);
        }
    }
}

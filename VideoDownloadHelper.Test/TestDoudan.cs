using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using VideoDownloadHelper.Doudan;

namespace VideoDownloadHelper.Test
{
    [TestFixture]
    public class TestDoudan : ITest
    {
        IPlugin plugin = new VideoDownloadHelper.Doudan.Doudan();

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
            Assert.False(plugin.isVaild("http://www.tudou.com/playlist/id/15838950/"));
            Assert.True(plugin.isVaild("http://www.tudou.com/playlist/id/15202966/"));
            Assert.False(plugin.isVaild("http://www.tudou.com/listplay/9tJnMUC-hyE.html"));
        }

        [Test]
        public void TestGetList()
        {
            plugin.isVaild("http://www.tudou.com/playlist/id/15202966/");
            List<BaseItem> items = plugin.GetList();
            Assert.AreEqual(20, items.Count);
        }

        [Test]
        public void TestDown()
        {
            int i = 1;
            plugin.isVaild("http://www.tudou.com/playlist/id/15202966/");
            plugin.GetList();
            plugin.Down(i);
        }
    }
}

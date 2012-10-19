using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace VideoDownloadHelper.Test
{
    [TestFixture]
    class TestYoukuUserHome2 : ITest
    {
        IPlugin plugin = new VideoDownloadHelper.YoukuUserHome2.YoukuUserHome2();
        String testUrl = "http://i.youku.com/u/UMTE0NDEzOTky/videos/order_1_view_1_page_2";

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
            Assert.AreEqual(20, plugin.GetList().Count);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace VideoDownloadHelper.Test.Plugin
{
    [TestFixture]
    public class TestYoukuUserHome : ITest
    {
        IPlugin plugin = new VideoDownloadHelper.YoukuUserHome.YoukuUserHome();
        String testUrl = "http://i.youku.com/u/UNjQxMDM2ODg=/videos";
        String downloadUrl = "iku://|video|http://v.youku.com/v_show/id_XMzc0NzkwNzYw.html|quality=flv|";

        [Test]
        public void TestGetVersionNumber()
        {
            Assert.AreEqual(4, plugin.GetVersionNumber());
        }

        [Test]
        public void TestGetVersion()
        {
            Assert.AreEqual("V2.0", plugin.GetVersion());
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
            Assert.AreEqual(downloadUrl, plugin.Down(0));
        }
    }
}

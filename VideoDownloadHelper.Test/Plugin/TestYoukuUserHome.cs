using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace VideoDownloadHelper.Test.Plugin
{
    [TestFixture]
    [Ignore("Unsupported")]
    public class TestYoukuUserHome : ITest
    {
        IPlugin plugin = new VideoDownloadHelper.YoukuUserHome.YoukuUserHome();
        String testUrl = "http://i.youku.com/u/UNjQxMDM2ODg=/videos";

        [Test]
        public void TestGetVersionNumber()
        {
            Assert.AreEqual(2, plugin.GetVersionNumber());
        }

        [Test]
        public void TestGetVersion()
        {
            Assert.AreEqual("V1.1", plugin.GetVersion());
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
            Assert.AreEqual(30, plugin.GetList().Count);
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

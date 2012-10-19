using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace VideoDownloadHelper.Test
{
    [TestFixture]
    public class TestYoukuUserHome : ITest
    {
        IPlugin plugin = new VideoDownloadHelper.YoukuUserHome.YoukuUserHome();
        String testUrl = "http://u.youku.com/user_video/id_UNjQxMDM2ODg=.html";

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

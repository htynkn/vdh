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

        [Test]
        public void TestGetVersionNumber()
        {
            Assert.AreEqual("1", plugin.GetVersionNumber());
        }

        [Test]
        public void TestGetVersion()
        {
            Assert.AreEqual("V1.0", plugin.GetVersion());
        }

        [Test]
        public void TestisVaild()
        {
            Assert.True(plugin.isVaild("http://u.youku.com/user_video/id_UMjQ1MzY3NzI=.html"));
        }

        [Test]
        public void TestGetList()
        {
            plugin.isVaild("http://u.youku.com/user_video/id_UMjc3NjMwMjA=.html");
            Assert.AreEqual(30, plugin.GetList().Count);
        }

        [Test]
        public void TestDown()
        {
            plugin.isVaild("http://u.youku.com/user_video/id_UMjc3NjMwMjA=.html");
            plugin.GetList();
            plugin.Down(0);
        }
    }
}

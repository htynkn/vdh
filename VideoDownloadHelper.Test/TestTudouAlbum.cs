using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace VideoDownloadHelper.Test
{
    [TestFixture]
    public class TestTudouAlbum : ITest
    {
        IPlugin plugin = new VideoDownloadHelper.TudouAlbum.TudouAlbum();
        String testUrl = "http://www.tudou.com/albumcover/ckyYccWvXOU.html";
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
            Assert.True(plugin.isVaild(testUrl));
        }

        [Test]
        public void TestGetList()
        {
            plugin.isVaild(testUrl);
            plugin.GetList();
            Assert.AreEqual(34, plugin.Items.Count);
        }

        [Test]
        public void TestDown()
        {
            plugin.isVaild(testUrl);
            plugin.GetList();
            plugin.Down(0);
            plugin.Down(2);
        }
    }
}

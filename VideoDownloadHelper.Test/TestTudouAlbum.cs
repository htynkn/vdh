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
            Assert.True(plugin.isVaild("http://www.tudou.com/albumcover/t1tzlUNNYo4.html"));
        }

        [Test]
        public void TestGetList()
        {
            plugin.isVaild("http://www.tudou.com/albumcover/t1tzlUNNYo4.html");
            plugin.GetList();
            Assert.AreEqual(84, plugin.Items.Count);

            plugin.isVaild("http://www.tudou.com/albumcover/rPbYLHD6a1U.html");
            plugin.GetList();
            Assert.AreEqual(5, plugin.Items.Count);
        }

        [Test]
        public void TestDown()
        {
            plugin.isVaild("http://www.tudou.com/albumcover/cghDyIIHl0M.html");
            plugin.GetList();
            plugin.Down(0);
        }
    }
}

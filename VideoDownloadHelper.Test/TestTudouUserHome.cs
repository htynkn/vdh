using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace VideoDownloadHelper.Test
{
    [TestFixture]
    public class TestTudouUserHome : ITest
    {
        IPlugin plugin = new VideoDownloadHelper.TudouUserHome.TudouUserHome();

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
            Assert.True(plugin.isVaild("http://www.tudou.com/home/item_u57808119s0p1.html"));
            Assert.True(plugin.isVaild("http://www.tudou.com/home/_53621156"));
        }

        [Test]
        public void TestGetList()
        {
            plugin.isVaild("http://www.tudou.com/home/item_u36343961s0p1.html");
            List<BaseItem> list = plugin.GetList();
            Assert.AreEqual(3, list.Count);

            plugin.isVaild("http://www.tudou.com/home/_53621156");
            list = plugin.GetList();
            Assert.AreEqual(40, list.Count);
        }

        [Test]
        public void TestDown()
        {
            plugin.isVaild("http://www.tudou.com/home/item_u36343961s0p1.html");
            List<BaseItem> list = plugin.GetList();
            plugin.Down(1);
        }
    }
}

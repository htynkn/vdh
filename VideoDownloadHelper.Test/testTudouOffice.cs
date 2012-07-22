using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using VideoDownloadHelper.Modal;

namespace VideoDownloadHelper.Test
{
    [TestFixture]
    public class TestTudouOffice
    {
        String tudouOffice = "http://www.tudou.com/playlist/album/id65393.html";
        [Test]
        [Category("列表测试")]
        public void GetInfos()
        {
            BaseList items = ListFactory.Create(tudouOffice);
            items.GetInfos();
            Assert.AreEqual(35, items.Items.Count);
            BaseItem item = items.Items[0];
            item.GetInfo();
            Assert.AreEqual("74623299", item.DownNumber);
            Assert.AreEqual("42:40", item.Time);
        }
    }
}

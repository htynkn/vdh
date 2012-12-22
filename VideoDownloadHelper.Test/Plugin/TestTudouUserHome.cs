using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace VideoDownloadHelper.Test
{
    [TestFixture]
    public class TestTudouUserHome : BaseTest
    {
        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            this.plugin = new VideoDownloadHelper.TudouUserHome.TudouUserHome();
            this.urls = new String[] { "http://www.tudou.com/home/_100308093/", "http://www.tudou.com/home/item_u100308093s0p1.html", "http://www.tudou.com/home/item_u107309431s0p1.html" };
            this.table = new Boolean[] { true, true, true };
            this.count = new int[] { 40, 40, 6 };
            this.down = new String[] { "tudou://154349629/", "tudou://154349629/", "tudou://125557837/" };
        }

        [Test]
        public void TestGetVersionNumber()
        {
            base.TestGetVersionNumber(1);
        }

        [Test]
        public void TestGetVersion()
        {
            base.TestGetVersion("V1.0");
        }

        [Test]
        public override void TestisVaild()
        {
            base.TestisVaild();
        }

        [Test]
        public override void TestGetList()
        {
            base.TestGetList();
        }

        [Test]
        public override void TestDown()
        {
            base.TestDown();
        }
    }
}

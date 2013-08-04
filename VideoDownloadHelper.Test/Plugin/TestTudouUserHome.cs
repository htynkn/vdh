using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace VideoDownloadHelper.Test.Plugin
{
    [TestFixture]
    public class TestTudouUserHome : BaseTest
    {
        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            this.plugin = new VideoDownloadHelper.TudouUserHome.TudouUserHome();
            this.urls = new String[] { "http://www.tudou.com/home/item_u100308093s0p1.html", "http://www.tudou.com/home/item_u107309431s0p1.html" };
            this.table = new Boolean[] { true, true };
            this.count = new int[] { 40, 6 };
            this.down = new String[] { "tudou://154349629:st=2/", "tudou://125557837:st=2/" };
        }

        [Test]
        public void TestGetVersionNumber()
        {
            base.TestGetVersionNumber(3);
        }

        [Test]
        public void TestGetVersion()
        {
            base.TestGetVersion("V1.2");
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

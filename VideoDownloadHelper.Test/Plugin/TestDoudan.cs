using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using VideoDownloadHelper.Doudan;

namespace VideoDownloadHelper.Test.Plugin
{
    [TestFixture]
    public class TestDoudan : BaseTest
    {
        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            this.plugin = new VideoDownloadHelper.Doudan.Doudan();
            this.urls = new String[] { "http://www.tudou.com/playlist/id9009493.html", "http://www.tudou.com/playlist/id15444955.html", "http://www.tudou.com/playlist/id2151855.html" };
            this.table = new Boolean[] { true, true, true };
            this.count = new int[] { 24, 13, 76 };
            this.down = new String[] { "tudou://57410380:st=2/", "tudou://66971981:st=2/", "tudou://11755195:st=2/" };
        }

        [Test]
        public void TestGetVersionNumber()
        {
            base.TestGetVersionNumber(4);
        }

        [Test]
        public void TestGetVersion()
        {
            base.TestGetVersion("V1.3");
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

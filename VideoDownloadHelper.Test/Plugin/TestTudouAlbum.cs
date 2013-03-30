using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace VideoDownloadHelper.Test.Plugin
{
    [TestFixture]
    public class TestTudouAlbum : BaseTest
    {
        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            this.plugin = new VideoDownloadHelper.TudouAlbum.TudouAlbum();
            this.urls = new String[] { "http://www.tudou.com/albumcover/fmxHfffw_Tc.html" };
            this.table = new Boolean[] { true };
            this.count = new int[] { 16};
            this.down = new String[] { "tudou://150556869/"};
        }

        [Test]
        public void TestGetVersionNumber()
        {
            base.TestGetVersionNumber(3);
        }

        [Test]
        public void TestGetVersion()
        {
            base.TestGetVersion("V2.0");
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

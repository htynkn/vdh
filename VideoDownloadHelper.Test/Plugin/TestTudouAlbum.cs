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
            this.urls = new String[] { "http://www.tudou.com/albumcover/R8LfDvjvHXE.html" };
            this.table = new Boolean[] { true };
            this.count = new int[] { 366};
            this.down = new String[] { "tudou://130613503:st=2/" };
        }

        [Test]
        public void TestGetVersionNumber()
        {
            base.TestGetVersionNumber(5);
        }

        [Test]
        public void TestGetVersion()
        {
            base.TestGetVersion("V3.0");
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

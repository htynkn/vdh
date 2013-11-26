using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace VideoDownloadHelper.Test.Plugin
{
    [TestFixture]
    public class TestYoukuAlbum : BaseTest
    {
        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            this.plugin = new VideoDownloadHelper.YoukuAlbum.YoukuAlbum();
            this.urls = new String[] { "http://www.youku.com/playlist_show/id_2256623.html", "http://www.youku.com/playlist_show/id_3136914_page_2_ascending_1_mode_pic.html" };
            this.table = new Boolean[] { true,true};
            this.count = new int[] { 20,20 };
            this.down = new String[] { "iku://|video|http://v.youku.com/v_show/id_XMjQyODk0MA==.html|quality=flv|", "iku://|video|http://v.youku.com/v_show/id_XMzMyODI4NA==.html|quality=flv|" };
        }

        [Test]
        public void TestGetVersionNumber()
        {
            base.TestGetVersionNumber(3);
        }

        [Test]
        public void TestGetVersion()
        {
            base.TestGetVersion("V2.1");
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

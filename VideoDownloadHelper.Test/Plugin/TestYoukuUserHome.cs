using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace VideoDownloadHelper.Test.Plugin
{
    [TestFixture]
    public class TestYoukuUserHome : BaseTest
    {
        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            this.plugin = new VideoDownloadHelper.YoukuUserHome.YoukuUserHome();
            this.urls = new String[] { "http://i.youku.com/u/UNjQxMDM2ODg=/videos"};
            this.table = new Boolean[] { true };
            this.count = new int[] { 20 };
            this.down = new String[] { "iku://|video|http://v.youku.com/v_show/id_XMzc0NzkwNzYw.html|quality=flv|" };
        }

        [Test]
        public void TestGetVersionNumber()
        {
            base.TestGetVersionNumber(5);
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

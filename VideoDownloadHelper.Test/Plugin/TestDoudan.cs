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
            this.urls = new String[] { "http://www.tudou.com/listplay/Ry9axJ8HziA.html", "http://www.tudou.com/listplay/9g0AN7WqbuA.html", "http://www.tudou.com/listplay/SjzQteQQYAw.html" };
            this.table = new Boolean[] { true, true, true };
            this.count = new int[] { 24, 13, 76 };
            this.down = new String[] { "tudou://150556869/", "tudou://50968420/", "tudou://130672983/" };
        }

        [Test]
        public void TestGetVersionNumber()
        {
            base.TestGetVersionNumber(2);
        }

        [Test]
        public void TestGetVersion()
        {
            base.TestGetVersion("V1.1");
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

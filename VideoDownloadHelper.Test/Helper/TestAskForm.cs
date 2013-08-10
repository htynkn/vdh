using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using VideoDownloadHelper.Helper;

namespace VideoDownloadHelper.Test.Helper
{
    [TestFixture]
    public class TestAskForm
    {
        [Test]
        public void TestPost()
        {
            Askform.init("78e62f00-4fd5-49f0-ab06-7becd28250e7", 2);
            Assert.AreEqual("OK", Askform.post("test", "test2"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using VideoDownloadHelper.Helper;

namespace VideoDownloadHelper.Test
{
    [TestFixture]
    public class TestProgramHelper
    {
        [Test]
        public void TestUpdateCheck()
        {
            String s = ProgramHelper.UpdateCheck();
            String[] temp = s.Split(',');
            Assert.AreEqual(4, temp.Length);
        }
    }
}

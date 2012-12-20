using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace VideoDownloadHelper.Test
{
    public class BaseTest
    {
        protected IPlugin plugin;
        protected String[] urls;
        protected Boolean[] table;
        protected int[] count;
        protected String[] down;

        public virtual void TestFixtureSetUp()
        {
        }

        public virtual void TestDown()
        {
            for (int i = 0; i < urls.Length; i++)
            {
                plugin.isVaild(urls[i]);
                plugin.GetList();
                Assert.AreEqual(down[i], plugin.Down(0));
            }
        }

        public virtual void TestGetList()
        {
            for (int i = 0; i < urls.Length; i++)
            {
                plugin.isVaild(urls[i]);
                Assert.AreEqual(count[i], plugin.GetList().Count);
            }
        }

        public virtual void TestisVaild()
        {
            for (int i = 0; i < urls.Length; i++)
            {
                Assert.AreEqual(table[i], plugin.isVaild(urls[i]));
            }
        }

        public void TestGetVersion(String version)
        {
            Assert.AreEqual(version, plugin.GetVersion());
        }

        public void TestGetVersionNumber(int versionNumber)
        {
            Assert.AreEqual(versionNumber, plugin.GetVersionNumber());
        }
    }
}

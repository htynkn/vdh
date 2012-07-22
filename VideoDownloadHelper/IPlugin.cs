using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Addins;

namespace VideoDownloadHelper
{
    [TypeExtensionPoint]
    public interface IPlugin
    {
        int GetVersionNumber();
        String GetVersion();
        bool isVaild(String url);
        List<BaseItem> GetList();
        void Down(int index);

        List<BaseItem> Items { get; set; }
        String Url { get; set; }
    }
}

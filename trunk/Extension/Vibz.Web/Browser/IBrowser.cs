using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Vibz.Web.Browser
{
    public interface IBrowser
    {
        void Init(bool showBrowser);
        void LoadUrl(string url, int maxWait);
        void Init(Uri url, string htmlSource);
        
        Dictionary<string, string> PageHeaders { get; }
        int DownloadAllImages(string absPath, string relPath);
        IWebDocument Document { get; }
        
    }
}

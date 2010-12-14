using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Globalization;
using System.Threading;

namespace Vibz.Studio.LangResource
{
    public class TextManager
    {
        static TextManager _lang = null;
        ResourceManager ResourceSet = null;
        static object _padLock = new object();
        TextManager()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["culture"]);
            ResourceSet = new ResourceManager("Vibz.Studio.LangResource.Text", this.GetType().Assembly);
        }
        static TextManager Manager
        {
            get {
                if (_lang == null)
                {
                    lock (_padLock)
                    {
                        if (_lang == null)
                        {
                            _lang = new TextManager();
                        }
                    }
                }
                return _lang;
            }
        }
        public static string GetString(string key)
        {
            try
            {
                return Manager.ResourceSet.GetString(key, Thread.CurrentThread.CurrentUICulture);
            }
            catch (Exception exc)
            {
                return "";
            }
        }
    }
}

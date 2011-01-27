/*
*	Copyright © 2011, The Vibzworld Team
*	All rights reserved.
*	http://code.google.com/p/vauto/
*	
*	Redistribution and use in source and binary forms, with or without
*	modification, are permitted provided that the following conditions
*	are met:
*	
*	- Redistributions of source code must retain the above copyright
*	notice, this list of conditions and the following disclaimer.
*	
*	- Neither the name of the Vibzworld Team, nor the names of its
*	contributors may be used to endorse or promote products
*	derived from this software without specific prior written
*	permission.
*/
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

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
using Vibz.Web.Browser.Collection;
using Vibz.Helper;
//using System.Data;
using Vibz.Contract.Data;
namespace Vibz.Web.Browser
{
    public enum LocatorType { XPath, AttributeValue, ID }
    public interface IWebDocument
    {
        //Progress Progress { get; }
        URLList RedirectLinks { get; }
        Dictionary<string, string> ImageLinks { get; }
        Vibz.Web.Browser.Collection.ImageList Images { get; }
        string SourceCode { get;}
        string[] JSLinks { get; }
        string GetFirstInnerText(string xpath);
        string[] GetAllInnerText(string xpath);
        string GetFirstAttribute(string attrxpath);
        string GetFirstAttribute(string xpath, string attributeName);
        string[] GetAllAttributes(string xpath, string attributeName);
        DataTable GetTableContent(string repeaterXPath, Dictionary<string, string> offsetXPath);

        void Click(string locator);
        void WaitForPageLoad(int maxWait, bool exceptionOnTimeout);
        void Type(string locator, string value);
        void Check(string locator);
        void UnCheck(string locator);
        void SelectOption(string locator, string optionText);
        void DoubleClick(string locator);
        void KeyPress(string locator, char c);
        void MouseOver(string locator);
        void TypeIntoFileUpload(string locator, string value);
        void WaitForControlLoad(string locator, int maxWait);
        void WaitForTextLoad(string text, int maxWait);
        void WaitForControlEnable(string locator, int maxWait);
        void DragAndDrop(string sourceLocator, string destinationLocator);
        void FireEvent(string locator, string eventName);
        void Focus(string locator);
        void GoBack(int maxWait);
        void Close();
        void OpenWindow(string url, int maxWait);
        void Navigate(string url, int maxWait);
        void Refresh(int maxWait);
        void SelectFrame(string frameLocator);
        void SelectWindow(string windowId);

        Dictionary<string, string> GetAttributes(string locator);
		int GetElementIndex(string locator);
		string GetLocation();
		string GetInnerText(string locator);
        string GetTitle();
		string GetValue(string locator);

        bool IsExists(string locator);
		bool IsChecked(string locator);
        bool IsTextPresent(string text);
		bool IsEditable(string locator);
		bool IsEnabled(string locator);
		bool IsVisible(string locator);
    }
}

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

namespace Vibz.Contract.Data
{
    public class DataCollection : List<Var>, ICompile
    {
        public const string nData = "data";
        public bool ContainsData(string datakey)
        {
            foreach (Var dm in this)
            {
                if (dm.Name == datakey)
                    return true;
            }
            return false;
        }
        public void Add(Var dMember)
        {
            if (this.ContainsData(dMember.Name))
                throw new Exception("Data with name '" + dMember.Name + "' has already been initialised.");
            base.Add(dMember);
        }
        public void Add(string name, IData value)
        {
            if (value.Source.ToLower() == Vibz.Contract.Data.Source.SourceType.Internal.ToString().ToLower()
                && value.Type.ToLower() == Vibz.Contract.Data.DataType.None.ToString().ToLower())
            {
                object val = value.GetValue();
                if (val != null && val.GetType() == typeof(String) && val.ToString().StartsWith("@") && this.ContainsData(val.ToString().Substring(1)))
                {
                    Var v = this.Get(val.ToString().Substring(1));
                    this.Add(new Var(name, v));
                    return;
                }
            }
            this.Add(new Var(name, value));
        }
        public void Add(string name, IData value, string path, string innerText)
        {
            this.Add(new Var(path, name, value, innerText));
        }
        public void Update(Var dMember)
        {
            foreach (Var dm in this)
            {
                if (dm.Name == dMember.Name)
                {
                    int index = this.IndexOf(dm);
                    this.RemoveAt(index);
                    this.Insert(index, dMember);
                    return;
                }
            }
            Add(dMember);
        }
        public void Update(string name, IData data)
        {
            foreach (Var dm in this)
            {
                if (dm.Name == name)
                {
                    dm.Data = data;
                    dm.Source = data.Source;
                    dm.Type = data.Type;
                    return;
                }
            }
            throw new Exception("Data '" + name + "' not present in the data list.");
        }
        public void AddOrUpdate(string name, IData data)
        {
            foreach (Var dm in this)
            {
                if (dm.Name == name)
                {
                    this.Remove(dm);
                    break;
                }
            }
            this.Add(name, data);
        }
        public void Update(string name, IData data, string path)
        {
            foreach (Var dm in this)
            {
                if (dm.Name == name)
                {
                    dm.Data = data;
                    dm._filePath = path;
                    return;
                }
            }
            throw new Exception("Data '" + name + "' not present in the data list.");
        }
        public Var Get(string name)
        {
            foreach (Var dm in this)
            {
                if (dm.Name == name)
                {
                    if (dm.PointerTo != null)
                        return dm.PointerTo;
                    return dm;
                }
            }
            throw new Exception("Data '" + name + "' not present in the data list.");
        }
        public Var TryGet(string name)
        {
            foreach (Var dm in this)
            {
                if (dm.Name == name)
                {
                    if (dm.PointerTo != null)
                        return dm.PointerTo;
                    return dm;
                }
            }
            return null;
        }
        public void Merge(DataCollection dset)
        {
            foreach (Var dm in dset)
            {
                if (this.ContainsData(dm.Name))
                    throw new Exception("Multiple occurances of identifier '" + dm.Name + "'. [Files: '" + dm._filePath + "' and '" + this.Get(dm.Name)._filePath + "'");
                this.Add(dm);
            }
        }
        public string SetPrefix(string value, string prefix)
        {
            foreach (Var dm in this)
            {
                if (value.Contains("@" + dm.Name))
                {
                    value = value.Replace("@" + dm.Name, "@" + prefix + "_" + dm.Name);
                }
            }
            return value;
        }
        public string GetCompiledText()
        {
            return GetCompiledText("");
        }
        public string GetCompiledText(string prefix)
        {
            if (this == null || this.Count == 0)
                return "";
            string retValue = "<" + nData + ">";
            string innerText = "";
            foreach (Var dm in this)
            {
                innerText += dm.GetCompiledText(prefix);
            }
            if (innerText == "")
                return "";
            retValue += innerText;
            retValue += "</" + nData + ">";
            return retValue;
        }
        
    }
}

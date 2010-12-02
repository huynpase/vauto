using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract.Data
{
    public class DataCollection : List<Variable>, ICompile
    {
        public const string nData = "data";
        public bool ContainsData(string datakey)
        {
            foreach (Variable dm in this)
            {
                if (dm.Name == datakey)
                    return true;
            }
            return false;
        }
        public void Add(Variable dMember)
        {
            if (this.ContainsData(dMember.Name))
                throw new Exception("Data with name '" + dMember.Name + "' has already been initialised.");
            base.Add(dMember);
        }
        public void Add(string name, IData value, string path, string innerText)
        {
            this.Add(new Variable(path, name, value, innerText));
        }
        public void Update(Variable dMember)
        {
            foreach (Variable dm in this)
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
            foreach (Variable dm in this)
            {
                if (dm.Name == name)
                {
                    dm.Data = data;
                    return;
                }
            }
            throw new Exception("Data '" + name + "' not present in the data list.");
        }
        public void Update(string name, IData data, string path)
        {
            foreach (Variable dm in this)
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
        public Variable Get(string name)
        {
            foreach (Variable dm in this)
            {
                if (dm.Name == name)
                {
                    return dm;
                }
            }
            throw new Exception("Data '" + name + "' not present in the data list.");
        }
        public Variable TryGet(string name)
        {
            foreach (Variable dm in this)
            {
                if (dm.Name == name)
                    return dm;
            }
            return null;
        }
        public void Merge(DataCollection dset)
        {
            foreach (Variable dm in dset)
            {
                if (this.ContainsData(dm.Name))
                    throw new Exception("Multiple occurances of identifier '" + dm.Name + "'. [Files: '" + dm._filePath + "' and '" + this.Get(dm.Name)._filePath + "'");
                this.Add(dm);
            }
        }
        public string GetCompiledText()
        {
            if (this == null || this.Count == 0)
                return "";
            string retValue = "<" + nData + ">";
            string innerText = "";
            foreach (Variable dm in this)
            {
                innerText += dm.GetCompiledText();
            }
            if (innerText == "")
                return "";
            retValue += innerText;
            retValue += "</" + nData + ">";
            return retValue;
        }
        
    }
}

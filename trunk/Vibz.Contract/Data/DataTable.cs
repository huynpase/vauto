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
using System.Data;

namespace Vibz.Contract.Data
{
    public class DataTable : IData
    {
        protected System.Data.DataTable Value = new System.Data.DataTable();

        public DataTable()
            : this(new System.Data.DataTable())
        { }
        public DataTable(System.Data.DataTable value)
        { Value = value; }

        public string Type
        { get { return DataType.DataTable.ToString(); } }

        public virtual string Source
        { get { return Vibz.Contract.Data.Source.SourceType.Internal.ToString(); } }

        public object GetValue() { return Value; }

        public virtual string Evaluate(params object[] args)
        {
            if (!ValidateValue)
                throw new Exception("Data is not initialized.");
            
            if (args.Length < 1)
                throw new Exception("Data in data-table must be accessed through a numeric index.");
            
            if (args.Length > 2)
                throw new Exception("More than two index found. Data in data-table should be accessed with two index only.");
            
            int index1 = -1;
            try
            {
                index1 = Convert.ToInt32(args.GetValue(0));
            }
            catch (Exception exc)
            {
                throw new Exception("Data in Data-table must be accessed through a numeric index.");            
            }

            if (index1 >= this.Value.Rows.Count)
                throw new Exception("Data-table row index out of range.");
            
            int index2 = -1;
            try
            {
                index2 = Convert.ToInt32(args.GetValue(1));
            }
            catch (Exception exc)
            {
                throw new Exception("Data in Data-table must be accessed through a numeric index.");            
            }
            if (index2 >= this.Value.Rows[index1].ItemArray.Length)
                throw new Exception("Data-table column index out of range.");

            return this.Value.Rows[index1].ItemArray.GetValue(index2).ToString();
        }
        public virtual string Evaluate(string property)
        {
            if (!ValidateValue)
                throw new Exception("Data is not initialized.");
            
            switch (property.ToLower())
            {
                case "length":
                case "rowcount":
                    return this.Value.Rows.Count.ToString();
                case "colcount":
                case "columncount":
                    return this.Value.Columns.Count.ToString();
                default:
                    throw new Exception("Invalid property '" + property + "' for Data-table data type.");
            }
        }
        public virtual string Evaluate(string method, params object[] args)
        {
            if (!ValidateValue)
                throw new Exception("Data is not initialized.");

            switch (method.ToLower())
            {
                case "addrow":
                    string[] data = new string[args.Length];
                    args.CopyTo(data, 0);
                    AddRow(data);
                    break;
                default:
                    throw new Exception("Invalid method '" + method + "' for datatable data type.");
            }
            return "";
        }
        bool ValidateValue
        {
            get
            {
                if (this.Value == null)
                    return false;
                return true;
            }
        }
        public void AddRow(params string[] rowValues)
        {
            if (rowValues.Length > this.Columns.Count)
            {
                for (int i = this.Columns.Count; i < rowValues.Length; i++)
                {
                    this.Columns.Add("Data" + i.ToString());
                }
            }
            System.Data.DataRow dr = this.RowTemplate;
            for (int i = 0; i < rowValues.Length; i++)
            {
                dr[i] = rowValues[i];
            }
            this.Rows.Add(dr);
        }
        #region DataTable members
        public System.Data.DataRow RowTemplate
        {
            get
            {
                return Value.NewRow();
            }
        }
        public System.Data.DataRowCollection Rows
        {
            get
            {
                return Value.Rows;
            }
        }
        public System.Data.DataColumnCollection Columns
        {
            get
            {
                return Value.Columns;
            }
        }
        public override string ToString()
        {
            return "DataTable- Rows:" + Value.Rows.Count.ToString() + ", Columns: " + Value.Columns.Count.ToString();
        } 
        #endregion
    }
}

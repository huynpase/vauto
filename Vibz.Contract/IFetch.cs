using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract.Data;
namespace Vibz.Contract
{
    public interface IFetch
    {
        string Output { get; set; }
        IData Fetch(DataHandler vList);
    }
}

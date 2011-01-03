using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using Vibz.Solution.Element;
using Vibz.Contract.Attribute;
using Vibz.Studio.Document.XDoc;

namespace Vibz.Studio.Document
{
    public partial class IdentifierDocument : ElementDocument
    {
        public IdentifierDocument()
            : base("")
        { }
        public IdentifierDocument(string filePath)
            : base(filePath)
        { }

        public override void Document_DragDrop(object sender, DragEventArgs e)
        {
            //TODO: Handle Control ID drag even
        }
        public override void Document_DragEnter(object sender, DragEventArgs e)
        {
            //TODO: Handle Control ID drag even
            //if (e.Data.GetDataPresent(typeof(FunctionTypeInfo)))
            //    e.Effect = DragDropEffects.Move;
            //else
                e.Effect = DragDropEffects.None;
        }
    }
}
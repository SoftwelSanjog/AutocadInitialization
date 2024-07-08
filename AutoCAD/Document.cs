using Autodesk.AutoCAD.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Schema;

namespace AutoCADWrapper
{
    public class Document
    {
        private AcadDocument acadDocument;
        public object Name
        {
            get
            {
                return acadDocument.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, acadDocument, null);
            }
        }
        public AcadDocument GetDocumentObject()
        {
            return acadDocument;
        }
        public void SetDocumentObject(object acadDoc)
        {
            acadDocument = (AcadDocument) acadDoc;
        }
        public object ActiveViewPort()
        {
            return acadDocument.ActiveViewport;
        }
        public object Layers()
        {
            return acadDocument.GetType().InvokeMember("Layers",BindingFlags.GetProperty, null, acadDocument, null);
        }
        public object ActiveLayer
        {
            get
            {
                return acadDocument.GetType().InvokeMember("ActiveLayer", BindingFlags.GetProperty, null, acadDocument, null);
            }
            set
            {
                acadDocument.GetType().InvokeMember("ActiveLayer",BindingFlags.SetProperty,null, acadDocument, new object[] { value });
            }
        }
        public object Blocks
        {
            get
            {
                return acadDocument.GetType().InvokeMember("Blocks",BindingFlags.GetProperty,null, acadDocument, null); 
            }
        }
        public ModelSpace ModelSpace()
        {
            ModelSpace mSpace = new ModelSpace();
            mSpace.setModelSpaceObject(acadDocument.GetType().InvokeMember("ModelSpace", BindingFlags.GetProperty, null, acadDocument, null));
            return mSpace;
        }

        public Utility Utility()
        {
            Utility mUtility = new Utility();
            mUtility.setUtilityObject(acadDocument.GetType().InvokeMember("Utility", BindingFlags.GetProperty, null, acadDocument, null));
            return mUtility;
        }

    }
}

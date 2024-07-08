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
                return InvokeAcadDocumentMethod("Name",BindingFlags.GetProperty,null);
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
            return InvokeAcadDocumentMethod("Layers",BindingFlags.GetProperty, null);
        }
        public object ActiveLayer
        {
            get
            {
                return InvokeAcadDocumentMethod("ActiveLayer", BindingFlags.GetProperty, null);
            }
            set
            {
               InvokeAcadDocumentMethod("ActiveLayer",BindingFlags.SetProperty, new object[] { value });
            }
        }
        public object Blocks
        {
            get
            {
                return InvokeAcadDocumentMethod("Blocks", BindingFlags.GetProperty, null); 
            }
        }
        public ModelSpace ModelSpace()
        {
            ModelSpace mSpace = new ModelSpace();
            mSpace.setModelSpaceObject(InvokeAcadDocumentMethod("ModelSpace", BindingFlags.GetProperty, null));
            return mSpace;
        }

        public Utility Utility()
        {
            Utility mUtility = new Utility();
            mUtility.setUtilityObject(InvokeAcadDocumentMethod("Utility", BindingFlags.GetProperty, null));
            return mUtility;
        }

        private object InvokeAcadDocumentMethod(string methodName, BindingFlags bindingFlags, object[] args)
        {
            return acadDocument.GetType().InvokeMember(methodName, bindingFlags,null,acadDocument, args);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Desktop.AddIns;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;

namespace IncrementalValue
{
    public class PlusVal : ESRI.ArcGIS.Desktop.AddIns.Tool
    {

        MyForm myForm = new MyForm();
        public PlusVal()
        {
            Enabled = false;
        }

        protected override void OnUpdate()
        {
            IEditor3 editor3 = GetEditorFromArcMap((IMxApplication)ArcMap.Application);

            if (editor3.EditState == esriEditState.esriStateEditing)
            {
                Enabled = true;
            }
            else
            {
                Enabled = false;
            }
            //Enabled = ArcMap.Application != null;
        }

        protected override void OnActivate()
        {
            myForm = new MyForm();
            myForm.Show();
        }

        protected override void OnMouseDown(MouseEventArgs arg)
        {
            IMxDocument pMxDoc = ArcMap.Document;
            IPoint pPoint = pMxDoc.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(arg.X, arg.Y);
            pPoint.SpatialReference = pMxDoc.FocusMap.SpatialReference;
            //if (pMxDoc.FocusMap.SpatialReference is IProjectedCoordinateSystem)
            //{
            //    IProjectedCoordinateSystem pProjSR = (IProjectedCoordinateSystem)pMxDoc.FocusMap.SpatialReference;
            //    IGeographicCoordinateSystem pGeoSR = pProjSR.GeographicCoordinateSystem;
            //    pPoint.Project((ISpatialReference)pGeoSR);
            //}
            int newStartVal = int.Parse(myForm.startValue);
            int newIncremantalVal = int.Parse(myForm.incrementalValue);
            CreateFeature(myForm.featureClass, pPoint, myForm.layerFieldName, newStartVal);
            myForm.startValue = (newStartVal + newIncremantalVal).ToString();
            pMxDoc.ActiveView.Refresh();
        }


        public static void CreateFeature(IFeatureClass featureClass, IPoint point, string fieldName, int putVal)
        {
            // Build the feature.
            IFeature feature = featureClass.CreateFeature();
            feature.Shape = point;

            // Update the value on a string field that indicates who installed the feature.
            int insertFieldIndex = featureClass.FindField(fieldName);
            feature.set_Value(insertFieldIndex, putVal);
            
            // Commit the new feature to the geodatabase.
            feature.Store();
        }

        #region"Get Editor from ArcMap"
        // ArcGIS Snippet Title:
        // Get Editor from ArcMap
        // 
        // Long Description:
        // Returns a reference to the ESRI editor object.
        // 
        // Add the following references to the project:
        // ESRI.ArcGIS.ArcMapUI
        // ESRI.ArcGIS.Editor
        // ESRI.ArcGIS.Framework
        // ESRI.ArcGIS.System
        // 
        // Intended ArcGIS Products for this snippet:
        // ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
        // 
        // Applicable ArcGIS Product Versions:
        // 9.2
        // 9.3
        // 9.3.1
        // 10.0
        // 
        // Required ArcGIS Extensions:
        // (NONE)
        // 
        // Notes:
        // This snippet is intended to be inserted at the base level of a Class.
        // It is not intended to be nested within an existing Method.
        // 

        ///<summary>Returns a reference to the ESRI editor object.</summary>
        ///  
        ///<param name="mxApplication">An IMxApplication interface, ie. ArcMap.</param>
        ///   
        ///<returns>An IEditor2 interface, the ArcMap Editor.</returns>
        ///   
        ///<remarks>You could also use the: application.FindExtensionByName("ESRI Object Editor") to get the extension object.</remarks>
        public ESRI.ArcGIS.Editor.IEditor3 GetEditorFromArcMap(ESRI.ArcGIS.ArcMapUI.IMxApplication mxApplication)
        {
            if (mxApplication == null)
            {
                return null;
            }
            ESRI.ArcGIS.esriSystem.UID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
            uid.Value = "{F8842F20-BB23-11D0-802B-0000F8037368}";
            ESRI.ArcGIS.Framework.IApplication application = mxApplication as ESRI.ArcGIS.Framework.IApplication; // Dynamic Cast
            ESRI.ArcGIS.esriSystem.IExtension extension = application.FindExtensionByCLSID(uid);
            ESRI.ArcGIS.Editor.IEditor3 editor3 = extension as ESRI.ArcGIS.Editor.IEditor3; // Dynamic Cast

            return editor3;
        }
        #endregion
    }

}

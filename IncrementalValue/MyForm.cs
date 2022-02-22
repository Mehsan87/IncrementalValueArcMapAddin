using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Geodatabase;
using IncrementalValue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IncrementalValue
{
    public partial class MyForm : Form
    {
        public string layerFieldName;
        public string startValue;
        public string incrementalValue;

        public MyForm()
        {
            InitializeComponent();
            
        }

        private void MyForm_Load(object sender, EventArgs e)
        {
            IEditor3 editor3 = GetEditorFromArcMap((IMxApplication)ArcMap.Application);
            IFields fields = GetFieldsFromCreateFeatureTemplate(editor3);
            comboBox1Layer.Items.Clear();
            if (fields != null)
            {
                for (int i = 0; i < fields.FieldCount; i++)
                {

                    IField field = fields.get_Field(i);
                    if (field.Editable && !(field.Type == esriFieldType.esriFieldTypeGeometry))
                    {
                        comboBox1Layer.Items.Add(field.Name);
                    }
                }

            }
        }

        #region "Get Fields From Create Feature Template"
        ///<summary>Returns a reference to the ESRI editor object.</summary>
        ///  
        ///<param name="editor3">An IMxApplication interface, ie. ArcMap.</param>
        ///   
        ///<returns>An IFields interface, the ArcMap Editor.</returns>
        public IFields GetFieldsFromCreateFeatureTemplate(IEditor3 editor3)
        {
            IEditTemplate currentEditTemplate = editor3.CurrentTemplate;
            if (currentEditTemplate != null)
            {
                ILayer2 layer = (ILayer2)currentEditTemplate.Layer;
                IFeatureLayer featureLayer = (IFeatureLayer)layer;
                IFeatureClass featureClass = featureLayer.FeatureClass;
                IFields fields = featureClass.Fields;
                return fields;
            }
            else
            {
                return null;
            }
            

        }
        #endregion

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

        private void button1Go_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1Layer.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                return;
            }
            this.layerFieldName = comboBox1Layer.SelectedItem.ToString();
            this.startValue = textBox1.Text.ToString();
            this.incrementalValue = textBox2.Text.ToString();
            this.Hide();
        }
    }
}

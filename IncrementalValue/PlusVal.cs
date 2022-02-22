using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace IncrementalValue
{
    public class PlusVal : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        public PlusVal()
        {
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}

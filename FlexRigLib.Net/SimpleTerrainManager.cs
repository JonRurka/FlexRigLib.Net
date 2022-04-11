using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net
{
    public class SimpleTerrainManager :TerrainManager_Base
    {
        [DllImport(Settings.DLL)]
        private static extern IntPtr SimpleTerrainManager_New();

        [DllImport(Settings.DLL)]
        private static extern IntPtr SimpleTerrainManager_New(IntPtr col);

        public SimpleTerrainManager()
        {
            SetHandle(SimpleTerrainManager_New());
        }

        public SimpleTerrainManager(Collisions_Base col)
        {
            SetHandle(SimpleTerrainManager_New(col.GetHandle()));
        }
    }
}

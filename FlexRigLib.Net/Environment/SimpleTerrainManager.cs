using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using FlexRigLib.Net.Physics.Collision;

namespace FlexRigLib.Net.Environment
{
    public class SimpleTerrainManager :TerrainManager_Base
    {
        [DllImport(Settings.DLL)]
        private static extern IntPtr SimpleTerrainManager_New();

        [DllImport(Settings.DLL)]
        private static extern IntPtr SimpleTerrainManager_New(IntPtr col);

        [DllImport(Settings.DLL)]
        private static extern void SimpleTerrainManager_setGroundHeight(IntPtr handle, float height);

        public SimpleTerrainManager()
            : base(SimpleTerrainManager_New())
        {
        }

        public SimpleTerrainManager(Collisions_Base col)
            : base(SimpleTerrainManager_New(col.GetHandle()))
        {
        }
    
        public void SetGroundHeight(float val)
        {
            SimpleTerrainManager_setGroundHeight(handle, val);
        }
    }
}

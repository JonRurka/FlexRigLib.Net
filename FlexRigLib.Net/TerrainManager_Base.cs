using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net
{
    public class TerrainManager_Base
    {
        [DllImport(Settings.DLL)]
        private static extern IntPtr TerrainManager_Base_GetCollisions(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern void TerrainManager_Base_SetCollisions(IntPtr handle, IntPtr col);

        protected IntPtr handle;

        public TerrainManager_Base(IntPtr hdl)
        {
            handle = hdl;
        }

        protected void SetHandle(IntPtr hdl)
        {
            handle = hdl;
        }

        public IntPtr GetHandle()
        {
            return handle;
        }

        public Collisions_Base GetCollisions()
        {
            return new Collisions_Base(TerrainManager_Base_GetCollisions(handle));
        }

        void SetCollisions(Collisions_Base col)
        {
            TerrainManager_Base_SetCollisions(handle, col.GetHandle());
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using FlexRigLib.Net.Physics.Collision;
using FlexRigLib.Net.Utilities;

namespace FlexRigLib.Net.Environment
{
    public class TerrainManager_Base : NativeObject
    {
        [DllImport(Settings.DLL)]
        private static extern void TerrainManager_Base_getTerrainName(IntPtr handle, StringBuilder sb, int size);

        [DllImport(Settings.DLL)]
        private static extern IntPtr TerrainManager_Base_GetCollisions(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern void TerrainManager_Base_SetCollisions(IntPtr handle, IntPtr col);

        [DllImport(Settings.DLL)]
        private static extern void TerrainManager_Base_setGravity(IntPtr handle, float x, float y, float z);

        [DllImport(Settings.DLL)]
        private static extern Vec3 TerrainManager_Base_getGravity(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern float TerrainManager_Base_GetHeightAt(IntPtr handle, float x, float z);

        [DllImport(Settings.DLL)]
        private static extern Vec3 TerrainManager_Base_GetNormalAt(IntPtr handle, float x, float y, float z);

        [DllImport(Settings.DLL)]
        private static extern Vec3 TerrainManager_Base_getMaxTerrainSize(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern IntPtr TerrainManager_Base_getTerrainCollisionAAB(IntPtr handle);


        protected TerrainManager_Base(IntPtr hdl)
            : base(hdl)
        {
        }

        public static TerrainManager_Base GetBaseInstance(IntPtr hdl)
        {
            return new TerrainManager_Base(hdl);
        }

        public string GetTerrainName()
        {
            const int cap = 100;
            StringBuilder sb = new StringBuilder(cap);
            TerrainManager_Base_getTerrainName(handle, sb, cap);
            return sb.ToString();
        }

        public Collisions_Base GetCollisions()
        {
            return Collisions_Base.GetBaseInstance(TerrainManager_Base_GetCollisions(handle));
        }

        public void SetCollisions(Collisions_Base col)
        {
            TerrainManager_Base_SetCollisions(handle, col);
        }

        public void setGravity(float y)
        {
            setGravity(0, y, 0);
        }

        public void setGravity(float x, float y, float z)
        {
            TerrainManager_Base_setGravity(handle, x, y, z);
        }

        public Vec3 getGravity()
        {
            return TerrainManager_Base_getGravity(handle);
        }

        public float GetHeightAt(float x, float z)
        {
            return TerrainManager_Base_GetHeightAt(handle, x, z);
        }

        public Vec3 GetNormalAt(float x, float y, float z)
        {
            return TerrainManager_Base_GetNormalAt(handle, x, y, z);
        }

        public Vec3 GetMaxTerrainSize()
        {
            return TerrainManager_Base_getMaxTerrainSize(handle);
        }

        public AxisAlignedBox GetTerrainCollisionAAB()
        {
            return new AxisAlignedBox(TerrainManager_Base_getTerrainCollisionAAB(handle));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net.Utilities
{
    public class AxisAlignedBox : NativeObject
    {
        [DllImport(Settings.DLL)]
        private static extern Vec3 AxisAlignedBox_getMinimum(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern Vec3 AxisAlignedBox_getMaximum(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern Vec3 AxisAlignedBox_getSize(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern Vec3 AxisAlignedBox_getCorner(IntPtr handle, int cornerToGet);

        [DllImport(Settings.DLL)]
        private static extern bool AxisAlignedBox_contains(IntPtr handle, Vec3 v);

        public enum Extent
        {
            EXTENT_NULL,
            EXTENT_FINITE,
            EXTENT_INFINITE
        };

        public enum CornerEnum
        {
            FAR_LEFT_BOTTOM = 0,
            FAR_LEFT_TOP = 1,
            FAR_RIGHT_TOP = 2,
            FAR_RIGHT_BOTTOM = 3,
            NEAR_RIGHT_BOTTOM = 7,
            NEAR_LEFT_BOTTOM = 6,
            NEAR_LEFT_TOP = 5,
            NEAR_RIGHT_TOP = 4
        };

        public Vec3 Minimum
        {
            get
            {
                return AxisAlignedBox_getMinimum(handle);
            }
        }

        public Vec3 Maximum
        {
            get
            {
                return AxisAlignedBox_getMaximum(handle);
            }
        }

        public Vec3 Size
        {
            get
            {
                return AxisAlignedBox_getSize(handle);
            }
        }

        public AxisAlignedBox(IntPtr hdl)
            :base(hdl)
        {
        }

        public Vec3 GetCorner(CornerEnum cornerToGet)
        {
            return AxisAlignedBox_getCorner(handle, (int)cornerToGet);
        }

        public bool Contains(Vec3 v)
        {
            return AxisAlignedBox_contains(handle, v);
        }

    }
}

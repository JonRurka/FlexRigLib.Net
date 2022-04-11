using System;
using System.Collections.Generic;
using System.Text;

namespace FlexRigLib.Net
{
    public class AxisAlignedBox : NativeObject
    {


        public enum Extent
        {
            EXTENT_NULL,
            EXTENT_FINITE,
            EXTENT_INFINITE
        };

        enum CornerEnum
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

        public AxisAlignedBox(IntPtr hdl)
            :base(hdl)
        {
        }



    }
}

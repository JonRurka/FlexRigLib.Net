using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net
{
    public class Collisions_Base
    {
        protected IntPtr handle;


        public Collisions_Base(IntPtr hdl)
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
    }
}

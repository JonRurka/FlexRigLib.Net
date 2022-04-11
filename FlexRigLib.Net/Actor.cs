using System;
using System.Collections.Generic;
using System.Text;

namespace FlexRigLib.Net
{
    public class Actor
    {
        private IntPtr handle;

        public Actor(IntPtr hdl)
        {
            handle = hdl;
        }

        public IntPtr GetHandle()
        {
            return handle;
        }
    }
}

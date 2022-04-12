using System;
using System.Collections.Generic;
using System.Text;

namespace FlexRigLib.Net
{
    public class NativeObject : IEquatable<NativeObject>
    {
        protected IntPtr handle;

        public NativeObject(IntPtr hdl)
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

        public bool Equals(NativeObject other)
        {
            return handle.Equals(other.handle);
        }

        public static implicit operator IntPtr(NativeObject orig)
        {
            return orig.GetHandle();
        }
    }
}

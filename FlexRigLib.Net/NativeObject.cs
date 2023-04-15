using System;
using System.Collections.Generic;
using System.Text;

namespace FlexRigLib.Net
{
    public class NativeObject : IEquatable<NativeObject>
    {
        protected IntPtr handle;

        private static Dictionary<IntPtr, NativeObject> cache = new Dictionary<IntPtr, NativeObject>();

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

        public static T GetObject<T>(IntPtr handle, bool do_cache = true) where T : NativeObject
        {
            return (T)Activator.CreateInstance(typeof(T), handle);


            /*if (!do_cache)
                return (T)new NativeObject(handle);

            if (cache.ContainsKey(handle))
            {
                return (T)cache[handle];
            }

            NativeObject newActor = new NativeObject(handle);

            cache.Add(handle, newActor);

            return (T)newActor;*/
        }
    }
}

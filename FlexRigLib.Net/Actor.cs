using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net
{
    public class Actor : NativeObject
    {
        private static Dictionary<IntPtr, Actor> cache = new Dictionary<IntPtr, Actor>();

        public Actor(IntPtr hdl) : 
            base(hdl)
        {
        }



        public static Actor GetActor(IntPtr handle)
        {
            if (cache.ContainsKey(handle))
            {
                return cache[handle];
            }

            Actor newActor = new Actor(handle);

            cache.Add(handle, newActor);

            return newActor;
        }
    }
}

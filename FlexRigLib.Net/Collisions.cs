using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net
{
    public class Collisions : Collisions_Base
    {
        [DllImport(Settings.DLL)]
        private static extern IntPtr Collisions_New(float terrn_size_x, float terrn_size_y, float terrn_size_z);

        public Collisions(float terrn_size_x, float terrn_size_y, float terrn_size_z)
        {
            SetHandle(Collisions_New(terrn_size_x, terrn_size_y, terrn_size_z));
        }
    }
}

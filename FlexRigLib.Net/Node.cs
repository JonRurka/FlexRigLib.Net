using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net
{
    public class Node : NativeObject
    {
        [DllImport(Settings.DLL)]
        private static extern Vec3 node_t_getRelPosition(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern Vec3 node_t_getAbsPosition(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern Vec3 node_t_getVelocity(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern Vec3 node_t_getForces(IntPtr handle);



        public Vec3 RelPosition { get { return node_t_getRelPosition(handle); } }

        public Vec3 AbsPosition { get { return node_t_getAbsPosition(handle); } }

        public Vec3 Velocity { get { return node_t_getVelocity(handle); } }

        public Vec3 Forces { get { return node_t_getForces(handle); } }



        public Node(IntPtr hdl)
            :base(hdl)
        {
        }


    }
}

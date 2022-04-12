using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net
{
    public class Beam : NativeObject
    {
        [DllImport(Settings.DLL)]
        private static extern IntPtr beam_t_getP1(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern IntPtr beam_t_getP2(IntPtr handle);


        public Node P1 { get { return new Node(beam_t_getP1(handle)); } }

        public Node P2 { get { return new Node(beam_t_getP2(handle)); } }


        public Beam(IntPtr hdl) : 
            base(hdl)
        {
        }

    }
}

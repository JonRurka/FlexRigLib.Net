using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net.Physics
{
    public class Beam : NativeObject
    {
        [DllImport(Settings.DLL)]
        private static extern IntPtr Beam_t_getP1(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern IntPtr Beam_t_getP2(IntPtr handle);


        public Node P1 { get { return new Node(Actor, Beam_t_getP1(handle)); } }

        public Node P2 { get { return new Node(Actor, Beam_t_getP2(handle)); } }

        public Actor Actor { private set; get; }




        public Beam(Actor ac, IntPtr hdl) : 
            base(hdl)
        {
            Actor = ac;
        }

    }
}

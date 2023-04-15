using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using FlexRigLib.Net.Utilities;

namespace FlexRigLib.Net.Physics
{
    public class Node : NativeObject, IEquatable<Node>
    {
        [DllImport(Settings.DLL)]
        private static extern Vec3 Node_t_getRelPosition(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern Vec3 Node_t_getAbsPosition(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern Vec3 Node_t_getVelocity(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern Vec3 Node_t_getForces(IntPtr handle);


        [DllImport(Settings.DLL)]
        private static extern Vec3 Node_t_getRelPosition_idx(IntPtr actor_handle, int index);

        [DllImport(Settings.DLL)]
        private static extern Vec3 Node_t_getAbsPosition_idx(IntPtr actor_handle, int index);

        [DllImport(Settings.DLL)]
        private static extern Vec3 Node_t_getVelocity_idx(IntPtr actor_handle, int index);

        [DllImport(Settings.DLL)]
        private static extern Vec3 Node_t_getForces_idx(IntPtr actor_handle, int index);




        [DllImport(Settings.DLL)]
        private static extern void Node_t_setRelPosition(IntPtr handle, Vec3 pos);

        [DllImport(Settings.DLL)]
        private static extern void Node_t_setAbsPosition(IntPtr handle, Vec3 pos);

        [DllImport(Settings.DLL)]
        private static extern void Node_t_setVelocity(IntPtr handle, Vec3 vel);

        [DllImport(Settings.DLL)]
        private static extern void Node_t_setForces(IntPtr handle, Vec3 force);


        [DllImport(Settings.DLL)]
        private static extern void Node_t_setRelPosition_idx(IntPtr actor_handle, int index, Vec3 pos);

        [DllImport(Settings.DLL)]
        private static extern void Node_t_setAbsPosition_idx(IntPtr actor_handle, int index, Vec3 pos);

        [DllImport(Settings.DLL)]
        private static extern void Node_t_setVelocity_idx(IntPtr actor_handle, int index, Vec3 vel);

        [DllImport(Settings.DLL)]
        private static extern void Node_t_setForces_idx(IntPtr actor_handle, int index, Vec3 force);



        [DllImport(Settings.DLL)]
        private static extern int Node_t_getPosition(IntPtr handle);

        public Vec3 RelPosition { 
            get 
            { 
                if (byRef)
                    return Node_t_getRelPosition(handle);
                return Node_t_getRelPosition_idx(Actor, index);
            }
            set
            {
                if (byRef)
                    Node_t_setRelPosition(handle, value);
                Node_t_setRelPosition_idx(Actor, index, value);
            }
        }

        public Vec3 AbsPosition { 
            get 
            {
                if (byRef)
                    return Node_t_getAbsPosition(handle);
                return Node_t_getAbsPosition_idx(Actor, index);
            }
            set
            {
                if (byRef)
                    Node_t_setAbsPosition(handle, value);
                Node_t_setAbsPosition_idx(Actor, index, value);
            }
        }

        public Vec3 Velocity { 
            get 
            {
                if (byRef)
                    return Node_t_getVelocity(handle);
                return Node_t_getVelocity_idx(Actor, index);
            }
            set
            {
                if (byRef)
                    Node_t_setVelocity(handle, value);
                Node_t_setVelocity_idx(Actor, index, value);
            }
        }

        public Vec3 Forces { 
            get 
            {
                if (byRef)
                    return Node_t_getForces(handle);
                return Node_t_getForces_idx(Actor, index);
            }
            set
            {
                if (byRef)
                    Node_t_setForces(handle, value);
                Node_t_setForces_idx(Actor, index, value);
            }
        }

        public Actor Actor { private set; get; }

        public bool IsByRef { get { return byRef; } }

        public int Index { get
            {
                if (byRef)
                    return Node_t_getPosition(handle);
                return index;
            } 
        }

        private bool byRef;
        private int index;

        public Node(Actor ac, int indx)
            :base(default(IntPtr))
        {
            Actor = ac;
            index = indx;
            byRef = false;
        }

        public Node(Actor ac, IntPtr hdl)
            : base(hdl)
        {
            Actor = ac;
            byRef = true;
        }

        public Node ToRef()
        {
            if (byRef)
                return this;

            Node tmp = Actor.GetNodeReference(this);
            SetHandle(tmp.GetHandle());
            index = 0;
            byRef = true;

            return this;
        }

        public bool Equals(Node other)
        {
            if (byRef)
                return base.Equals(other);

            return Actor.Equals(other.Actor) && index == other.index;
        }
    
    
    }
}

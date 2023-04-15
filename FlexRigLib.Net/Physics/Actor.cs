using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using FlexRigLib.Net.Physics.Collision;
using FlexRigLib.Net.Utilities;

namespace FlexRigLib.Net.Physics
{
    public class Actor : NativeObject
    {
        [DllImport(Settings.DLL)]
        private static extern int Actor_getNumNodes(IntPtr handle);

        [DllImport(Settings.DLL, CallingConvention = CallingConvention.StdCall)]
        private static extern int Actor_GetNodes(IntPtr handle, [Out] IntPtr nodes);

        [DllImport(Settings.DLL)]
        private static extern int Actor_GetNumBeams(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern void Actor_GetBeams(IntPtr handle, out IntPtr[] beams);

        [DllImport(Settings.DLL)]
        private static extern IntPtr Actor_GetNodeRef(IntPtr handle, int index);

        [DllImport(Settings.DLL)]
        private static extern IntPtr Actor_GetBeamRef(IntPtr handle, int index);

        [DllImport(Settings.DLL)]
        private static extern IntPtr Actor_GetInter_point_col_detector(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern IntPtr Actor_GetIntra_point_col_detector(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern int Actor_GetNum_contactable_nodes(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern int Actor_GetNum_contacters(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern IntPtr Actor_GetBounding_Box(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern IntPtr Actor_GetPredicted_Bounding_Box(IntPtr handle);

        private static Dictionary<IntPtr, Actor> cache = new Dictionary<IntPtr, Actor>();

        public AxisAlignedBox Bounding_Box
        {
            get
            {
                return new AxisAlignedBox(Actor_GetBounding_Box(handle));
            }
        }

        public AxisAlignedBox Predicted_Bounding_Box
        {
            get
            {
                return new AxisAlignedBox(Actor_GetPredicted_Bounding_Box(handle));
            }
        }


        public Actor(IntPtr hdl) : 
            base(hdl)
        {
        }

        
    
        public int getNumNodes()
        {
            return Actor_getNumNodes(handle);
        }

        public int GetNumContactableNodes()
        {
            return Actor_GetNum_contactable_nodes(handle);
        }

        public int GetNumContacters()
        {
            return Actor_GetNum_contacters(handle);
        }

        public Node[] GetNodes(bool cache = true)
        {
            int numNodes = getNumNodes();
            Node[] nodes = new Node[numNodes];

            for (int i = 0; i < numNodes; i++)
            {
                nodes[i] = new Node(this, i);
            }

            return nodes;


            /*int numNodes = getNumNodes();
            IntPtr[] node_ptrs = new IntPtr[numNodes];
            Node[] nodes = new Node[numNodes];

            int size = Marshal.SizeOf(handle);

            Console.WriteLine("Getting {0} nodes at {1}", numNodes, size);

            IntPtr buffer = Marshal.AllocHGlobal(size * numNodes);
            int got = Actor_GetNodes(handle, buffer);

            Console.WriteLine("Got {0} nodes. was {1}", got, numNodes);


            Marshal.Copy(buffer, node_ptrs, 0, numNodes);
            Marshal.FreeHGlobal(buffer);

            for (int i = 0; i < numNodes; i++)
            {
                //Console.WriteLine("Node {0}: {1}", i, node_ptrs[i].);
                nodes[i] = new Node(this, node_ptrs[i]);
                Console.WriteLine(nodes[i].RelPosition.ToString());
            }

            

            return null;*/

        }

        public int GetNumBeams()
        {
            return Actor_GetNumBeams(handle);
        }

        public Beam[] GetBeams(bool cache = true)
        {
            int numBeams = GetNumBeams();
            Beam[] beams = new Beam[numBeams];

            for (int i = 0; i < numBeams; i++)
            {
                beams[i] = new Beam(this, Actor_GetBeamRef(handle, i));
            }

            return beams;



            /*IntPtr[] beam_ptrs = new IntPtr[GetNumBeams()];
            Actor_GetBeams(handle, out beam_ptrs);
            Beam[] beams = new Beam[beam_ptrs.Length];
            for (int i = 0; i < beams.Length; i++)
            {
                beams[i] = GetObject<Beam>(beam_ptrs[i], cache);
            }
            return beams;*/
        }

        public Node GetNodeReference(int index)
        {
            return new Node(this, Actor_GetNodeRef(handle, index));
        }

        public Node GetNodeReference(Node n)
        {
            return new Node(this, Actor_GetNodeRef(handle, n.Index));
        }

        public PointColDetector GetInter_point_col_detector()
        {
            return GetObject<PointColDetector>(Actor_GetInter_point_col_detector(handle));
        }

        public PointColDetector GetIntra_point_col_detector()
        {
            return GetObject<PointColDetector>(Actor_GetIntra_point_col_detector(handle));
        }
    }
}

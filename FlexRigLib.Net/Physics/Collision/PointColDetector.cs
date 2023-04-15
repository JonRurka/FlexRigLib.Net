using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using FlexRigLib.Net.Utilities;


namespace FlexRigLib.Net.Physics.Collision
{
    public class PointColDetector : NativeObject
    {
        const int MAX_HITS = 100;

        [DllImport(Settings.DLL)]
        private static extern IntPtr PointColDetector_New(IntPtr actor);

        //[DllImport(Settings.DLL)]
        //private static extern int PointColDetector_hit_list(IntPtr handle, out IntPtr[] list, int size);

        [DllImport(Settings.DLL)]
        private static extern int PointColDetector_hit_list(IntPtr handle, [Out] PointID[] list, int size);

        [DllImport(Settings.DLL)]
        public static extern int PointColDetector_numHits(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern void PointColDetector_UpdateIntraPoint(IntPtr handle, bool contactables = false);

        [DllImport(Settings.DLL)]
        private static extern void PointColDetector_UpdateInterPoint(IntPtr handle, bool ignorestate = false);

        [DllImport(Settings.DLL)]
        private static extern void PointColDetector_query(IntPtr handle, Vec3 vec1, Vec3 vec2, Vec3 vec3, float enlargeBB);

        [DllImport(Settings.DLL)]
        private static extern Vec3 PointColDetector_Get_bbmin(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern Vec3 PointColDetector_Get_bbmax(IntPtr handle);


        /*public class PointID : NativeObject
        {
            [DllImport(Settings.DLL)]
            private static extern IntPtr PointColDetector_pointid_t_getActor(IntPtr handle);

            [DllImport(Settings.DLL)]
            private static extern short PointColDetector_pointid_t_getNode_id(IntPtr handle);

            public Actor Actor { get { return new Actor(PointColDetector_pointid_t_getActor(handle)); } }

            public short Node_ID { get { return PointColDetector_pointid_t_getNode_id(handle); } }


            public PointID(IntPtr hdl) : 
                base(hdl)
            {
            }


        }*/

        /*public List<PointID> Hit_List
        {
            get
            {

                IntPtr[] out_list = new IntPtr[MAX_HITS];

                int numHits = PointColDetector_hit_list(handle, out out_list, MAX_HITS);

                List<PointID> list = new List<PointID>(numHits);
                for (int i = 0; i < numHits; i++)
                {
                    list.Add(new PointID(out_list[i]));
                }

                return list;
            }
        }*/


        [StructLayout(LayoutKind.Sequential)]
        public struct PointID
        {
            private IntPtr actor;
            private short node_id;
            private IntPtr node;

            public Actor Actor { get { return new Actor(actor); } }

            public short Node_ID { get { return node_id; } }

            public Node Node {get { return new Node(Actor, node); } }
        }

        public int NumHits
        {
            get
            {
                return PointColDetector_numHits(handle);
            }
        }

        public List<PointID> Hit_List
        {
            get
            {
                int hits = PointColDetector_numHits(handle);
                PointID[] out_list = new PointID[hits];

                PointColDetector_hit_list(handle, out_list, hits);

                List<PointID> list = new List<PointID>(hits);
                for (int i = 0; i < hits; i++)
                {
                    list.Add(out_list[i]);
                }

                return list;
            }
        }



        public Vec3 BB_Min
        {
            get
            {
                return PointColDetector_Get_bbmin(handle);
            }
        }

        public Vec3 BB_Max
        {
            get
            {
                return PointColDetector_Get_bbmax(handle);
            }
        }

        public PointColDetector(IntPtr hdl) : 
            base(hdl)
        {
        }

        public PointColDetector(Actor actor) :
            base(PointColDetector_New(actor))
        {
        }

        public void UpdateIntraPoint(bool contactables = false)
        {
            PointColDetector_UpdateIntraPoint(handle, contactables);
        }

        public void UpdateInterPoint(bool ignorestate = false)
        {
            PointColDetector_UpdateInterPoint(handle, ignorestate);
        }

        public void Query(Vec3 vec1, Vec3 vec2, Vec3 vec3, float enlargeBB)
        {
            PointColDetector_query(handle, vec1, vec2, vec3, enlargeBB);
        }
    }
}

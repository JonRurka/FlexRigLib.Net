using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace FlexRigLib.Net
{
    public class PointColDetector : NativeObject
    {
        const int MAX_HITS = 100;

        [DllImport(Settings.DLL)]
        private static extern IntPtr PointColDetector_New(IntPtr actor);

        //[DllImport(Settings.DLL)]
        //private static extern int PointColDetector_hit_list(IntPtr handle, out IntPtr[] list, int size);

        [DllImport(Settings.DLL)]
        private static extern int PointColDetector_hit_list(IntPtr handle, out PointID[] list, int size);

        [DllImport(Settings.DLL)]
        private static extern void PointColDetector_UpdateIntraPoint(IntPtr handle, bool contactables = false);

        [DllImport(Settings.DLL)]
        private static extern void PointColDetector_UpdateInterPoint(IntPtr handle, bool ignorestate = false);

        [DllImport(Settings.DLL)]
        private static extern void PointColDetector_query(IntPtr handle, Vec3 vec1, Vec3 vec2, Vec3 vec3, float enlargeBB);

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

        public struct PointID
        {
            private IntPtr actor;
            private short node_id;

            public Actor Actor { get { return Actor.GetActor(actor); } }
            public short Node_ID { get { return node_id; } }
        }

        public List<PointID> Hit_List
        {
            get
            {

                PointID[] out_list = new PointID[MAX_HITS];

                int numHits = PointColDetector_hit_list(handle, out out_list, MAX_HITS);

                List<PointID> list = new List<PointID>(numHits);
                for (int i = 0; i < numHits; i++)
                {
                    list.Add(out_list[i]);
                }

                return list;
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


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using FlexRigLib.Net.Utilities;

namespace FlexRigLib.Net.Physics.Collision
{
    public class Collisions_Base : NativeObject
    {
        [DllImport(Settings.DLL)]
        private static extern float Collisions_Base_getSurfaceHeight(IntPtr handle, float x, float z);

        [DllImport(Settings.DLL)]
        private static extern float Collisions_Base_getSurfaceHeightBelow(IntPtr handle, float x, float z, float height);

        //[DllImport(Settings.DLL)]
        //bool Collisions_Base_collisionCorrect(void* handle, glm::vec3* refpos, bool envokeScriptCallbacks = true);

        [DllImport(Settings.DLL)]
        private static extern bool Collisions_Base_groundCollision(IntPtr handle, IntPtr node, float dt);

        [DllImport(Settings.DLL)]
        private static extern bool Collisions_Base_isInside_1(IntPtr handle, Vec3 pos, string inst, string box, float border);

        [DllImport(Settings.DLL)]
        private static extern bool Collisions_Base_isInside_2(IntPtr handle, Vec3 pos, IntPtr cbox, float border);

        [DllImport(Settings.DLL)]
        private static extern bool Collisions_Base_nodeCollision(IntPtr handle, IntPtr node, float dt);

        [DllImport(Settings.DLL)]
        private static extern int Collisions_Base_addCollisionBox(IntPtr handle,
            bool rotating,
            bool virt,
            Vec3 pos,
            Vec3 rot,
            Vec3 l,
            Vec3 h,
            Vec3 sr,
            string eventname,
            string instancename,
            bool forcecam,
            Vec3 campos,
            Vec3 sc,
            Vec3 dr,
            short event_filter,
            int scripthandler);

        [DllImport(Settings.DLL)]
        private static extern int Collisions_Base_addCollisionTri(IntPtr handle, Vec3 p1, Vec3 p2, Vec3 p3, Ground_Model gm);

        [DllImport(Settings.DLL)]
        private static extern void Collisions_Base_removeCollisionBox(IntPtr handle, int number);

        [DllImport(Settings.DLL)]
        private static extern void Collisions_Base_removeCollisionTri(IntPtr handle, int number);

        [DllImport(Settings.DLL)]
        private static extern void Collisions_Base_clearEventCache(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern IntPtr Collisions_Base_getCollisionAAB(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern Vec3 C_primitiveCollision(IntPtr node, Vec3 velocity, float mass, Vec3 normal, float dt, Ground_Model gm, float penetration);


        public static Vec3 PrimitiveCollision(Node node, Vec3 velocity, float mass, Vec3 normal, float dt, Ground_Model gm, float penetration)
        {
            return C_primitiveCollision(node, velocity, mass, normal, dt, gm, penetration);
        }

        protected Collisions_Base(IntPtr hdl)
            : base(hdl)
        {
        }

        public static Collisions_Base GetBaseInstance(IntPtr hdl)
        {
            return new Collisions_Base(hdl);
        }

        public float GetSurfaceHeight(float x, float z)
        {
            return Collisions_Base_getSurfaceHeight(handle, x, z);
        }

        public float GetSurfaceHeightBelow(float x, float z, float height)
        {
            return Collisions_Base_getSurfaceHeightBelow(handle, x, z, height);
        }

        public bool GroundCollision(Node node, float dt)
        {
            return Collisions_Base_groundCollision(handle, node, dt);
        }

        public bool IsInside(Vec3 pos, string inst, string box, float border)
        {
            return Collisions_Base_isInside_1(handle, pos, inst, box, border);
        }

        public bool IsInside(Vec3 pos, Collision_Box cbox, float border)
        {
            return Collisions_Base_isInside_2(handle, pos, cbox, border);
        }

        public bool NodeCollision(Node node, float dt)
        {
            return Collisions_Base_nodeCollision(handle, node, dt);
        }

        public int AddCollisionBox(
            bool rotating,
            bool virt,
            Vec3 pos,
            Vec3 rot,
            Vec3 l,
            Vec3 h,
            Vec3 sr,
            string eventname,
            string instancename,
            bool forcecam,
            Vec3 campos,
            Vec3 sc,
            Vec3 dr,
            CollisionEventFilter event_filter,
            int scripthandler)
        {
            return Collisions_Base_addCollisionBox(handle,
                rotating,
                virt,
                pos,
                rot,
                l,
                h,
                sr,
                eventname,
                instancename,
                forcecam,
                campos,
                sc,
                dr,
                (short)event_filter,
                scripthandler);
        }

        public int AddCollisionTri(Vec3 p1, Vec3 p2, Vec3 p3, Ground_Model gm)
        {
            return Collisions_Base_addCollisionTri(handle, p1, p2, p3, gm);
        }

        public void RemoveCollisionBox(int number)
        {
            Collisions_Base_removeCollisionBox(handle, number);
        }

        public void RemoveCollisionTri(int number)
        {
            Collisions_Base_removeCollisionTri(handle, number);
        }

        public void ClearEventCache()
        {
            Collisions_Base_clearEventCache(handle);
        }

        public AxisAlignedBox GetCollisionAAB()
        {
            return new AxisAlignedBox(Collisions_Base_getCollisionAAB(handle));
        }

    }
}

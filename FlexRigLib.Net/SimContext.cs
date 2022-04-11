using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net
{
    public class SimContext
    {
        [DllImport(Settings.DLL)]
        private static extern IntPtr SimContext_New();

        [DllImport(Settings.DLL)]
        private static extern float SimContext_Test(IntPtr sim_context, float a, float b);

        [DllImport(Settings.DLL)]
        private static extern bool SimContext_LoadTerrain(IntPtr sim_context, IntPtr terrain_mgr, IntPtr collisions, float gravity);

        [DllImport(Settings.DLL)]
        private static extern void SimContext_UnloadTerrain(IntPtr sim_context);

        [DllImport(Settings.DLL)]
        private static extern IntPtr SimContext_SpawnActor(IntPtr sim_context, ActorSpawnRequest rq, IntPtr file_builder);

        [DllImport(Settings.DLL)]
        private static extern void SimContext_DeleteActor(IntPtr sim_context, IntPtr actor);

        [DllImport(Settings.DLL)]
        private static extern void SimContext_ModifyActor(IntPtr sim_context);

        [DllImport(Settings.DLL)]
        private static extern void SimContext_UpdateActors(IntPtr sim_context);

        [DllImport(Settings.DLL)]
        private static extern IntPtr SimContext_GetActorManager(IntPtr sim_context);

        [DllImport(Settings.DLL)]
        private static extern int SimContext_GetSimState(IntPtr sim_context);

        private IntPtr handle;

        public SimContext()
        {
            handle = SimContext_New();
        }

        public IntPtr GetHandle()
        {
            return handle;
        }

        public float TestThisWorks(float a, float b)
        {
            return SimContext_Test(handle, a, b);
        }

        public bool LoadTerrain(TerrainManager_Base terrain_mgr, Collisions_Base collisions, float gravity)
        {
            return SimContext_LoadTerrain(handle, terrain_mgr.GetHandle(), collisions.GetHandle(), gravity);
        }

        public void UnloadTerrain()
        {
            SimContext_UnloadTerrain(handle);
        }

        public Actor SpawnActor(ActorSpawnRequest rq, FileBuilder file_builder)
        {
            return new Actor(SimContext_SpawnActor(handle, rq, file_builder.GetHandle()));
        }

        public void DeleteActor(Actor actor)
        {
            SimContext_DeleteActor(handle, actor.GetHandle());
        }

        public void ModifyActor()
        {
            SimContext_ModifyActor(handle);
        }

        public void UpdateActors()
        {
            SimContext_UpdateActors(handle);
        }

        public IntPtr GetActorManager()
        {
            return SimContext_GetActorManager(handle);
        }

        public SimState GetSimState()
        {
            return (SimState)SimContext_GetSimState(handle);
        }
    }
}

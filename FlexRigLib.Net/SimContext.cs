using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using FlexRigLib.Net.Physics;
using FlexRigLib.Net.Physics.Collision;
using FlexRigLib.Net.Environment;
using FlexRigLib.Net.Utilities;
using FlexRigLib.Net.Resources;

namespace FlexRigLib.Net
{
    public class SimContext : NativeObject
    {
        [DllImport(Settings.DLL)]
        private static extern IntPtr SimContext_New();

        [DllImport(Settings.DLL)]
        private static extern Vec3 SimContext_Test(IntPtr sim_context, ActorSpawnRequest rq);

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
        private static extern void SimContext_UpdateActors(IntPtr sim_context, float dt);

        [DllImport(Settings.DLL)]
        private static extern IntPtr SimContext_GetActorManager(IntPtr sim_context);

        [DllImport(Settings.DLL)]
        private static extern int SimContext_GetSimState(IntPtr sim_context);

        [DllImport(Settings.DLL)]
        private static extern bool SimContext_IsSimulationPaused(IntPtr sim_context);

        [DllImport(Settings.DLL)]
        private static extern void SimContext_SetSimulationPaused(IntPtr sim_context, bool v);


        public bool IsPaused
        {
            get
            {
                return SimContext_IsSimulationPaused(handle);
            }
            set
            {
                SimContext_SetSimulationPaused(handle, value);
            }
        }

        public SimContext() :
            base (SimContext_New())
        {
        }


        public void Run()
        {
            IsPaused = false;
        }
        public Vec3 TestThisWorks(ActorSpawnRequest rq)
        {
            return SimContext_Test(handle, rq);
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

        public void UpdateActors(float dt)
        {
            SimContext_UpdateActors(handle, dt);
        }

        public ActorManager GetActorManager()
        {
            return new ActorManager(SimContext_GetActorManager(handle));
        }

        public SimState GetSimState()
        {
            return (SimState)SimContext_GetSimState(handle);
        }
    }
}

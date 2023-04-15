using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net.Physics
{
    public class ActorManager : NativeObject
    {
        [DllImport(Settings.DLL)]
        private static extern void ActorManager_SetSimulationSpeed(IntPtr handle, float speed);

        [DllImport(Settings.DLL)]
        private static extern float ActorManager_GetSimulationSpeed(IntPtr handle);


        public float SimulationSpeed
        {
            get
            {
                return ActorManager_GetSimulationSpeed(handle);
            }
            set
            {
                ActorManager_SetSimulationSpeed(handle, value);
            }
        }


        public ActorManager(IntPtr hdl) : 
            base(hdl)
        {
        }


    }
}

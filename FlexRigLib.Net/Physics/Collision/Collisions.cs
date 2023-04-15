using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net.Physics.Collision
{
    public class Collisions : Collisions_Base
    {
        [DllImport(Settings.DLL)]
        private static extern IntPtr Collisions_New(float terrn_size_x, float terrn_size_y, float terrn_size_z);

        [DllImport(Settings.DLL)]
        private static extern void Collisions_addGroundModel(IntPtr handle, string name, Ground_Model model);

        [DllImport(Settings.DLL)]
        private static extern void Collisions_setDefaultGroundModels(IntPtr handle);

        public Collisions(float terrn_size_x, float terrn_size_y, float terrn_size_z)
            : base(Collisions_New(terrn_size_x, terrn_size_y, terrn_size_z))
        {

        }

        public void AddGroundModel(string name, Ground_Model model)
        {
            Collisions_addGroundModel(handle, name, model);
        }

        public void SetDefaultGroundModels()
        {
            Collisions_setDefaultGroundModels(handle);
        }
    }
}

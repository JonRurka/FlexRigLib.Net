using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ActorSpawnRequest
    {
        public enum DefaultOrigin : int //!< Enables special processing
        {
            UNKNOWN = 0,
            TERRN_DEF = 1,
            DEFAULT = 2,
        };


        public Vec3 asr_position;
        public Quat asr_rotation;
        public Collision_Box asr_spawnbox;
        public int asr_origin;

        public bool asr_free_position;   //!< Disables the automatic spawn position adjustment
        public bool asr_terrn_machine;   //!< This is a fixed machinery
    }
}

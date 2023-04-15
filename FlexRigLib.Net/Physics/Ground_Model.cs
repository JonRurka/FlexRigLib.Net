using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net.Physics
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Ground_Model
    {
        public float va;                       //!< adhesion velocity
        public float ms;                       //!< static friction coefficient
        public float mc;                       //!< sliding friction coefficient
        public float t2;                       //!< hydrodynamic friction (s/m)
        public float vs;                       //!< stribeck velocity (m/s)
        public float alpha;                    //!< steady-steady
        public float strength;                 //!< ground strength

        public float fluid_density;            //!< Density of liquid
        public float flow_consistency_index;   //!< general drag coefficient

        //! if flow_behavior_index<1 then liquid is Pseudoplastic (ketchup, whipped cream, paint)
        //! if =1 then liquid is Newtoni'an fluid
        //! if >1 then liquid is Dilatant fluid (less common)
        public float flow_behavior_index;


        public float solid_ground_level;       //!< how deep the solid ground is
        public float drag_anisotropy;          //!< Upwards/Downwards drag anisotropy

        public int fx_type;

        //Ogre::ColourValue fx_colour;
        public int fx_colour;

        //public char[] name;
        //public char[] basename;
        //public char[] particle_name;

        public int fx_particle_amount;         //!< amount of particles

        public float fx_particle_min_velo;     //!< minimum velocity to display sparks
        public float fx_particle_max_velo;     //!< maximum velocity to display sparks
        public float fx_particle_fade;         //!< fade coefficient
        public float fx_particle_timedelta;    //!< delta for particle animation
        public float fx_particle_velo_factor;  //!< velocity factor
        public float fx_particle_ttl;

        public static Ground_Model Default()
        {
            Ground_Model res = default(Ground_Model);

            res.alpha = 2.0f;
            res.strength = 1.0f;

            return res;
        }
    }
}

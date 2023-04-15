using System;
using System.Collections.Generic;
using System.Text;

namespace FlexRigLib.Net.Physics.Collision
{
    public enum CollisionEventFilter : short
    {
        EVENT_NONE = 0,
        EVENT_ALL,
        EVENT_AVATAR,
        EVENT_TRUCK,
        EVENT_AIRPLANE,
        EVENT_BOAT,
        EVENT_DELETE
    }
}

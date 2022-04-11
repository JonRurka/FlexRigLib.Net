using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2
    {
        public float x;
        public float y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3
    {
        public float x;
        public float y;
        public float z;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4
    {
        public float x;
        public float y;
        public float z;
        public float w;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Quat
    {
        public float x;
        public float y;
        public float z;
        public float w;

    }
}

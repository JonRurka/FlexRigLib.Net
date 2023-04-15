using System;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net.Compute
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Platform
    {
        IntPtr platform;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1000)]
        char[] name;
        ushort name_size;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1000)]
        char[] vendor;
        ushort vendor_size;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1000)]
        char[] version;
        ushort version_size;

        

        public string Name { get { return new string(name).Substring(0, name_size); } }

        public string Vendor { get { return new string(vendor).Substring(0, vendor_size); } }

        public string Version { get { return new string(version).Substring(0, version_size); } }
    }
}
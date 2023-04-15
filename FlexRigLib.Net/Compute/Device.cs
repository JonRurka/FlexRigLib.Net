using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net.Compute
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Device
    {
        public IntPtr device;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1000)]
        public char[] vendor;
        ushort vendor_size;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1000)]
        public char[] name;
        ushort name_size;

        public uint clock_frequency;

        public uint num_compute_units;

        public ulong mem_size;

        public uint max_work_size;

        public uint group_size;

        byte is_type_default;

        byte is_type_CPU;

        byte is_type_GPU;

        byte is_type_Accelerator;

        

        public string Name { get { return new string(name).Substring(0, name_size); } }

        public string Vendor { get { return new string(vendor).Substring(0, vendor_size); } }
    }
}

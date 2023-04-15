using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net.Compute
{
    public static class ComputeEngine
    {
        [DllImport(Settings.DLL)]
        private static extern int ComputeEngine_Platforms_Init();

        [DllImport(Settings.DLL)]
        private static extern void ComputeEngine_Platforms_GetAll([In, Out] Platform[] out_platforms);

        [DllImport(Settings.DLL)]
        private static extern int ComputeEngine_Devices_Init(Platform pltform);

        [DllImport(Settings.DLL)]
        private static extern void ComputeEngine_Devices_GetAll([In, Out] Device[] out_devices);

        [DllImport(Settings.DLL)]
        private static extern void ComputeEngine_Init(Platform platform, Device device, string dir, int dir_len);

        [DllImport(Settings.DLL)]
        private static extern void ComputeEngine_Get_CL_Version(StringBuilder str, int size);


        public static Platform[] Get_All_Platfroms()
        {
            int num = ComputeEngine_Platforms_Init();

            Platform[] platforms = new Platform[num];
            ComputeEngine_Platforms_GetAll(platforms);

            return platforms;
        }

        public static Device[] Get_All_Devices(Platform pltform)
        {
            int num = ComputeEngine_Devices_Init(pltform);

            Device[] devices = new Device[num];
            ComputeEngine_Devices_GetAll(devices);

            return devices;
        }

        public static void Init(Platform platform, Device device, string dir)
        {
            ComputeEngine_Init(platform, device, dir, dir.Length);
        }

        public static string Get_CL_Version()
        {
            StringBuilder bldr = new StringBuilder(1000);
            ComputeEngine_Get_CL_Version(bldr, 1000);
            return bldr.ToString();
        }
    }
}

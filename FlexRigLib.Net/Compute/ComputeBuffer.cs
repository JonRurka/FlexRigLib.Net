using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net.Compute
{
    public class ComputeBuffer : NativeObject
    {
        [DllImport(Settings.DLL)]
        private static extern int ComputeBuffer_SetData(IntPtr handle, IntPtr data);

        [DllImport(Settings.DLL)]
        private static extern int ComputeBuffer_GetData(IntPtr handle, IntPtr outData);

        [DllImport(Settings.DLL)]
        private static extern void ComputeBuffer_Dispose(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern IntPtr ComputeBuffer_Get_CL_Mem(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern ulong ComputeBuffer_GetSize(IntPtr handle);

        internal ComputeBuffer(IntPtr hdl) :
            base(hdl)
        {
        }

        public int SetData<T>(T[] data)
        {
            GCHandle pinnedArray = GCHandle.Alloc(data, GCHandleType.Pinned);
            IntPtr pointer = pinnedArray.AddrOfPinnedObject();

            int res = ComputeBuffer_SetData(handle, pointer);

            pinnedArray.Free();

            return res;
        }

        public int GetData<T>(T[] data)
        {
            GCHandle pinnedArray = GCHandle.Alloc(data, GCHandleType.Pinned);
            IntPtr pointer = pinnedArray.AddrOfPinnedObject();

            int res = ComputeBuffer_GetData(handle, pointer);

            pinnedArray.Free();

            return res;
        }

        public void Dispose()
        {
            ComputeBuffer_Dispose(handle);
        }

        public IntPtr Get_CL_Mem()
        {
            return ComputeBuffer_Get_CL_Mem(handle);
        }

        public ulong GetSize()
        {
            return ComputeBuffer_GetSize(handle);
        }
    }
}

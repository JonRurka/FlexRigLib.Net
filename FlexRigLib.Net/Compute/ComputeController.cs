using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net.Compute
{
    public class ComputeController : NativeObject
    {
        [DllImport(Settings.DLL)]
        private static extern IntPtr ComputeController_New(Platform platform, Device device, string dir, int dir_len);

        [DllImport(Settings.DLL)]
        private static extern IntPtr ComputeController_GetProgramBuilder(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern void ComputeController_BuildProgram(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern IntPtr ComputeController_NewReadBuffer(IntPtr handle, ulong length);

        [DllImport(Settings.DLL)]
        private static extern IntPtr ComputeController_NewWriteBuffer(IntPtr handle, ulong length);

        [DllImport(Settings.DLL)]
        private static extern IntPtr ComputeController_NewReadWriteBuffer(IntPtr handle, ulong length);

        [DllImport(Settings.DLL)]
        private static extern int ComputeController_KernelAddBuffer(IntPtr handle, string k_name, IntPtr buffer);

        [DllImport(Settings.DLL)]
        private static extern int ComputeController_RunKernel(IntPtr handle, string k_name, int size_x, int size_y, int size_z);


        public ProgramBuilder Program_Builder
        {
            get
            {
                return ProgramBuilder.Get(ComputeController_GetProgramBuilder(handle));
            }
        }

        public ComputeController(IntPtr hdl) :
            base(hdl)
        {
        }

        public ComputeController(Platform platform, Device device, string dir) :
            base(ComputeController_New(platform, device, dir, dir.Length))
        {
        }

        public void BuildProgram()
        {
            ComputeController_BuildProgram(handle);
        }

        public ComputeBuffer NewReadBuffer(int length)
        {
            return new ComputeBuffer(ComputeController_NewReadBuffer(handle, (ulong)length));
        }

        public ComputeBuffer NewWriteBuffer(int length)
        {
            return new ComputeBuffer(ComputeController_NewWriteBuffer(handle, (ulong)length));
        }

        public ComputeBuffer NewReadWriteBuffer(int length)
        {
            return new ComputeBuffer(ComputeController_NewReadWriteBuffer(handle, (ulong)length));
        }

        public int KernelAddBuffer(string k_name, ComputeBuffer buffer)
        {
            return ComputeController_KernelAddBuffer(handle, k_name, buffer.GetHandle());
        }

        public int RunKernel(string k_name, int size_x, int size_y, int size_z)
        {
            return ComputeController_RunKernel(handle, k_name, size_x, size_y, size_z);
        }

    }
}

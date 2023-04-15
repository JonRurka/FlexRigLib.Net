using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net.Compute
{
    public class ProgramBuilder : NativeObject
    {
        [DllImport(Settings.DLL)]
        private static extern void ProgramBuilder_AddConstant(IntPtr handle, string name, string value);

        [DllImport(Settings.DLL)]
        private static extern void ProgramBuilder_AddFunction(IntPtr handle, string name, string f_source);

        [DllImport(Settings.DLL)]
        private static extern void ProgramBuilder_AddKernel(IntPtr handle, string name, string f_source);

        [DllImport(Settings.DLL)]
        private static extern void ProgramBuilder_AppendSource(IntPtr handle, string f_source);

        [DllImport(Settings.DLL)]
        private static extern int ProgramBuilder_GetErrorSize(IntPtr handle);

        [DllImport(Settings.DLL)]
        private static extern void ProgramBuilder_GetError(IntPtr handle, [Out] StringBuilder out_error);

        [DllImport(Settings.DLL)]
        private static extern int ProgramBuilder_Build(IntPtr handle);

        public string Error
        {
            get
            {
                int e_size = ProgramBuilder_GetErrorSize(handle);
                StringBuilder str_b = new StringBuilder(e_size);
                ProgramBuilder_GetError(handle, str_b);
                return str_b.ToString();
            }
        }


        internal ProgramBuilder(IntPtr hdl) :
            base(hdl)
        {
        }

        public void AddConstant(string name, string value)
        {
            ProgramBuilder_AddConstant(handle, name, value);
        }

        public void AddFunction(string name, string f_source)
        {
            ProgramBuilder_AddFunction(handle, name, f_source);
        }

        public void AddKernel(string name, string f_source)
        {
            ProgramBuilder_AddKernel(handle, name, f_source);
        }

        public void AppendSource(string f_source)
        {
            ProgramBuilder_AppendSource(handle, f_source);
        }

        public void Build()
        {
            ProgramBuilder_Build(handle);
        }


        internal static Dictionary<IntPtr, ProgramBuilder> builders = new Dictionary<IntPtr, ProgramBuilder>();
        internal static ProgramBuilder Get(IntPtr hdl)
        {
            if (builders.ContainsKey(hdl))
                return builders[hdl];

            ProgramBuilder newBuilder = new ProgramBuilder(hdl);
            builders.Add(hdl, newBuilder);

            return newBuilder;
        }
    }
}

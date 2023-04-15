using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net.Resources
{
	public class FileBuilder : NativeObject
    {
		[DllImport(Settings.DLL, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr FileBuilder_New();

		[DllImport(Settings.DLL)]
		private static extern void FileBuilder_SetGlobals(IntPtr handle,
			float dry_mass,
			float cargo_mass,
			string material_name);

		[DllImport(Settings.DLL)]
		private static extern void FileBuilder_SetNodeDefaults(IntPtr handle,
			float load_weight,
			float friction,
			float volume,
			float surface,
			uint options);

		[DllImport(Settings.DLL)]
		private static extern void FileBuilder_SetBeamDefaultsScale(IntPtr handle,
			float springiness,
			float damping_constan,
			float deformation_threshold_constant,
			float breaking_threshold_constant);

		[DllImport(Settings.DLL)]
		private static extern void FileBuilder_SetBeamDefaults(IntPtr handle,
			float springiness,
			float damping_constant,
			float deformation_threshold,
			float breaking_threshold,
			float visual_beam_diameter,
			string beam_material_name,
			float plastic_deform_coef,
			bool _enable_advanced_deformation,
			bool _is_plastic_deform_coef_user_defined,
			bool _is_user_defined 
		);

		[DllImport(Settings.DLL)]
		private static extern void FileBuilder_SetMinimassPreset(IntPtr handle, float min_mass);

		[DllImport(Settings.DLL)]
		private static extern void FileBuilder_AddNode(IntPtr handle, string id, float x, float y, float z, bool loadWeight, float weight);

		[DllImport(Settings.DLL)]
		private static extern void FileBuilder_AddBeam(IntPtr handle, string node_1, string node_2, bool canBreak, float breakLimit);

		[DllImport(Settings.DLL)]
		private static extern void FileBuilder_NewSubmesh(IntPtr handle);

		[DllImport(Settings.DLL)]
		private static extern void FileBuilder_FlushSubmesh(IntPtr handle);

		[DllImport(Settings.DLL)]
		private static extern void FileBuilder_AddCab(IntPtr handle, string n1, string n2, string n3, int option);

		[DllImport(Settings.DLL)]
		private static extern void FileBuilder_AddContacter(IntPtr handle, string n1);

		public FileBuilder(IntPtr hdl) : 
            base(hdl)
        {
        }

		public FileBuilder() :
			base(FileBuilder_New())
        {
        }

		public void SetGlobals(
			float dry_mass,
			float cargo_mass,
			string material_name)
        {
			FileBuilder_SetGlobals(handle, dry_mass, cargo_mass, material_name);
		}

		public void SetNodeDefaults(
			float load_weight,
			float friction,
			float volume,
			float surface,
			uint options)
        {
			FileBuilder_SetNodeDefaults(handle, load_weight, friction, volume, surface, options);

		}

		public void SetBeamDefaultsScale(
			float springiness,
			float damping_constan,
			float deformation_threshold_constant,
			float breaking_threshold_constant)
        {
			FileBuilder_SetBeamDefaultsScale(handle, springiness, damping_constan, deformation_threshold_constant, breaking_threshold_constant);

		}

		public void SetBeamDefaults(
			float springiness,
			float damping_constant,
			float deformation_threshold,
			float breaking_threshold,
			float visual_beam_diameter,
			string beam_material_name,
			float plastic_deform_coef,
			bool _enable_advanced_deformation,
			bool _is_plastic_deform_coef_user_defined,
			bool _is_user_defined
		)
        {
			FileBuilder_SetBeamDefaults(handle, 
				springiness,
				damping_constant,
				deformation_threshold,
				breaking_threshold,
				visual_beam_diameter,
				beam_material_name,
				plastic_deform_coef,
				_enable_advanced_deformation,
				_is_plastic_deform_coef_user_defined,
				_is_user_defined);
		}

		public void SetMinimassPreset(float min_mass)
        {
			FileBuilder_SetMinimassPreset(handle, min_mass);
		}

		public void AddNode(string id, float x, float y, float z, bool loadWeight, float weight)
        {
			FileBuilder_AddNode(handle, id, x, y, z, loadWeight, weight);
		}

		public void AddBeam(string node_1, string node_2, bool canBreak, float breakLimit)
        {
			FileBuilder_AddBeam(handle, node_1, node_2, canBreak, breakLimit);
		}

		public void NewSubmesh()
        {
			FileBuilder_NewSubmesh(handle);
		}

		public void FlushSubmesh()
        {
			FileBuilder_FlushSubmesh(handle);
		}

		public void AddCab(string n1, string n2, string n3, int option)
        {
			FileBuilder_AddCab(handle, n1, n2, n3, option);
		}

		public void AddContacter(string n1)
        {
			FileBuilder_AddContacter(handle, n1);
		}

	}
}

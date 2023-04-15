using System;
using FlexRigLib.Net;
using FlexRigLib.Net.Compute;
using System.Runtime.InteropServices;

namespace TesterApp
{
    class Program
    {
        static string kernel =
            "int multiply(int a, int b);\n" +
            "int multiply(int a, int b) {\n" +
            "  return a * b;\n" +
            "}\n" +
            "\n" +
            "__kernel void hello(__global int *input, __global int *output)\n" +
            "{\n" +
            "  size_t id = get_global_id(0);\n" +
            "  output[id] = multiply(input[id], input[id]);\n" +
            "}\n" +
            "\n";
        static void Main(string[] args)
        {
            Platform[] platforms = ComputeEngine.Get_All_Platfroms();

            Platform thePlatform = default(Platform);
            Device theDevice = default(Device);

            for (int i = 0; i < platforms.Length; i++)
            {
                Device[] devices = ComputeEngine.Get_All_Devices(platforms[i]);

                if (platforms[i].Name.ToLower().Contains("nvidia"))
                    thePlatform = platforms[i];

                for (int j = 0; j < devices.Length; j++)
                {
                    
                    if (devices[j].Name.ToLower().Contains("t500"))
                        theDevice = devices[j];
                }
            }

            //Console.WriteLine("Platform: {0}, {1:X}", thePlatform.Name, theDevice.device.ToInt64());
            //Console.WriteLine("Device: {0}, {1:X}", theDevice.Name, theDevice.device.ToInt64());


            int[] in_buffer = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] out_buffer = new int[10];

            ComputeController controller = new ComputeController(thePlatform, theDevice, "");

            controller.Program_Builder.AddKernel("hello", kernel);
            controller.BuildProgram();

            ComputeBuffer c_buf_in = controller.NewReadBuffer(sizeof(int) * in_buffer.Length);
            c_buf_in.SetData(in_buffer);

            ComputeBuffer c_buf_out = controller.NewWriteBuffer(sizeof(int) * out_buffer.Length);

            controller.KernelAddBuffer("hello", c_buf_in);
            controller.KernelAddBuffer("hello", c_buf_out);

            controller.RunKernel("hello", in_buffer.Length, 1, 1);

            c_buf_out.GetData(out_buffer);

            for (int i = 0; i < out_buffer.Length; i++)
            {
                Console.WriteLine(out_buffer[i]);
            }

            //ComputeEngine.Init();
            //Console.WriteLine("OpenCL Version: {0}.", ComputeEngine.Get_CL_Version());


            /*SimContext sim_context = new SimContext();

            Collisions col = new Collisions(1, 1, 1);

            SimpleTerrainManager terr = new SimpleTerrainManager(col);
            terr.SetGroundHeight(10);

            sim_context.LoadTerrain(terr, col, 0);

            Console.WriteLine("Terrain name: {0}", terr.GetTerrainName());

            FileBuilder fileBuilder = new FileBuilder();

            Console.WriteLine("add it everywhere");

            fileBuilder.SetGlobals(100.0f, 0.0f, "");
            fileBuilder.SetNodeDefaults(0, 1, 1, 1, 0);
            fileBuilder.SetBeamDefaults(-1, -1, -1, -1, 0.2f, "mat", 0.2f, false, false, false);
            fileBuilder.SetBeamDefaultsScale(1, 1, 1, 1);

            fileBuilder.SetMinimassPreset(0);

            fileBuilder.AddNode("0", 0, 0, 0, false, 0);
            fileBuilder.AddNode("1", 0, -1, 0, false, 0);

            fileBuilder.AddBeam("0", "1", true, 10000);

            ActorSpawnRequest res = new ActorSpawnRequest();

            res.asr_free_position = true;

            res.asr_origin = 2;

            res.asr_rotation = new Quat();

            res.asr_position = new Vec3();

            res.asr_terrn_machine = false;

            //Debug.Log("Requesting actor spawn...");
            Actor actor = sim_context.SpawnActor(res, fileBuilder);
            try
            {
                Console.WriteLine("Getting nodes.");
                Node[] nodes = actor.GetNodes();
                Console.WriteLine("Got nodes. " + nodes.Length);
                

                Console.WriteLine("Node 1: " + nodes[0].ToRef().RelPosition);
                Console.WriteLine("Node 2: " + nodes[1].ToRef().RelPosition);

                Beam[] beams = actor.GetBeams();

                Console.WriteLine("Beam Node 1: " + beams[0].P1.AbsPosition);
                Console.WriteLine("Beam Node 2: " + beams[0].P2.AbsPosition);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }*/

        }
    }
}

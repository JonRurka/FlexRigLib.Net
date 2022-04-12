using System;
using FlexRigLib.Net;

namespace TesterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Collisions col = new Collisions(1, 1, 1);

            SimpleTerrainManager terr = new SimpleTerrainManager(col);

            

            Console.WriteLine("Name: {0}", terr.GetTerrainName());
        }
    }
}

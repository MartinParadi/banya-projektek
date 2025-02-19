using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teszt
{
    internal class Mine
    {
        public List<Miner> Miners { get; private set; } = new List<Miner>();
        public List<Machine> Machines { get; private set; } = new List<Machine>();
        public List<OreLayer> OreLayers { get; private set; } = new List<OreLayer>();
        public int ExcavatedOres { get; private set; } = 0;
        private Random random = new Random();

        public Mine()
        {
            // Inicializálás
            Miners.Add(new Miner("Rafael"));
            Miners.Add(new Miner("Hugrabug"));

            Machines.Add(new Machine("Csákány"));
            Machines.Add(new Machine("Fúró"));

            OreLayers.Add(new OreLayer("Arany", 50));
            OreLayers.Add(new OreLayer("Vas", 100));
        }

        public void StartMining()
        {
            while (OreLayers.Any(layer => layer.Amount > 0))
            {
                foreach (var miner in Miners)
                {
                    miner.MineOre(OreLayers);
                    ExcavatedOres++;
                }

                foreach (var machine in Machines)
                {
                    machine.SpeedUpMining(OreLayers);
                    ExcavatedOres += 2;
                }

                SimulateCollapse();
                ShowStatus();
                Thread.Sleep(1000);
            }

            Console.WriteLine("Minden érc kimerült!");
        }

        private void SimulateCollapse()
        {
            if (random.Next(0, 100) < 10) // 10% esély egy földomlásra
            {
                Console.WriteLine("!!! Földomlás történt! A bányászat lassabb lesz !!!");
                Thread.Sleep(2000);
            }
        }

        private void ShowStatus()
        {
            Console.WriteLine($"Összesen kibányászott ércek: {ExcavatedOres}");
            foreach (var layer in OreLayers)
            {
                Console.WriteLine($"{layer.Type}: {layer.Amount} maradt");
            }
            Console.WriteLine("----------------------");
        }
    }
}

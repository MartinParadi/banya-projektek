using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banya_Alkalmazas
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
            Miners.Add(new Miner("RAFAEL"));
            Miners.Add(new Miner("HUGRABUG"));

            Machines.Add(new Machine("Fúró"));
            Machines.Add(new Machine("Csákány"));

            OreLayers.Add(new OreLayer("Kő", 150));
            OreLayers.Add(new OreLayer("Vas", 100));
            OreLayers.Add(new OreLayer("Arany", 50));
            OreLayers.Add(new OreLayer("Gyémánt", 2));
        }

        public async Task StartMining()
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

                await SimulateCollapse();
                ShowStatus();
                await Task.Delay(1000);
            }

            Console.WriteLine("Minden érc kimerült!");
        }

        private async Task SimulateCollapse()
        {
            if (random.Next(0, 100) < 10)
            {
                Console.WriteLine("!!! FÖLDOMLÁS TÖRTÉNT! Le kell pihenj ahhoz, hogy folytathasd !!!");
                await Task.Delay(5000);
                Console.WriteLine("Kipihened magad.");
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

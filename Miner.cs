using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teszt
{
     internal class Miner
    {
        public string Name { get; private set; }

        public Miner(string name)
        {
            Name = name;
        }

        public void MineOre(List<OreLayer> layers)
        {
            foreach (var layer in layers)
            {
                if (layer.Amount > 0)
                {
                    layer.ExtractOre(1);
                    Console.WriteLine($"{Name} kibányászott 1 egység {layer.Type}-t.");
                    break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banya_Alkalmazas
{
    internal class Machine
    {
        public string Name { get; private set; }

        public Machine(string name)
        {
            Name = name;
        }

        public void SpeedUpMining(List<OreLayer> layers)
        {
            foreach (var layer in layers)
            {
                if (layer.Amount > 0)
                {
                    layer.ExtractOre(2);
                    Console.WriteLine($"{Name} segített kibányászni 2 egység {layer.Type}-t.");
                    break;
                }
            }
        }
    }
}

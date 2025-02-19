using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banya_Alkalmazas
{
    internal class OreLayer
    {
        public string Type { get; private set; }
        public int Amount { get; private set; }

        public OreLayer(string type, int amount)
        {
            Type = type;
            Amount = amount;
        }

        public void ExtractOre(int quantity)
        {
            Amount = Math.Max(0, Amount - quantity);
        }
    }
}

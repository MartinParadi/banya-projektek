using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Banya_Alkalmazas
{
    class Program
    {
        static async Task Main()
        {
            Mine mine = new Mine();
            await mine.StartMining();
        }
    }
}

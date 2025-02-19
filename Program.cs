using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Mine mine = new Mine();
        await mine.StartMining();
    }
}

class Mine
{
    public List<Miner> Miners { get; private set; } = new List<Miner>();
    public List<Machine> Machines { get; private set; } = new List<Machine>();
    public List<OreLayer> OreLayers { get; private set; } = new List<OreLayer>();
    public int ExcavatedOres { get; private set; } = 0;
    private Random random = new Random();

    public Mine()
    {
        Miners.Add(new Miner("John"));
        Miners.Add(new Miner("Alice"));

        Machines.Add(new Machine("Excavator"));
        Machines.Add(new Machine("Drill"));

        OreLayers.Add(new OreLayer("Gold", 50));
        OreLayers.Add(new OreLayer("Iron", 100));
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
            Console.WriteLine("!!! Földomlás történt! A bányászat lassabb lesz !!!");
            await Task.Delay(2000);
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

class Miner
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

class Machine
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

class OreLayer
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banya_projekt
{
    using System;
    using System.Collections.Generic;

    public class Banyasz
    {
        public string Nev { get; set; }
        public double Tudas { get; set; } // Bányász tudása, minél magasabb, annál gyorsabb
        public BanyiGep Gep { get; set; }

        public Banyasz(string nev, double tudas)
        {
            Nev = nev;
            Tudas = tudas;
            Gep = null; // Kezdetben nincs gépe
        }

        // Bányászás folyamatának szimulálása
        public double Banyasz()
        {
            double banyaszasiSebesseg = Tudas;
            if (Gep != null)
            {
                banyaszasiSebesseg += Gep.Hatatekonysag; // A gép sebessége növeli a bányászás hatékonyságát
            }
            return banyaszasiSebesseg;
        }
    }

    public class GeyiGep
    {
        public string Tipus { get; set; }
        public double Hatatekonysag { get; set; } // A gép munkahatékonysága

        public GeyiGep(string tipus, double hatatekonysag)
        {
            Tipus = tipus;
            Hatatekonysag = hatatekonysag;
        }
    }

    public class Erc
    {
        public string Nev { get; set; }
        public double Mennyiseg { get; set; }

        public Erc(string nev, double mennyiseg)
        {
            Nev = nev;
            Mennyiseg = mennyiseg;
        }
    }

    public class Foldretteg
    {
        public string Nev { get; set; }
        public List<Erc> Ercok { get; set; }

        public Foldretteg(string nev)
        {
            Nev = nev;
            Ercok = new List<Erc>();
        }

        public void AddErc(Erc erc)
        {
            Ercok.Add(erc);
        }

        // Földréteg kimerülése (ércek elfogyása)
        public void Kimerules()
        {
            Ercok.Clear(); // Ha a réteg elfogy, eltávolítjuk az összes ércet
        }
    }
}

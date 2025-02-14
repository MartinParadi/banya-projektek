using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banya_projekt
{
    public class Banyaszat
    {
        public List<Banyasz> Banyaszok { get; set; }
        public List<Foldretteg> Foldreteg { get; set; }

        public Banyaszat()
        {
            Banyaszok = new List<Banyasz>();
            Foldreteg = new List<Foldretteg>();
        }

        public void Inditas()
        {
            foreach (var banyasz in Banyaszok)
            {
                double nyertErcek = banyasz.Banyasz();
                Console.WriteLine($"{banyasz.Nev} bányászott {nyertErcek} egység érceket.");
            }
        }

        public void Kimerules()
        {
            foreach (var foldretteg in Foldreteg)
            {
                foldretteg.Kimerules();
                Console.WriteLine($"{foldretteg.Nev} réteg kimerült.");
            }
        }
    }
}
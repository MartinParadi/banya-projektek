namespace banya_projekt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Földrétegek
            var foldretteg1 = new Foldretteg("Mészkő réteg");
            foldretteg1.AddErc(new Erc("Arany", 1000));
            foldretteg1.AddErc(new Erc("Vasérc", 500));

            var foldretteg2 = new Foldretteg("Homokkő réteg");
            foldretteg2.AddErc(new Erc("Réz", 800));

            // Bányászok és gépek
            var banyasz1 = new Banyasz("Bányász 1", 10);
            var banyasz2 = new Banyasz("Bányász 2", 12);

            var gep = new GeyiGep("Munkagép", 5);
            banyasz1.Gep = gep;

            // Bányászat szimuláció
            var banyaszat = new Banyaszat();
            banyaszat.Banyaszok.Add(banyasz1);
            banyaszat.Banyaszok.Add(banyasz2);
            banyaszat.Foldreteg.Add(foldretteg1);
            banyaszat.Foldreteg.Add(foldretteg2);

            banyaszat.Inditas();
            banyaszat.Kimerules();
        }
    }
}
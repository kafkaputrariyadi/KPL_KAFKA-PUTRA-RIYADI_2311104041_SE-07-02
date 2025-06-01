namespace tpmodul12_2311104041
{
    public class Helper
    {
        public static string CariTandaBilangan(int a)
        {
            if (a < 0) return "Bilangan Negatif";
            else if (a > 0) return "Bilangan Positif";
            else return "Bilangan Nol";
        }
    }
}

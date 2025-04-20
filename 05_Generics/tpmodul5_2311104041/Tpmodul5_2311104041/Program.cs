using System;

namespace Tpmodul5_2311104041
{
    class Program
    {
        static void Main(string[] args)
        {
            HaloGeneric halo = new HaloGeneric();
            halo.SapaUser("Kafka");

            DataGeneric<string> data = new DataGeneric<string>("2311104041");
            data.PrintData();
        }
    }
}

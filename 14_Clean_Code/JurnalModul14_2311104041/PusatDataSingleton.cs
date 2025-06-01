using System;
using System.Collections.Generic;

namespace JurnalModul13_2311104041
{
    public class PusatDataSingleton
    {
        private static PusatDataSingleton _instance;

        public List<string> DataTersimpan { get; private set; }

        private PusatDataSingleton()
        {
            DataTersimpan = new List<string>();
        }

        public static PusatDataSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PusatDataSingleton();
            }

            return _instance;
        }
        public List<string> AmbilSemuaData()
        {
            return DataTersimpan;
        }

        public void TampilkanSemuaData()
        {
            foreach (var data in DataTersimpan)
            {
                Console.WriteLine(data);
            }
        }
        public void TambahData(string input)
        {
            DataTersimpan.Add(input);
        }

        public void HapusData(int index)
        {
            if (index >= 0 && index < DataTersimpan.Count)
            {
                DataTersimpan.RemoveAt(index);
            }
        }
    }
}

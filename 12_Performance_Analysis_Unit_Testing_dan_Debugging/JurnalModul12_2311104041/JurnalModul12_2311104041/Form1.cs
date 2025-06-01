using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JurnalModul12_2311104041
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCek_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxA.Text, out int a) && int.TryParse(textBoxB.Text, out int b))
            {
                int hasil = Helper.CariNilaiPangkat(a, b);
                labelOutput.Text = $"Hasil Output: {hasil}";
            }
            else
            {
                labelOutput.Text = "Hasil Output: Input tidak valid!";
            }
        }
    }
}

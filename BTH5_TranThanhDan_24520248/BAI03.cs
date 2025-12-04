using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH5_TranThanhDan_24520248
{
    public partial class BAI03 : Form
    {
        int x, y;
        int Wcir, Hcir;
        public BAI03()
        {
            InitializeComponent();
            this.Paint += VeHinhtron;
            this.MouseClick += Khoitaotoado;
            Decbutton.Click += (_, _) =>
            {
                if (Wcir-10>0) Wcir -= 10;
                if (Hcir-10>0) Hcir -= 10;
                Invalidate();
            };
            Incbutton.Click += (_, _) =>
            {
                Wcir += 10;
                Hcir += 10;
                Invalidate();
            };
        }
        void Khoitaotoado (object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x=e.X; y=e.Y;
                Wcir = 90;
                Hcir = 90;
                Invalidate();
            }
        }
        void VeHinhtron(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Brush brush=new SolidBrush(Color.Purple);
            g.FillEllipse(brush, x, y, Wcir,Hcir);
        }
    }
}

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
    public partial class BAI02 : Form
    {
        int x, y;
        int Wrec,Hrec;
        public BAI02()
        {
            InitializeComponent();
            this.Paint += VeHinhVuong;
            Wrec = 300;
            Hrec = 200;
            x = (int)this.Width / 2 - (int)Wrec/2;
            y = (int)this.Height / 2 - (int)Hrec/2;
            this.KeyDown += Nhanphim;
        }
        void VeHinhVuong(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen pen=new Pen(Color.Purple,5);
            Brush brush = new SolidBrush(Color.Yellow);
            g.FillRectangle(brush,x,y,Wrec,Hrec);
            g.DrawRectangle(pen, x, y, Wrec, Hrec);
        }
        void Nhanphim(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (x - 10 >= 0) x -= 10;
                    break;
                case Keys.Right:
                    if (x + Wrec + 10 <= this.Width) x += 10;
                    break;
                case Keys.Up:
                    if (y - 10 >= 0) y -= 10;
                    break;
                case Keys.Down:
                    if (y + 10 + Hrec <= this.Height) y += 10;
                    break;
            }
            Invalidate();
        }
    }
}

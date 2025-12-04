using System.Security.Cryptography;

namespace BTH5_TranThanhDan_24520248
{
    public partial class BAI01 : Form
    {
        int x, y;
        string s;
        Font font;
        SizeF sz;
        public BAI01()
        {
            InitializeComponent();
            this.Paint += VeChuoi;
            Graphics g = this.CreateGraphics();
            s = "Hello! How are you today?";
            font = new Font("Time New Roman", 30);
            sz = g.MeasureString(s, font);
            x = (int)this.Width / 2 - (int)sz.Width / 2;
            y = (int)this.Height / 2 - (int)sz.Height;
            this.KeyDown += Nhanphim;
        }
        void VeChuoi(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawString(s, font, Brushes.Purple, x, y);
        }
        void Nhanphim(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (x-10 >= 0) x -= 10;
                    break;
                case Keys.Right:
                    if (x+sz.Width+10<=this.Width) x += 10;
                    break;
                case Keys.Up:
                    if (y-10 >= 0) y -= 10;
                    break;
                case Keys.Down:
                    if (y+10+sz.Height<=this.Height) y += 10;
                    break;
            }
            Invalidate();
        }
    }
}

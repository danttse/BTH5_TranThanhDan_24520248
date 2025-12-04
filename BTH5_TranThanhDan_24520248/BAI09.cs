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
    public partial class BAI09 : Form
    {
        Brush brush;
        Pen pen;
        Graphics g;
        public BAI09()
        {
            InitializeComponent();
            string[] listchoice = new string[] { "Circle", "Square", "Ellipse", "Pie", "Filled Circle", "Filled Square", "Filled Ellipse", "Filled Pie" };
            foreach (string choice in listchoice)
            {
                comboBox1.Items.Add(choice);
            }
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            brush = new SolidBrush(Color.YellowGreen);
            pen=new Pen(Color.Purple,3);
            g=this.CreateGraphics();
        }

        private void ComboBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string choice = comboBox1.Text;
            switch (choice)
            {
                case "Circle":
                    VeHinhTron(false);
                    break;
                case "Square":
                    VeHinhVuong(false);
                    break;
                case "Ellipse":
                    VeHinhBauDuc(false);
                    break;
                case "Pie":
                    VeCung(false);
                    break;
                case "Filled Circle":
                    VeHinhTron(true);
                    break;
                case "Filled Square":
                    VeHinhVuong(true);
                    break;
                case "Filled Ellipse":
                    VeHinhBauDuc(true);
                    break;
                case "Filled Pie":
                    VeCung(true);
                    break;
            }
        }
        void VeHinhTron(bool isFill)
        {
            g.Clear(BackColor);
            if (isFill)
            {
                g.FillEllipse(brush, this.Width/2-100, this.Height/2-100, 200, 200);
            }
            g.DrawEllipse(pen, this.Width/2-100, this.Height/2-100, 200, 200);
        }
        void VeHinhVuong(bool isFill)
        {
            g.Clear(BackColor);
            if (isFill)
            {
                g.FillRectangle(brush, this.Width / 2 - 100, this.Height/2 - 100, 200, 200);
            }
            g.DrawRectangle(pen, this.Width / 2 - 100, this.Height/2 - 100, 200, 200);
        }
        void VeHinhBauDuc(bool isFill)
        {
            g.Clear(BackColor);
            if (isFill)
            {
                g.FillEllipse(brush, this.Width/2-100, this.Height/2-50, 200, 100);
            }
            g.DrawEllipse(pen, this.Width/2 - 100, this.Height/2 - 50, 200, 100);
        }
        void VeCung(bool isFill)
        {
            g.Clear(BackColor);
            if (isFill)
            {
                g.FillPie(brush,this.Width/2-100,this.Height/2-100,200,200,0,200);
            }
            g.DrawPie(pen, this.Width / 2 - 100, this.Height / 2 - 100, 200, 200, 0, 200);
        }
    }
}

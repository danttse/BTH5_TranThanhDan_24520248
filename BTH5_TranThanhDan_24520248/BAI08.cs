using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace BTH5_TranThanhDan_24520248
{
    public partial class BAI08 : Form
    {
        Graphics g;
        Bitmap khung;
        public BAI08()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
            this.Load += BAI08_Load;
            pictureBox1.Paint += BAI08_Paint;
            System.Windows.Forms.Timer bodemgiay= new System.Windows.Forms.Timer();
            bodemgiay.Interval = 1000;
            bodemgiay.Tick += (_, _) =>
            {
                pictureBox1.Invalidate();
            };
            bodemgiay.Start();
        }

        private void BAI08_Load(object? sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            khung = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics c = Graphics.FromImage(khung))
            {
                c.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
                c.RotateTransform(-90);
                VeKhungDongHo(c);      
            }
            pictureBox1.Image = khung;
        }

        private void BAI08_Paint(object? sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(Color.Black);
            g= e.Graphics;
            //g.DrawImage(khung, 0, 0);
            g.TranslateTransform(pictureBox1.Width/2, pictureBox1.Height/2);
            g.RotateTransform(-90);
            VeKimGiay();
        }

        void VeKhungDongHo(Graphics c)
        {
            double goc = 0.0f;
            int dem = 0;
            Brush brush = new SolidBrush(Color.White);
            while (dem < 60)
            {
                int big;
                if (dem % 5 == 0) big = 20; else big = 6;
                double rad = goc * Math.PI / 180;
                RectangleF rect = new RectangleF((float)(200 * Math.Cos(rad) - big / 2), (float)(200 * Math.Sin(rad) - big / 2), big, big);
                c.FillEllipse(brush, rect);
                goc = goc - 6.0f;
                ++dem;
            }
        }
        void VeKimGiay()
        {
            int giay = DateTime.Now.Second;
            double gocgiay = (float)giay * 6.0f;
            double rad = gocgiay * Math.PI / 180;
            Pen pen = new Pen(Color.White,2);
            g.DrawLine(pen, 0, 0, (float)(175 * Math.Cos(rad)), (float)(175 * Math.Sin(rad)));
            VeKimPhut();
            VeKimGio();
        }
        void VeKimGio()
        {
            int gio = DateTime.Now.Hour;
            double gocgio = (float)gio * 30.0f;
            double rad = gocgio * Math.PI / 180;
            Pen pen = new Pen(Color.White, 6);
            PointF dinhtrai = new PointF((float)(20 * Math.Cos(rad + Math.PI / 2)), (float)(20 * Math.Sin(rad + Math.PI / 2)));
            PointF dinhphai = new PointF((float)(20 * Math.Cos(rad + 3*Math.PI/2)), (float)(20 * Math.Sin(rad + 3*Math.PI/2)));
            PointF dinhduoi = new PointF((float)(45 * Math.Cos(rad + Math.PI)), (float)(45 * Math.Sin(rad + Math.PI)));
            PointF dinhtren = new PointF((float)(100 * Math.Cos(rad)), (float)(100 * Math.Sin(rad)));
            VeHinhThoi(dinhtrai, dinhphai, dinhtren, dinhduoi);
        }
        void VeKimPhut()
        {
            int phut = DateTime.Now.Minute;
            double gocphut = (float)phut * 6.0f;
            double rad = gocphut * Math.PI / 180;
            PointF dinhtrai = new PointF((float)(10 * Math.Cos(rad+Math.PI/2)), (float)(10 * Math.Sin(rad+Math.PI/2)));
            PointF dinhphai = new PointF((float)(10 * Math.Cos(rad+3*Math.PI/2)), (float)(10 * Math.Sin(rad+3*Math.PI/2)));
            PointF dinhduoi=new PointF((float)(25 * Math.Cos(rad+Math.PI)), (float)(25 * Math.Sin(rad+Math.PI)));
            PointF dinhtren = new PointF((float)(145 * Math.Cos(rad)), (float)(145 * Math.Sin(rad)));
            VeHinhThoi(dinhtrai, dinhphai, dinhtren, dinhduoi);
            //g.DrawLine(pen, 0, 0, (float)(145 * Math.Cos(rad)), (float)(145 * Math.Sin(rad)));
            
        }
        void VeHinhThoi(PointF dinhtrai,PointF dinhphai,PointF dinhtren,PointF dinhduoi)
        {
            Pen pen = new Pen(Color.White, 2);
            g.DrawLine(pen, dinhduoi, dinhtrai);
            g.DrawLine(pen, dinhduoi, dinhphai);
            g.DrawLine(pen, dinhtrai, dinhtren);
            g.DrawLine(pen, dinhphai, dinhtren);
            //PointF[] list = { dinhtren, dinhphai, dinhduoi, dinhtrai };
            //g.FillPolygon(new SolidBrush(color),list);
        }
    }
}

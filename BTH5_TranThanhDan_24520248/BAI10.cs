using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH5_TranThanhDan_24520248
{
    public partial class BAI10 : Form
    {
        Pen pen;
        bool drawmode = false;
        Point start;
        Point end;
        Bitmap canvas;

        public BAI10()
        {
            InitializeComponent();
            this.Load += BAI10_Load;
            pen = new Pen(Color.Red);

            LoadData();

            pictureBox1.MouseDown += ChuotXuong;
            pictureBox1.MouseUp += ChuotLen;
            pictureBox1.MouseMove += ChuotDiChuyen;
            pictureBox1.Paint += PictureBox1_Paint;
        }

        private void BAI10_Load(object? sender, EventArgs e)
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = canvas;
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!drawmode) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(pen, start, end);
            Point v1 = new Point(start.X + 80, start.Y + 100);
            Point v2 = new Point(start.X + 160, start.Y + 20);
            Point[] vshape = { new Point(start.X, start.Y + 20), v1, v2 };
            e.Graphics.DrawLines(pen, vshape);
        }
        private void ChuotDiChuyen(object sender, MouseEventArgs e)
        {
            if (drawmode)
            {
                end = new Point(e.X, e.Y);
                pictureBox1.Invalidate();
            }
        }
        private void ChuotXuong(object sender, MouseEventArgs e)
        {
            pen.DashStyle = (DashStyle)comboBoxdashstyle.SelectedItem;
            pen.DashCap = (DashCap)comboBoxdashcap.SelectedItem;
            pen.EndCap = (LineCap)comboBoxendcap.SelectedItem;
            pen.StartCap = (LineCap)comboBoxstartcap.SelectedItem;
            pen.LineJoin = (LineJoin)comboBoxlinejoin.SelectedItem;
            pen.Width = 5;
            if (int.TryParse(comboBoxwidth.Text, out int temp))
                pen.Width = temp;

            drawmode = true;
            start = new Point(e.X, e.Y);
            end = start;

            pictureBox1.Invalidate();
        }
        private void ChuotLen(object sender, MouseEventArgs e)
        {
            drawmode = false;
            end = new Point(e.X, e.Y);

            using (Graphics c = Graphics.FromImage(canvas))
            {
                c.SmoothingMode = SmoothingMode.AntiAlias;
                c.DrawLine(pen, start, end);
                Point v1 = new Point(start.X + 80, start.Y + 100);
                Point v2 = new Point(start.X + 160, start.Y+20);
                Point[] vshape = { new Point(start.X,start.Y+20), v1, v2 };
                c.DrawLines(pen, vshape);
            }

            pictureBox1.Image = canvas;
            pictureBox1.Invalidate();
        }
        void LoadData()
        {
            comboBoxdashstyle.DataSource=Enum.GetValues(typeof(DashStyle));
            comboBoxdashcap.DataSource=Enum.GetValues(typeof(DashCap));
            comboBoxlinejoin.DataSource=Enum.GetValues(typeof(LineJoin));
            comboBoxstartcap.DataSource=Enum.GetValues(typeof(LineCap));
            comboBoxendcap.DataSource=Enum.GetValues(typeof(LineCap));
            for (int i = 1;i<20;i++)
            {
                comboBoxwidth.Items.Add(i.ToString());
            }
        }


    }
}

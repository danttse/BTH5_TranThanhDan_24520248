using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH5_TranThanhDan_24520248
{
    public partial class BAI11 : Form
    {
        Bitmap canvas;
        bool DrawMode = false;
        Point start;
        Point end;
        Pen pen;
        Brush brush;
        Color colorLine=Color.Black;
        public BAI11()
        {
            InitializeComponent();
            this.Load += BAI11_Load;
            pictureBox1.MouseDown += ChuotXuong;
            pictureBox1.MouseUp += ChuotLen;
            pictureBox1.MouseMove += ChuotDiChuyen;
            pictureBox1.Paint += PictureBox1_Paint;
            buttonColor.Click += (_, _) =>
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                    colorLine = colorDialog.Color;
            };
        }

        private void PictureBox1_Paint(object? sender, PaintEventArgs e)
        {
            VeHinh(e.Graphics);
        }

        void ChuotXuong(object sender, MouseEventArgs e)
        {
            DrawMode=true;
            start=new Point(e.X, e.Y);
        }
        void ChuotLen(object sender, MouseEventArgs e)
        {
            DrawMode = false;
            end=new Point(e.X, e.Y);
            using (Graphics g = Graphics.FromImage(canvas))
            {
                VeHinh(g);
            }
            pictureBox1.Image = canvas;
        }
        void ChuotDiChuyen(object sender, MouseEventArgs e)
        {
            if (DrawMode)
            {
                end=new Point(e.X,e.Y);
                pictureBox1.Invalidate();
            }
        }
        void VeHinh(Graphics g)
        {
            Rectangle rect = new Rectangle(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y), Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
            if (radioButtonLine.Checked)
            {
                if (textBoxWidthLine.Text.Length == 0)
                {
                    MessageBox.Show("Vui long nhap do day net ve duong thang!");
                    return;
                }
                int w = int.Parse(textBoxWidthLine.Text);
                Pen pen = new Pen(colorLine, w);
                g.DrawLine(pen, start, end);
            }
            else
            {
                if (radioButtonSolidBrush.Checked)
                {
                    brush = new SolidBrush(Color.Green);
                }
                else
                if (radioButtonHatchBrush.Checked)
                {
                    brush = new HatchBrush(HatchStyle.Horizontal, Color.Blue, Color.Green);
                }
                else
                if (radioButtonLinearBrush.Checked)
                {
                    brush = new LinearGradientBrush(rect, Color.Red, Color.Green, LinearGradientMode.Vertical);
                }
                else
                if (radioButtonTextureBrush.Checked)
                {
                    brush = new TextureBrush(Properties.Resources.TextureBrushExample);
                }
                if (radioButtonRectangle.Checked)
                {
                    g.FillRectangle(brush, rect);
                } else
                if (radioButtonEllipse.Checked)
                {
                    g.FillEllipse(brush, rect);
                }    
            }
        }

        private void BAI11_Load(object? sender, EventArgs e)
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH5_TranThanhDan_24520248
{
    public partial class BAI04 : Form
    {
        string fontfamily;
        int size;
        FontStyle style;
        string s = "Hello";
        Color color;
        StringFormat stringformat;

        public BAI04()
        {
            InitializeComponent();
            fontfamily = "Time New Roman";
            size = 11;
            style = FontStyle.Regular;
            color = Color.Black;
            stringformat = StringFormat.GenericTypographic;
            Vechu();
            SetUpData();
            toolStripButtonColor.BackColor=Color.Black;
            toolStripComboBoxFont.SelectedIndexChanged += (_, _) =>
            {
                fontfamily = toolStripComboBoxFont.Text;
                Vechu();
            };
            toolStripComboBoxSize.SelectedIndexChanged += (_, _) =>
            {
                size = int.Parse(toolStripComboBoxSize.Text);
                Vechu();
            };
            radioButtonLeftAlign.CheckedChanged += (_, _) =>
            {
                stringformat.Alignment = StringAlignment.Near;
                Vechu();
            };
            radioButtonRightAlign.CheckedChanged += (_, _) =>
            {
                stringformat.Alignment = StringAlignment.Far;
                Vechu();
            };
            radioButtonCenterAlign.CheckedChanged += (_, _) =>
            {
                stringformat.Alignment = StringAlignment.Center;
                Vechu();
            };
            checkBoxBold.CheckedChanged += (_, _) =>
            {
                style = style ^ FontStyle.Bold;
                Vechu();
            };
            checkBoxItalic.CheckedChanged += (_, _) =>
            {
                style = style ^ FontStyle.Italic;
                Vechu();
            };
            checkBoxUnderLine.CheckedChanged += (_, _) =>
            {
                style = style^FontStyle.Underline;
                Vechu();
            };
            toolStripButtonColor.Click += Chonmau;
        }
        void SetUpData()
        {
            InstalledFontCollection ListFont = new InstalledFontCollection();
            foreach(var font in ListFont.Families)
            {
                toolStripComboBoxFont.Items.Add(font.Name);
            }
            int[] ListSize = new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var i in ListSize)
            {
                toolStripComboBoxSize.Items.Add(i.ToString());
            }
        }
        void Vechu()
        {
            //panel1.CreateGraphics();
            Graphics g=panel1.CreateGraphics();
            g.Clear(Color.White);
            Font font = new Font(fontfamily, size, style);
            Brush brush = new SolidBrush(color);
            g.DrawString(s, font, brush, new RectangleF(0, 0, panel1.Width, panel1.Height), stringformat);
        }
        void Chonmau(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripButtonColor.BackColor = colorDialog.Color;
                color=colorDialog.Color;
                Vechu();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH5_TranThanhDan_24520248
{
    public partial class BAI06 : Form
    {
        public BAI06()
        {
            InitializeComponent();
            LoadFont();
        }
        void LoadFont()
        {
            InstalledFontCollection families = new InstalledFontCollection();
            foreach (var f in families.Families)
            {
                listBox1.Items.Add(f.Name);
            }
            listBox1.DrawMode= DrawMode.OwnerDrawFixed;
            listBox1.DrawItem += ListBox1_DrawItem;
            listBox1.ItemHeight = 40;
        }

        private void ListBox1_DrawItem(object? sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            string fname = listBox1.Items[e.Index].ToString();
            Font font = new Font(fname, 16);
            Brush brush = new SolidBrush(Color.Black);
            e.Graphics.DrawString(fname,font,brush,e.Bounds);
            e.DrawFocusRectangle();
        }
    }
}

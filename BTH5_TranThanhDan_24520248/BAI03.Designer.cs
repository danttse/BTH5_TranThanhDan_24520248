namespace BTH5_TranThanhDan_24520248
{
    partial class BAI03
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Incbutton = new Button();
            Decbutton = new Button();
            SuspendLayout();
            // 
            // Incbutton
            // 
            Incbutton.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Incbutton.Location = new Point(12, 12);
            Incbutton.Name = "Incbutton";
            Incbutton.Size = new Size(150, 50);
            Incbutton.TabIndex = 0;
            Incbutton.Text = "+";
            Incbutton.UseVisualStyleBackColor = true;
            // 
            // Decbutton
            // 
            Decbutton.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Decbutton.Location = new Point(192, 12);
            Decbutton.Name = "Decbutton";
            Decbutton.Size = new Size(150, 50);
            Decbutton.TabIndex = 1;
            Decbutton.Text = "-";
            Decbutton.UseVisualStyleBackColor = true;
            // 
            // BAI03
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Decbutton);
            Controls.Add(Incbutton);
            Name = "BAI03";
            Text = "BAI03";
            ResumeLayout(false);
        }

        #endregion

        private Button Incbutton;
        private Button Decbutton;
    }
}
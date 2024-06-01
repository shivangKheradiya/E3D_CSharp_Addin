namespace E3DAddIn_8
{
    partial class NetGridAddinControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.CE_Mem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 247);
            this.panel1.TabIndex = 0;
            // 
            // CE_Mem
            // 
            this.CE_Mem.Location = new System.Drawing.Point(3, 250);
            this.CE_Mem.Name = "CE_Mem";
            this.CE_Mem.Size = new System.Drawing.Size(91, 23);
            this.CE_Mem.TabIndex = 0;
            this.CE_Mem.Text = "CE Mem";
            this.CE_Mem.UseVisualStyleBackColor = true;
            this.CE_Mem.Click += new System.EventHandler(this.Add_CE_Mem_Click);
            // 
            // NetGridAddinControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CE_Mem);
            this.Controls.Add(this.panel1);
            this.Name = "NetGridAddinControl";
            this.Size = new System.Drawing.Size(262, 276);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CE_Mem;
    }
}

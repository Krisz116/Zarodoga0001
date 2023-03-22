namespace Zarodoga
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_Dock = new System.Windows.Forms.Button();
            this.Button_Diak = new System.Windows.Forms.Button();
            this.button_ki_be = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Dock
            // 
            this.button_Dock.BackColor = System.Drawing.Color.Transparent;
            this.button_Dock.ForeColor = System.Drawing.Color.Black;
            this.button_Dock.Location = new System.Drawing.Point(90, 156);
            this.button_Dock.Name = "button_Dock";
            this.button_Dock.Size = new System.Drawing.Size(97, 158);
            this.button_Dock.TabIndex = 1;
            this.button_Dock.Text = "Dockumentumok";
            this.button_Dock.UseVisualStyleBackColor = false;
            this.button_Dock.Click += new System.EventHandler(this.button_Dock_Click);
            // 
            // Button_Diak
            // 
            this.Button_Diak.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Diak.Location = new System.Drawing.Point(284, 156);
            this.Button_Diak.Name = "Button_Diak";
            this.Button_Diak.Size = new System.Drawing.Size(97, 158);
            this.Button_Diak.TabIndex = 2;
            this.Button_Diak.Text = "Diak";
            this.Button_Diak.UseVisualStyleBackColor = true;
            this.Button_Diak.Click += new System.EventHandler(this.Button_Diak_Click);
            // 
            // button_ki_be
            // 
            this.button_ki_be.Location = new System.Drawing.Point(482, 156);
            this.button_ki_be.Name = "button_ki_be";
            this.button_ki_be.Size = new System.Drawing.Size(97, 158);
            this.button_ki_be.TabIndex = 3;
            this.button_ki_be.Text = "Ki/Be Iratkozás";
            this.button_ki_be.UseVisualStyleBackColor = true;
            this.button_ki_be.Click += new System.EventHandler(this.button_ki_be_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(653, 450);
            this.Controls.Add(this.button_ki_be);
            this.Controls.Add(this.Button_Diak);
            this.Controls.Add(this.button_Dock);
            this.Name = "Form1";
            this.Text = "Kezdőlap";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Dock;
        private System.Windows.Forms.Button Button_Diak;
        private System.Windows.Forms.Button button_ki_be;
    }
}


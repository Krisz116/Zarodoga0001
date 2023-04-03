namespace Zarodoga
{
    partial class Dock_Form
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_torol = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_nev = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_dock_nev = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_ig_szam = new System.Windows.Forms.TextBox();
            this.button_keres = new System.Windows.Forms.Button();
            this.button_keresestorlese = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.button_frissit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(248, 433);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(640, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Hozzáadd";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(640, 26);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(118, 23);
            this.button_update.TabIndex = 2;
            this.button_update.Text = "Szerkeszt";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_torol
            // 
            this.button_torol.Location = new System.Drawing.Point(640, 116);
            this.button_torol.Name = "button_torol";
            this.button_torol.Size = new System.Drawing.Size(118, 22);
            this.button_torol.TabIndex = 3;
            this.button_torol.Text = "Töröl";
            this.button_torol.UseVisualStyleBackColor = true;
            this.button_torol.Click += new System.EventHandler(this.button_torol_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(286, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Név";
            // 
            // textBox_nev
            // 
            this.textBox_nev.Location = new System.Drawing.Point(374, 71);
            this.textBox_nev.Name = "textBox_nev";
            this.textBox_nev.Size = new System.Drawing.Size(177, 20);
            this.textBox_nev.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(257, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Dock_Név";
            // 
            // comboBox_dock_nev
            // 
            this.comboBox_dock_nev.FormattingEnabled = true;
            this.comboBox_dock_nev.Items.AddRange(new object[] {
            "Of_jell",
            "Viszajell_lap",
            "Hianyzas",
            "Elhelyezes_Ugy"});
            this.comboBox_dock_nev.Location = new System.Drawing.Point(374, 116);
            this.comboBox_dock_nev.Name = "comboBox_dock_nev";
            this.comboBox_dock_nev.Size = new System.Drawing.Size(177, 21);
            this.comboBox_dock_nev.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(257, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Diak IG Szam";
            // 
            // textBox_ig_szam
            // 
            this.textBox_ig_szam.Location = new System.Drawing.Point(374, 31);
            this.textBox_ig_szam.Name = "textBox_ig_szam";
            this.textBox_ig_szam.Size = new System.Drawing.Size(177, 20);
            this.textBox_ig_szam.TabIndex = 12;
            // 
            // button_keres
            // 
            this.button_keres.Location = new System.Drawing.Point(374, 170);
            this.button_keres.Name = "button_keres";
            this.button_keres.Size = new System.Drawing.Size(75, 39);
            this.button_keres.TabIndex = 13;
            this.button_keres.Text = "Keresés";
            this.button_keres.UseVisualStyleBackColor = true;
            this.button_keres.Click += new System.EventHandler(this.button_keres_Click);
            // 
            // button_keresestorlese
            // 
            this.button_keresestorlese.Location = new System.Drawing.Point(476, 170);
            this.button_keresestorlese.Name = "button_keresestorlese";
            this.button_keresestorlese.Size = new System.Drawing.Size(75, 39);
            this.button_keresestorlese.TabIndex = 14;
            this.button_keresestorlese.Text = "Keresés törlése";
            this.button_keresestorlese.UseVisualStyleBackColor = true;
            this.button_keresestorlese.Click += new System.EventHandler(this.button_keresestorlese_Click);
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(683, 397);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(105, 41);
            this.button_back.TabIndex = 15;
            this.button_back.Text = "Vissza";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_frissit
            // 
            this.button_frissit.Location = new System.Drawing.Point(572, 397);
            this.button_frissit.Name = "button_frissit";
            this.button_frissit.Size = new System.Drawing.Size(105, 41);
            this.button_frissit.TabIndex = 16;
            this.button_frissit.Text = "Frissítés";
            this.button_frissit.UseVisualStyleBackColor = true;
            this.button_frissit.Click += new System.EventHandler(this.button_frissit_Click);
            // 
            // Dock_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_frissit);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_keresestorlese);
            this.Controls.Add(this.button_keres);
            this.Controls.Add(this.textBox_ig_szam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_dock_nev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_nev);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_torol);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "Dock_Form";
            this.Text = "Documentumok";
            this.Load += new System.EventHandler(this.Dock_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_nev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button_torol;
        public System.Windows.Forms.Button button_update;
        public System.Windows.Forms.ComboBox comboBox_dock_nev;
        public System.Windows.Forms.TextBox textBox_ig_szam;
        private System.Windows.Forms.Button button_keres;
        private System.Windows.Forms.Button button_keresestorlese;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_frissit;
    }
}
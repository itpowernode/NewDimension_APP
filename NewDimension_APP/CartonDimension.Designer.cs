namespace NewDimension_APP
{
    partial class CartonDimension
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartonDimension));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_cartonid = new System.Windows.Forms.TextBox();
            this.button_insertupdate = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.numericUpDown_length_in = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_width_in = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_height_in = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_length_cm = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_width_cm = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_height_cm = new System.Windows.Forms.NumericUpDown();
            this.checkBox_inactive = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_length_in)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_width_in)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_height_in)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_length_cm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_width_cm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_height_cm)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carton";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Carton ID*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Length (IN)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Width (IN)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Height (IN)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Length (CM)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Width (CM)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(310, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Height (CM)";
            // 
            // textBox_cartonid
            // 
            this.textBox_cartonid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_cartonid.Location = new System.Drawing.Point(141, 83);
            this.textBox_cartonid.MaxLength = 20;
            this.textBox_cartonid.Name = "textBox_cartonid";
            this.textBox_cartonid.Size = new System.Drawing.Size(152, 22);
            this.textBox_cartonid.TabIndex = 8;
            this.textBox_cartonid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_cartonid_KeyDown);
            this.textBox_cartonid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_cartonid_KeyPress);
            // 
            // button_insertupdate
            // 
            this.button_insertupdate.BackColor = System.Drawing.Color.Ivory;
            this.button_insertupdate.Location = new System.Drawing.Point(374, 257);
            this.button_insertupdate.Name = "button_insertupdate";
            this.button_insertupdate.Size = new System.Drawing.Size(75, 31);
            this.button_insertupdate.TabIndex = 23;
            this.button_insertupdate.Text = "Insert";
            this.button_insertupdate.UseVisualStyleBackColor = false;
            this.button_insertupdate.Click += new System.EventHandler(this.button_insertupdate_Click);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_clear.Location = new System.Drawing.Point(470, 257);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 31);
            this.button_clear.TabIndex = 24;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // numericUpDown_length_in
            // 
            this.numericUpDown_length_in.DecimalPlaces = 2;
            this.numericUpDown_length_in.Location = new System.Drawing.Point(141, 121);
            this.numericUpDown_length_in.Maximum = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.numericUpDown_length_in.Name = "numericUpDown_length_in";
            this.numericUpDown_length_in.Size = new System.Drawing.Size(152, 22);
            this.numericUpDown_length_in.TabIndex = 16;
            this.numericUpDown_length_in.ValueChanged += new System.EventHandler(this.numericUpDown_length_in_ValueChanged);
            this.numericUpDown_length_in.Enter += new System.EventHandler(this.numericUpDown_length_in_Enter);
            this.numericUpDown_length_in.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_length_in_KeyDown);
            this.numericUpDown_length_in.Leave += new System.EventHandler(this.numericUpDown_length_in_Leave);
            // 
            // numericUpDown_width_in
            // 
            this.numericUpDown_width_in.DecimalPlaces = 2;
            this.numericUpDown_width_in.Location = new System.Drawing.Point(141, 163);
            this.numericUpDown_width_in.Maximum = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.numericUpDown_width_in.Name = "numericUpDown_width_in";
            this.numericUpDown_width_in.Size = new System.Drawing.Size(152, 22);
            this.numericUpDown_width_in.TabIndex = 17;
            this.numericUpDown_width_in.ValueChanged += new System.EventHandler(this.numericUpDown_width_in_ValueChanged);
            this.numericUpDown_width_in.Enter += new System.EventHandler(this.numericUpDown_width_in_Enter);
            this.numericUpDown_width_in.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_width_in_KeyDown);
            this.numericUpDown_width_in.Leave += new System.EventHandler(this.numericUpDown_width_in_Leave);
            // 
            // numericUpDown_height_in
            // 
            this.numericUpDown_height_in.DecimalPlaces = 2;
            this.numericUpDown_height_in.Location = new System.Drawing.Point(141, 202);
            this.numericUpDown_height_in.Maximum = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.numericUpDown_height_in.Name = "numericUpDown_height_in";
            this.numericUpDown_height_in.Size = new System.Drawing.Size(152, 22);
            this.numericUpDown_height_in.TabIndex = 18;
            this.numericUpDown_height_in.ValueChanged += new System.EventHandler(this.numericUpDown_height_in_ValueChanged);
            this.numericUpDown_height_in.Enter += new System.EventHandler(this.numericUpDown_height_in_Enter);
            this.numericUpDown_height_in.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_height_in_KeyDown);
            this.numericUpDown_height_in.Leave += new System.EventHandler(this.numericUpDown_height_in_Leave);
            // 
            // numericUpDown_length_cm
            // 
            this.numericUpDown_length_cm.DecimalPlaces = 2;
            this.numericUpDown_length_cm.Location = new System.Drawing.Point(393, 121);
            this.numericUpDown_length_cm.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_length_cm.Name = "numericUpDown_length_cm";
            this.numericUpDown_length_cm.Size = new System.Drawing.Size(152, 22);
            this.numericUpDown_length_cm.TabIndex = 19;
            this.numericUpDown_length_cm.ValueChanged += new System.EventHandler(this.numericUpDown_length_cm_ValueChanged);
            this.numericUpDown_length_cm.Enter += new System.EventHandler(this.numericUpDown_length_cm_Enter);
            this.numericUpDown_length_cm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_length_cm_KeyDown);
            this.numericUpDown_length_cm.Leave += new System.EventHandler(this.numericUpDown_length_cm_Leave);
            // 
            // numericUpDown_width_cm
            // 
            this.numericUpDown_width_cm.DecimalPlaces = 2;
            this.numericUpDown_width_cm.Location = new System.Drawing.Point(393, 161);
            this.numericUpDown_width_cm.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_width_cm.Name = "numericUpDown_width_cm";
            this.numericUpDown_width_cm.Size = new System.Drawing.Size(152, 22);
            this.numericUpDown_width_cm.TabIndex = 20;
            this.numericUpDown_width_cm.ValueChanged += new System.EventHandler(this.numericUpDown_width_cm_ValueChanged);
            this.numericUpDown_width_cm.Enter += new System.EventHandler(this.numericUpDown_width_cm_Enter);
            this.numericUpDown_width_cm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_width_cm_KeyDown);
            this.numericUpDown_width_cm.Leave += new System.EventHandler(this.numericUpDown_width_cm_Leave);
            // 
            // numericUpDown_height_cm
            // 
            this.numericUpDown_height_cm.DecimalPlaces = 2;
            this.numericUpDown_height_cm.Location = new System.Drawing.Point(393, 202);
            this.numericUpDown_height_cm.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_height_cm.Name = "numericUpDown_height_cm";
            this.numericUpDown_height_cm.Size = new System.Drawing.Size(152, 22);
            this.numericUpDown_height_cm.TabIndex = 21;
            this.numericUpDown_height_cm.ValueChanged += new System.EventHandler(this.numericUpDown_height_cm_ValueChanged);
            this.numericUpDown_height_cm.Enter += new System.EventHandler(this.numericUpDown_height_cm_Enter);
            this.numericUpDown_height_cm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_height_cm_KeyDown);
            this.numericUpDown_height_cm.Leave += new System.EventHandler(this.numericUpDown_height_cm_Leave);
            // 
            // checkBox_inactive
            // 
            this.checkBox_inactive.AutoSize = true;
            this.checkBox_inactive.Location = new System.Drawing.Point(141, 250);
            this.checkBox_inactive.Name = "checkBox_inactive";
            this.checkBox_inactive.Size = new System.Drawing.Size(72, 20);
            this.checkBox_inactive.TabIndex = 22;
            this.checkBox_inactive.Text = "Inactive";
            this.checkBox_inactive.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(295, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(237, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "*Only alphabetic and numeric characters allowed";
            // 
            // CartonDimension
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 321);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.checkBox_inactive);
            this.Controls.Add(this.numericUpDown_height_cm);
            this.Controls.Add(this.numericUpDown_width_cm);
            this.Controls.Add(this.numericUpDown_length_cm);
            this.Controls.Add(this.numericUpDown_height_in);
            this.Controls.Add(this.numericUpDown_width_in);
            this.Controls.Add(this.numericUpDown_length_in);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_insertupdate);
            this.Controls.Add(this.textBox_cartonid);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(626, 360);
            this.MinimumSize = new System.Drawing.Size(626, 360);
            this.Name = "CartonDimension";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Carton";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CartonDimension_FormClosed);
            this.Load += new System.EventHandler(this.CartonDimension_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_length_in)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_width_in)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_height_in)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_length_cm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_width_cm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_height_cm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_cartonid;
        private System.Windows.Forms.Button button_insertupdate;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.NumericUpDown numericUpDown_length_in;
        private System.Windows.Forms.NumericUpDown numericUpDown_width_in;
        private System.Windows.Forms.NumericUpDown numericUpDown_height_in;
        private System.Windows.Forms.NumericUpDown numericUpDown_length_cm;
        private System.Windows.Forms.NumericUpDown numericUpDown_width_cm;
        private System.Windows.Forms.NumericUpDown numericUpDown_height_cm;
        private System.Windows.Forms.CheckBox checkBox_inactive;
        private System.Windows.Forms.Label label9;
    }
}
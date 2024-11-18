namespace NewDimension_APP
{
    partial class ProductDimension
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductDimension));
            this.button_clear = new System.Windows.Forms.Button();
            this.button_insertupdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_sku = new System.Windows.Forms.TextBox();
            this.textBox_upc = new System.Windows.Forms.TextBox();
            this.textBox_productname = new System.Windows.Forms.TextBox();
            this.numericUpDown_length_in = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_width_in = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_height_in = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_weight_lb = new System.Windows.Forms.NumericUpDown();
            this.comboBox_shoetype = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_length_in)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_width_in)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_height_in)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_weight_lb)).BeginInit();
            this.SuspendLayout();
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_clear.Location = new System.Drawing.Point(494, 286);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 31);
            this.button_clear.TabIndex = 44;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_insertupdate
            // 
            this.button_insertupdate.BackColor = System.Drawing.Color.Ivory;
            this.button_insertupdate.Location = new System.Drawing.Point(403, 286);
            this.button_insertupdate.Name = "button_insertupdate";
            this.button_insertupdate.Size = new System.Drawing.Size(75, 31);
            this.button_insertupdate.TabIndex = 43;
            this.button_insertupdate.Text = "Insert";
            this.button_insertupdate.UseVisualStyleBackColor = false;
            this.button_insertupdate.Click += new System.EventHandler(this.button_insertupdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Shoe Type*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "SKU*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "UPC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Product Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(283, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 16);
            this.label9.TabIndex = 33;
            this.label9.Text = "Package Height (IN)*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(288, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 16);
            this.label10.TabIndex = 32;
            this.label10.Text = "Package Width (IN)*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(282, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 16);
            this.label11.TabIndex = 31;
            this.label11.Text = "Package Length (IN)*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(277, 203);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 16);
            this.label12.TabIndex = 34;
            this.label12.Text = "Package Weight (LB)*";
            // 
            // textBox_sku
            // 
            this.textBox_sku.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_sku.Location = new System.Drawing.Point(122, 122);
            this.textBox_sku.MaxLength = 50;
            this.textBox_sku.Name = "textBox_sku";
            this.textBox_sku.Size = new System.Drawing.Size(152, 22);
            this.textBox_sku.TabIndex = 36;
            this.textBox_sku.Enter += new System.EventHandler(this.textBox_sku_Enter);
            this.textBox_sku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_sku_KeyDown);
            // 
            // textBox_upc
            // 
            this.textBox_upc.Location = new System.Drawing.Point(122, 161);
            this.textBox_upc.MaxLength = 20;
            this.textBox_upc.Name = "textBox_upc";
            this.textBox_upc.Size = new System.Drawing.Size(152, 22);
            this.textBox_upc.TabIndex = 37;
            this.textBox_upc.Enter += new System.EventHandler(this.textBox_upc_Enter);
            this.textBox_upc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_upc_KeyDown);
            this.textBox_upc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_upc_KeyPress);
            // 
            // textBox_productname
            // 
            this.textBox_productname.Location = new System.Drawing.Point(122, 200);
            this.textBox_productname.MaxLength = 200;
            this.textBox_productname.Multiline = true;
            this.textBox_productname.Name = "textBox_productname";
            this.textBox_productname.Size = new System.Drawing.Size(152, 59);
            this.textBox_productname.TabIndex = 38;
            this.textBox_productname.Enter += new System.EventHandler(this.textBox_productname_Enter);
            this.textBox_productname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_productname_KeyDown);
            // 
            // numericUpDown_length_in
            // 
            this.numericUpDown_length_in.DecimalPlaces = 2;
            this.numericUpDown_length_in.Location = new System.Drawing.Point(417, 82);
            this.numericUpDown_length_in.Maximum = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.numericUpDown_length_in.Name = "numericUpDown_length_in";
            this.numericUpDown_length_in.Size = new System.Drawing.Size(152, 22);
            this.numericUpDown_length_in.TabIndex = 39;
            this.numericUpDown_length_in.ValueChanged += new System.EventHandler(this.numericUpDown_length_in_ValueChanged);
            this.numericUpDown_length_in.Enter += new System.EventHandler(this.numericUpDown_length_in_Enter);
            this.numericUpDown_length_in.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_length_in_KeyDown);
            // 
            // numericUpDown_width_in
            // 
            this.numericUpDown_width_in.DecimalPlaces = 2;
            this.numericUpDown_width_in.Location = new System.Drawing.Point(417, 122);
            this.numericUpDown_width_in.Maximum = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.numericUpDown_width_in.Name = "numericUpDown_width_in";
            this.numericUpDown_width_in.Size = new System.Drawing.Size(152, 22);
            this.numericUpDown_width_in.TabIndex = 40;
            this.numericUpDown_width_in.ValueChanged += new System.EventHandler(this.numericUpDown_width_in_ValueChanged);
            this.numericUpDown_width_in.Enter += new System.EventHandler(this.numericUpDown_width_in_Enter);
            this.numericUpDown_width_in.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_width_in_KeyDown);
            // 
            // numericUpDown_height_in
            // 
            this.numericUpDown_height_in.DecimalPlaces = 2;
            this.numericUpDown_height_in.Location = new System.Drawing.Point(417, 161);
            this.numericUpDown_height_in.Maximum = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.numericUpDown_height_in.Name = "numericUpDown_height_in";
            this.numericUpDown_height_in.Size = new System.Drawing.Size(152, 22);
            this.numericUpDown_height_in.TabIndex = 41;
            this.numericUpDown_height_in.ValueChanged += new System.EventHandler(this.numericUpDown_height_in_ValueChanged);
            this.numericUpDown_height_in.Enter += new System.EventHandler(this.numericUpDown_height_in_Enter);
            this.numericUpDown_height_in.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_height_in_KeyDown);
            // 
            // numericUpDown_weight_lb
            // 
            this.numericUpDown_weight_lb.DecimalPlaces = 2;
            this.numericUpDown_weight_lb.Location = new System.Drawing.Point(417, 200);
            this.numericUpDown_weight_lb.Maximum = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.numericUpDown_weight_lb.Name = "numericUpDown_weight_lb";
            this.numericUpDown_weight_lb.Size = new System.Drawing.Size(152, 22);
            this.numericUpDown_weight_lb.TabIndex = 42;
            this.numericUpDown_weight_lb.ValueChanged += new System.EventHandler(this.numericUpDown_weight_lb_ValueChanged);
            this.numericUpDown_weight_lb.Enter += new System.EventHandler(this.numericUpDown_weight_lb_Enter);
            this.numericUpDown_weight_lb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_weight_lb_KeyDown);
            // 
            // comboBox_shoetype
            // 
            this.comboBox_shoetype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_shoetype.FormattingEnabled = true;
            this.comboBox_shoetype.Items.AddRange(new object[] {
            "MensWomens",
            "Childrens"});
            this.comboBox_shoetype.Location = new System.Drawing.Point(122, 82);
            this.comboBox_shoetype.Name = "comboBox_shoetype";
            this.comboBox_shoetype.Size = new System.Drawing.Size(152, 24);
            this.comboBox_shoetype.TabIndex = 35;
            // 
            // ProductDimension
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 348);
            this.Controls.Add(this.comboBox_shoetype);
            this.Controls.Add(this.numericUpDown_weight_lb);
            this.Controls.Add(this.numericUpDown_height_in);
            this.Controls.Add(this.numericUpDown_width_in);
            this.Controls.Add(this.numericUpDown_length_in);
            this.Controls.Add(this.textBox_productname);
            this.Controls.Add(this.textBox_upc);
            this.Controls.Add(this.textBox_sku);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_insertupdate);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(633, 387);
            this.MinimumSize = new System.Drawing.Size(633, 387);
            this.Name = "ProductDimension";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Product";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProductDimension_FormClosed);
            this.Load += new System.EventHandler(this.ProductDimension_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_length_in)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_width_in)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_height_in)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_weight_lb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_insertupdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_sku;
        private System.Windows.Forms.TextBox textBox_upc;
        private System.Windows.Forms.TextBox textBox_productname;
        private System.Windows.Forms.NumericUpDown numericUpDown_length_in;
        private System.Windows.Forms.NumericUpDown numericUpDown_width_in;
        private System.Windows.Forms.NumericUpDown numericUpDown_height_in;
        private System.Windows.Forms.NumericUpDown numericUpDown_weight_lb;
        private System.Windows.Forms.ComboBox comboBox_shoetype;
    }
}
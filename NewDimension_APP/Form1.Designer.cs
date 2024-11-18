namespace NewDimension_APP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl_home = new System.Windows.Forms.TabControl();
            this.tabPage_carton = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_newcarton = new System.Windows.Forms.Button();
            this.dataGridView_carton = new System.Windows.Forms.DataGridView();
            this.Column_carton_active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_cartonid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_carton_l_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_carton_w_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_carton_h_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_carton_l_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_carton_w_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_carton_h_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage_product = new System.Windows.Forms.TabPage();
            this.button_product_export = new System.Windows.Forms.Button();
            this.button_product_reload = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_product_sku = new System.Windows.Forms.TextBox();
            this.dataGridView_product = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label_product_downloadtemplate = new System.Windows.Forms.Label();
            this.button_product_newimport = new System.Windows.Forms.Button();
            this.button_product_new = new System.Windows.Forms.Button();
            this.tabPage_holiday = new System.Windows.Forms.TabPage();
            this.numericUpDown_holiday_year = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.monthCalendar_holiday = new System.Windows.Forms.MonthCalendar();
            this.button_holiday_remove = new System.Windows.Forms.Button();
            this.button_holiday_add = new System.Windows.Forms.Button();
            this.dataGridView_holiday = new System.Windows.Forms.DataGridView();
            this.Column_holiday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl_home.SuspendLayout();
            this.tabPage_carton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_carton)).BeginInit();
            this.tabPage_product.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_product)).BeginInit();
            this.tabPage_holiday.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_holiday_year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_holiday)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_home
            // 
            this.tabControl_home.Controls.Add(this.tabPage_carton);
            this.tabControl_home.Controls.Add(this.tabPage_product);
            this.tabControl_home.Controls.Add(this.tabPage_holiday);
            this.tabControl_home.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_home.Location = new System.Drawing.Point(0, 0);
            this.tabControl_home.Name = "tabControl_home";
            this.tabControl_home.SelectedIndex = 0;
            this.tabControl_home.Size = new System.Drawing.Size(804, 411);
            this.tabControl_home.TabIndex = 0;
            this.tabControl_home.SelectedIndexChanged += new System.EventHandler(this.tabControl_home_SelectedIndexChanged);
            // 
            // tabPage_carton
            // 
            this.tabPage_carton.Controls.Add(this.label3);
            this.tabPage_carton.Controls.Add(this.label1);
            this.tabPage_carton.Controls.Add(this.button_newcarton);
            this.tabPage_carton.Controls.Add(this.dataGridView_carton);
            this.tabPage_carton.Location = new System.Drawing.Point(4, 25);
            this.tabPage_carton.Name = "tabPage_carton";
            this.tabPage_carton.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_carton.Size = new System.Drawing.Size(796, 382);
            this.tabPage_carton.TabIndex = 0;
            this.tabPage_carton.Text = "Carton";
            this.tabPage_carton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(325, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "*Double Click below and edit status in pop-up window.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Carton";
            // 
            // button_newcarton
            // 
            this.button_newcarton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_newcarton.BackColor = System.Drawing.Color.White;
            this.button_newcarton.Location = new System.Drawing.Point(682, 41);
            this.button_newcarton.Name = "button_newcarton";
            this.button_newcarton.Size = new System.Drawing.Size(92, 31);
            this.button_newcarton.TabIndex = 1;
            this.button_newcarton.Text = "New";
            this.button_newcarton.UseVisualStyleBackColor = false;
            this.button_newcarton.Click += new System.EventHandler(this.button_newcarton_Click);
            // 
            // dataGridView_carton
            // 
            this.dataGridView_carton.AllowUserToAddRows = false;
            this.dataGridView_carton.AllowUserToDeleteRows = false;
            this.dataGridView_carton.AllowUserToResizeRows = false;
            this.dataGridView_carton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_carton.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_carton.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_carton.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_carton.ColumnHeadersHeight = 28;
            this.dataGridView_carton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_carton.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_carton_active,
            this.Column_cartonid,
            this.Column_carton_l_in,
            this.Column_carton_w_in,
            this.Column_carton_h_in,
            this.Column_carton_l_cm,
            this.Column_carton_w_cm,
            this.Column_carton_h_cm});
            this.dataGridView_carton.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView_carton.Location = new System.Drawing.Point(3, 101);
            this.dataGridView_carton.MultiSelect = false;
            this.dataGridView_carton.Name = "dataGridView_carton";
            this.dataGridView_carton.ReadOnly = true;
            this.dataGridView_carton.RowHeadersVisible = false;
            this.dataGridView_carton.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_carton.Size = new System.Drawing.Size(790, 278);
            this.dataGridView_carton.TabIndex = 0;
            this.dataGridView_carton.TabStop = false;
            this.dataGridView_carton.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_carton_CellDoubleClick);
            // 
            // Column_carton_active
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_carton_active.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column_carton_active.HeaderText = "Active";
            this.Column_carton_active.Name = "Column_carton_active";
            this.Column_carton_active.ReadOnly = true;
            this.Column_carton_active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_carton_active.Width = 69;
            // 
            // Column_cartonid
            // 
            this.Column_cartonid.HeaderText = "Carton ID";
            this.Column_cartonid.Name = "Column_cartonid";
            this.Column_cartonid.ReadOnly = true;
            this.Column_cartonid.Width = 87;
            // 
            // Column_carton_l_in
            // 
            this.Column_carton_l_in.HeaderText = "Length (IN)";
            this.Column_carton_l_in.Name = "Column_carton_l_in";
            this.Column_carton_l_in.ReadOnly = true;
            this.Column_carton_l_in.Width = 96;
            // 
            // Column_carton_w_in
            // 
            this.Column_carton_w_in.HeaderText = "Width (IN)";
            this.Column_carton_w_in.Name = "Column_carton_w_in";
            this.Column_carton_w_in.ReadOnly = true;
            this.Column_carton_w_in.Width = 90;
            // 
            // Column_carton_h_in
            // 
            this.Column_carton_h_in.HeaderText = "Height (IN)";
            this.Column_carton_h_in.Name = "Column_carton_h_in";
            this.Column_carton_h_in.ReadOnly = true;
            this.Column_carton_h_in.Width = 95;
            // 
            // Column_carton_l_cm
            // 
            this.Column_carton_l_cm.HeaderText = "Length (CM)";
            this.Column_carton_l_cm.Name = "Column_carton_l_cm";
            this.Column_carton_l_cm.ReadOnly = true;
            this.Column_carton_l_cm.Width = 103;
            // 
            // Column_carton_w_cm
            // 
            this.Column_carton_w_cm.HeaderText = "Width (CM)";
            this.Column_carton_w_cm.Name = "Column_carton_w_cm";
            this.Column_carton_w_cm.ReadOnly = true;
            this.Column_carton_w_cm.Width = 97;
            // 
            // Column_carton_h_cm
            // 
            this.Column_carton_h_cm.HeaderText = "Height (CM)";
            this.Column_carton_h_cm.Name = "Column_carton_h_cm";
            this.Column_carton_h_cm.ReadOnly = true;
            this.Column_carton_h_cm.Width = 102;
            // 
            // tabPage_product
            // 
            this.tabPage_product.Controls.Add(this.button_product_export);
            this.tabPage_product.Controls.Add(this.button_product_reload);
            this.tabPage_product.Controls.Add(this.label6);
            this.tabPage_product.Controls.Add(this.textBox_product_sku);
            this.tabPage_product.Controls.Add(this.dataGridView_product);
            this.tabPage_product.Controls.Add(this.label2);
            this.tabPage_product.Controls.Add(this.label_product_downloadtemplate);
            this.tabPage_product.Controls.Add(this.button_product_newimport);
            this.tabPage_product.Controls.Add(this.button_product_new);
            this.tabPage_product.Location = new System.Drawing.Point(4, 25);
            this.tabPage_product.Name = "tabPage_product";
            this.tabPage_product.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_product.Size = new System.Drawing.Size(796, 382);
            this.tabPage_product.TabIndex = 1;
            this.tabPage_product.Text = "Product";
            this.tabPage_product.UseVisualStyleBackColor = true;
            // 
            // button_product_export
            // 
            this.button_product_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_product_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_product_export.Location = new System.Drawing.Point(588, 61);
            this.button_product_export.Name = "button_product_export";
            this.button_product_export.Size = new System.Drawing.Size(92, 31);
            this.button_product_export.TabIndex = 28;
            this.button_product_export.Text = "Export";
            this.button_product_export.UseVisualStyleBackColor = true;
            this.button_product_export.Click += new System.EventHandler(this.button_product_export_Click);
            // 
            // button_product_reload
            // 
            this.button_product_reload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_product_reload.Location = new System.Drawing.Point(374, 61);
            this.button_product_reload.Name = "button_product_reload";
            this.button_product_reload.Size = new System.Drawing.Size(92, 31);
            this.button_product_reload.TabIndex = 27;
            this.button_product_reload.Text = "Reload";
            this.button_product_reload.UseVisualStyleBackColor = true;
            this.button_product_reload.Click += new System.EventHandler(this.button_product_reload_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "SKU";
            // 
            // textBox_product_sku
            // 
            this.textBox_product_sku.Location = new System.Drawing.Point(64, 70);
            this.textBox_product_sku.Name = "textBox_product_sku";
            this.textBox_product_sku.Size = new System.Drawing.Size(140, 22);
            this.textBox_product_sku.TabIndex = 25;
            this.textBox_product_sku.TextChanged += new System.EventHandler(this.textBox_product_sku_TextChanged);
            this.textBox_product_sku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_product_sku_KeyDown);
            // 
            // dataGridView_product
            // 
            this.dataGridView_product.AllowUserToAddRows = false;
            this.dataGridView_product.AllowUserToDeleteRows = false;
            this.dataGridView_product.AllowUserToResizeRows = false;
            this.dataGridView_product.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_product.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_product.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_product.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_product.ColumnHeadersHeight = 28;
            this.dataGridView_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_product.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView_product.Location = new System.Drawing.Point(3, 101);
            this.dataGridView_product.MultiSelect = false;
            this.dataGridView_product.Name = "dataGridView_product";
            this.dataGridView_product.ReadOnly = true;
            this.dataGridView_product.RowHeadersVisible = false;
            this.dataGridView_product.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_product.Size = new System.Drawing.Size(790, 278);
            this.dataGridView_product.TabIndex = 24;
            this.dataGridView_product.TabStop = false;
            this.dataGridView_product.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_product_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Product";
            // 
            // label_product_downloadtemplate
            // 
            this.label_product_downloadtemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_product_downloadtemplate.AutoSize = true;
            this.label_product_downloadtemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_product_downloadtemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_product_downloadtemplate.Location = new System.Drawing.Point(609, 42);
            this.label_product_downloadtemplate.Name = "label_product_downloadtemplate";
            this.label_product_downloadtemplate.Size = new System.Drawing.Size(169, 16);
            this.label_product_downloadtemplate.TabIndex = 22;
            this.label_product_downloadtemplate.Text = "Download Import Template";
            this.label_product_downloadtemplate.Click += new System.EventHandler(this.label_product_downloadtemplate_Click);
            // 
            // button_product_newimport
            // 
            this.button_product_newimport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_product_newimport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_product_newimport.Location = new System.Drawing.Point(686, 61);
            this.button_product_newimport.Name = "button_product_newimport";
            this.button_product_newimport.Size = new System.Drawing.Size(92, 31);
            this.button_product_newimport.TabIndex = 21;
            this.button_product_newimport.Text = "Import";
            this.button_product_newimport.UseVisualStyleBackColor = true;
            this.button_product_newimport.Click += new System.EventHandler(this.button_product_newimport_Click);
            // 
            // button_product_new
            // 
            this.button_product_new.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_product_new.BackColor = System.Drawing.Color.White;
            this.button_product_new.Location = new System.Drawing.Point(472, 61);
            this.button_product_new.Name = "button_product_new";
            this.button_product_new.Size = new System.Drawing.Size(92, 31);
            this.button_product_new.TabIndex = 20;
            this.button_product_new.Text = "New";
            this.button_product_new.UseVisualStyleBackColor = false;
            this.button_product_new.Click += new System.EventHandler(this.button_product_new_Click);
            // 
            // tabPage_holiday
            // 
            this.tabPage_holiday.Controls.Add(this.numericUpDown_holiday_year);
            this.tabPage_holiday.Controls.Add(this.label5);
            this.tabPage_holiday.Controls.Add(this.monthCalendar_holiday);
            this.tabPage_holiday.Controls.Add(this.button_holiday_remove);
            this.tabPage_holiday.Controls.Add(this.button_holiday_add);
            this.tabPage_holiday.Controls.Add(this.dataGridView_holiday);
            this.tabPage_holiday.Controls.Add(this.label4);
            this.tabPage_holiday.Location = new System.Drawing.Point(4, 25);
            this.tabPage_holiday.Name = "tabPage_holiday";
            this.tabPage_holiday.Size = new System.Drawing.Size(796, 382);
            this.tabPage_holiday.TabIndex = 2;
            this.tabPage_holiday.Text = "Holiday";
            this.tabPage_holiday.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_holiday_year
            // 
            this.numericUpDown_holiday_year.Location = new System.Drawing.Point(514, 76);
            this.numericUpDown_holiday_year.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown_holiday_year.Minimum = new decimal(new int[] {
            1753,
            0,
            0,
            0});
            this.numericUpDown_holiday_year.Name = "numericUpDown_holiday_year";
            this.numericUpDown_holiday_year.Size = new System.Drawing.Size(117, 22);
            this.numericUpDown_holiday_year.TabIndex = 33;
            this.numericUpDown_holiday_year.Value = new decimal(new int[] {
            1753,
            0,
            0,
            0});
            this.numericUpDown_holiday_year.ValueChanged += new System.EventHandler(this.numericUpDown_holiday_year_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Year";
            // 
            // monthCalendar_holiday
            // 
            this.monthCalendar_holiday.Location = new System.Drawing.Point(54, 104);
            this.monthCalendar_holiday.MaxSelectionCount = 1;
            this.monthCalendar_holiday.Name = "monthCalendar_holiday";
            this.monthCalendar_holiday.TabIndex = 31;
            this.monthCalendar_holiday.TabStop = false;
            this.monthCalendar_holiday.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_holiday_DateChanged);
            this.monthCalendar_holiday.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_holiday_DateSelected);
            this.monthCalendar_holiday.Enter += new System.EventHandler(this.monthCalendar_holiday_Enter);
            // 
            // button_holiday_remove
            // 
            this.button_holiday_remove.BackColor = System.Drawing.Color.LightGray;
            this.button_holiday_remove.Enabled = false;
            this.button_holiday_remove.Location = new System.Drawing.Point(324, 202);
            this.button_holiday_remove.Name = "button_holiday_remove";
            this.button_holiday_remove.Size = new System.Drawing.Size(92, 31);
            this.button_holiday_remove.TabIndex = 30;
            this.button_holiday_remove.Text = "Remove";
            this.button_holiday_remove.UseVisualStyleBackColor = false;
            this.button_holiday_remove.Click += new System.EventHandler(this.button_holiday_remove_Click);
            // 
            // button_holiday_add
            // 
            this.button_holiday_add.BackColor = System.Drawing.Color.White;
            this.button_holiday_add.Location = new System.Drawing.Point(324, 146);
            this.button_holiday_add.Name = "button_holiday_add";
            this.button_holiday_add.Size = new System.Drawing.Size(92, 31);
            this.button_holiday_add.TabIndex = 29;
            this.button_holiday_add.Text = "Add";
            this.button_holiday_add.UseVisualStyleBackColor = false;
            this.button_holiday_add.Click += new System.EventHandler(this.button_holiday_add_Click);
            // 
            // dataGridView_holiday
            // 
            this.dataGridView_holiday.AllowUserToAddRows = false;
            this.dataGridView_holiday.AllowUserToDeleteRows = false;
            this.dataGridView_holiday.AllowUserToResizeRows = false;
            this.dataGridView_holiday.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_holiday.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_holiday.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_holiday.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_holiday.ColumnHeadersHeight = 28;
            this.dataGridView_holiday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_holiday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_holiday});
            this.dataGridView_holiday.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView_holiday.Location = new System.Drawing.Point(459, 104);
            this.dataGridView_holiday.MultiSelect = false;
            this.dataGridView_holiday.Name = "dataGridView_holiday";
            this.dataGridView_holiday.ReadOnly = true;
            this.dataGridView_holiday.RowHeadersVisible = false;
            this.dataGridView_holiday.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_holiday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_holiday.Size = new System.Drawing.Size(283, 162);
            this.dataGridView_holiday.TabIndex = 27;
            this.dataGridView_holiday.TabStop = false;
            this.dataGridView_holiday.Enter += new System.EventHandler(this.dataGridView_holiday_Enter);
            // 
            // Column_holiday
            // 
            this.Column_holiday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_holiday.HeaderText = "Holiday Date";
            this.Column_holiday.Name = "Column_holiday";
            this.Column_holiday.ReadOnly = true;
            this.Column_holiday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_holiday.Width = 280;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "Holiday";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 411);
            this.Controls.Add(this.tabControl_home);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(820, 450);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NEW DIMENSION v1.01";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl_home.ResumeLayout(false);
            this.tabPage_carton.ResumeLayout(false);
            this.tabPage_carton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_carton)).EndInit();
            this.tabPage_product.ResumeLayout(false);
            this.tabPage_product.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_product)).EndInit();
            this.tabPage_holiday.ResumeLayout(false);
            this.tabPage_holiday.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_holiday_year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_holiday)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_home;
        private System.Windows.Forms.TabPage tabPage_carton;
        private System.Windows.Forms.TabPage tabPage_product;
        private System.Windows.Forms.DataGridView dataGridView_carton;
        private System.Windows.Forms.Button button_newcarton;
        private System.Windows.Forms.Label label_product_downloadtemplate;
        private System.Windows.Forms.Button button_product_newimport;
        private System.Windows.Forms.Button button_product_new;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_carton_active;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_cartonid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_carton_l_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_carton_w_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_carton_h_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_carton_l_cm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_carton_w_cm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_carton_h_cm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage_holiday;
        private System.Windows.Forms.DataGridView dataGridView_holiday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_holiday_remove;
        private System.Windows.Forms.Button button_holiday_add;
        private System.Windows.Forms.NumericUpDown numericUpDown_holiday_year;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MonthCalendar monthCalendar_holiday;
        private System.Windows.Forms.DataGridView dataGridView_product;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_product_sku;
        private System.Windows.Forms.Button button_product_reload;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_holiday;
        private System.Windows.Forms.Button button_product_export;
    }
}


namespace NewDimension_APP
{
    partial class MoreAddForm
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
            this.label_message = new System.Windows.Forms.Label();
            this.button_havemore = new System.Windows.Forms.Button();
            this.button_lastone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.Location = new System.Drawing.Point(111, 53);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(44, 16);
            this.label_message.TabIndex = 0;
            this.label_message.Text = "label1";
            // 
            // button_havemore
            // 
            this.button_havemore.Location = new System.Drawing.Point(114, 131);
            this.button_havemore.Name = "button_havemore";
            this.button_havemore.Size = new System.Drawing.Size(106, 33);
            this.button_havemore.TabIndex = 1;
            this.button_havemore.Text = "Yes";
            this.button_havemore.UseVisualStyleBackColor = true;
            this.button_havemore.Click += new System.EventHandler(this.button_havemore_Click);
            // 
            // button_lastone
            // 
            this.button_lastone.Location = new System.Drawing.Point(258, 131);
            this.button_lastone.Name = "button_lastone";
            this.button_lastone.Size = new System.Drawing.Size(106, 33);
            this.button_lastone.TabIndex = 2;
            this.button_lastone.Text = "No";
            this.button_lastone.UseVisualStyleBackColor = true;
            this.button_lastone.Click += new System.EventHandler(this.button_lastone_Click);
            // 
            // MoreAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 204);
            this.Controls.Add(this.button_lastone);
            this.Controls.Add(this.button_havemore);
            this.Controls.Add(this.label_message);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MoreAddForm";
            this.Text = "MoreAddForm";
            this.Load += new System.EventHandler(this.MoreAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Button button_havemore;
        private System.Windows.Forms.Button button_lastone;
    }
}
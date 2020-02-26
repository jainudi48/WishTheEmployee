namespace WishTheEmployee
{
    partial class Form2
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
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.dtpDOJ = new System.Windows.Forms.DateTimePicker();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAlias = new System.Windows.Forms.ComboBox();
            this.btnPull = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Alias";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(296, 344);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(201, 48);
            this.btnSaveChanges.TabIndex = 16;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // dtpDOJ
            // 
            this.dtpDOJ.Location = new System.Drawing.Point(334, 250);
            this.dtpDOJ.Name = "dtpDOJ";
            this.dtpDOJ.Size = new System.Drawing.Size(354, 31);
            this.dtpDOJ.TabIndex = 15;
            // 
            // dtpDOB
            // 
            this.dtpDOB.Location = new System.Drawing.Point(334, 193);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(354, 31);
            this.dtpDOB.TabIndex = 14;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(334, 136);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(354, 31);
            this.tbName.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "Date of Joining";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Date of Birth";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "Name";
            // 
            // cbAlias
            // 
            this.cbAlias.FormattingEnabled = true;
            this.cbAlias.Location = new System.Drawing.Point(334, 74);
            this.cbAlias.Name = "cbAlias";
            this.cbAlias.Size = new System.Drawing.Size(268, 33);
            this.cbAlias.TabIndex = 23;
            this.cbAlias.SelectedIndexChanged += new System.EventHandler(this.cbAlias_SelectedIndexChanged_1);
            // 
            // btnPull
            // 
            this.btnPull.Location = new System.Drawing.Point(608, 74);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(81, 42);
            this.btnPull.TabIndex = 24;
            this.btnPull.Text = "Pull";
            this.btnPull.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPull);
            this.Controls.Add(this.cbAlias);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.dtpDOJ);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.DateTimePicker dtpDOJ;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAlias;
        private System.Windows.Forms.Button btnPull;
    }
}
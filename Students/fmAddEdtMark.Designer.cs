namespace Students
{
    partial class fmAddEdtMark
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
            this.btCansel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.tbmark = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btCansel
            // 
            this.btCansel.Location = new System.Drawing.Point(96, 68);
            this.btCansel.Name = "btCansel";
            this.btCansel.Size = new System.Drawing.Size(75, 23);
            this.btCansel.TabIndex = 3;
            this.btCansel.Text = "Отменить";
            this.btCansel.UseVisualStyleBackColor = true;
            this.btCansel.Click += new System.EventHandler(this.btCansel_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(12, 68);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tbmark
            // 
            this.tbmark.Location = new System.Drawing.Point(79, 10);
            this.tbmark.Name = "tbmark";
            this.tbmark.Size = new System.Drawing.Size(92, 20);
            this.tbmark.TabIndex = 0;
            this.tbmark.TextChanged += new System.EventHandler(this.tbmark_TextChanged);
            this.tbmark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbmark_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Оценка";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(79, 42);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(92, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Дата";
            // 
            // fmAddEdtMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 99);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btCansel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tbmark);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmAddEdtMark";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmAddEdtMark";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCansel;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TextBox tbmark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label2;
    }
}
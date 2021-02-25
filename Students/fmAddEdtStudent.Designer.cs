namespace Students
{
    partial class fmAddEdtStudent
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btCansel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО";
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(80, 20);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(233, 20);
            this.tb1.TabIndex = 1;
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(80, 46);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(233, 20);
            this.tb2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пол";
            // 
            // tb3
            // 
            this.tb3.Location = new System.Drawing.Point(80, 72);
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(233, 20);
            this.tb3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Адрес";
            // 
            // tb4
            // 
            this.tb4.Location = new System.Drawing.Point(80, 98);
            this.tb4.Name = "tb4";
            this.tb4.Size = new System.Drawing.Size(233, 20);
            this.tb4.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Телефон";
            // 
            // btCansel
            // 
            this.btCansel.Location = new System.Drawing.Point(173, 124);
            this.btCansel.Name = "btCansel";
            this.btCansel.Size = new System.Drawing.Size(75, 23);
            this.btCansel.TabIndex = 9;
            this.btCansel.Text = "Отменить";
            this.btCansel.UseVisualStyleBackColor = true;
            this.btCansel.Click += new System.EventHandler(this.btCansel_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(75, 124);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 8;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // fmAddEdtStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 153);
            this.Controls.Add(this.btCansel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label1);
            this.Name = "fmAddEdtStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование данных студента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btCansel;
        private System.Windows.Forms.Button btSave;
    }
}
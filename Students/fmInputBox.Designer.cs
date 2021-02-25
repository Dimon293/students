namespace Students
{
    partial class fmInputBox
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
            this.tb = new System.Windows.Forms.TextBox();
            this.btCansel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(71, 16);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(223, 20);
            this.tb.TabIndex = 1;
            this.tb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_KeyUp);
            // 
            // btCansel
            // 
            this.btCansel.Location = new System.Drawing.Point(152, 42);
            this.btCansel.Name = "btCansel";
            this.btCansel.Size = new System.Drawing.Size(75, 23);
            this.btCansel.TabIndex = 3;
            this.btCansel.Text = "Отменить";
            this.btCansel.UseVisualStyleBackColor = true;
            this.btCansel.Click += new System.EventHandler(this.btCansel_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(71, 42);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // fmInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 78);
            this.Controls.Add(this.btCansel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.label1);
            this.Name = "fmInputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование справочника";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.Button btCansel;
        private System.Windows.Forms.Button btSave;
    }
}
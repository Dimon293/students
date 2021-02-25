namespace Students
{
    partial class fmAddEdtGroupSubject
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb1 = new System.Windows.Forms.ComboBox();
            this.cb2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btCansel
            // 
            this.btCansel.Location = new System.Drawing.Point(227, 111);
            this.btCansel.Name = "btCansel";
            this.btCansel.Size = new System.Drawing.Size(75, 23);
            this.btCansel.TabIndex = 11;
            this.btCansel.Text = "Отменить";
            this.btCansel.UseVisualStyleBackColor = true;
            this.btCansel.Click += new System.EventHandler(this.btCansel_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(52, 111);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 10;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Семестр";
            // 
            // cb1
            // 
            this.cb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb1.Location = new System.Drawing.Point(93, 25);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(253, 21);
            this.cb1.TabIndex = 13;
            // 
            // cb2
            // 
            this.cb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2.Location = new System.Drawing.Point(93, 52);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(253, 21);
            this.cb2.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Предмет";
            // 
            // cb3
            // 
            this.cb3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb3.Location = new System.Drawing.Point(93, 79);
            this.cb3.Name = "cb3";
            this.cb3.Size = new System.Drawing.Size(253, 21);
            this.cb3.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Преподаватель";
            // 
            // fmAddEdtGroupSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 146);
            this.Controls.Add(this.cb3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCansel);
            this.Controls.Add(this.btSave);
            this.Name = "fmAddEdtGroupSubject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка предмета в группе";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCansel;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb1;
        private System.Windows.Forms.ComboBox cb2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb3;
        private System.Windows.Forms.Label label3;
    }
}
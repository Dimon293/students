namespace Students
{
    partial class fmViewMark
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.cbControl = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFaculties = new System.Windows.Forms.ComboBox();
            this.cbChairs = new System.Windows.Forms.ComboBox();
            this.cbSpecialties = new System.Windows.Forms.ComboBox();
            this.chMark = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvStudentsMark = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsMark)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvStudentsMark);
            this.splitContainer1.Size = new System.Drawing.Size(1019, 489);
            this.splitContainer1.SplitterDistance = 392;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.cbControl);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.cbGroup);
            this.splitContainer2.Panel1.Controls.Add(this.cbSubject);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.cbFaculties);
            this.splitContainer2.Panel1.Controls.Add(this.cbChairs);
            this.splitContainer2.Panel1.Controls.Add(this.cbSpecialties);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chMark);
            this.splitContainer2.Size = new System.Drawing.Size(392, 489);
            this.splitContainer2.SplitterDistance = 217;
            this.splitContainer2.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Варианты аттестации";
            // 
            // cbControl
            // 
            this.cbControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbControl.FormattingEnabled = true;
            this.cbControl.Location = new System.Drawing.Point(142, 192);
            this.cbControl.Name = "cbControl";
            this.cbControl.Size = new System.Drawing.Size(240, 21);
            this.cbControl.TabIndex = 22;
            this.cbControl.SelectedIndexChanged += new System.EventHandler(this.cbControl_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Семестр + дисциплина";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Группа";
            // 
            // cbGroup
            // 
            this.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(142, 117);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(240, 21);
            this.cbGroup.TabIndex = 19;
            this.cbGroup.SelectedIndexChanged += new System.EventHandler(this.cbGroup_SelectedIndexChanged);
            // 
            // cbSubject
            // 
            this.cbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(13, 165);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(369, 21);
            this.cbSubject.TabIndex = 18;
            this.cbSubject.SelectedIndexChanged += new System.EventHandler(this.cbSubject_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Специальность";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Кафедра";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Факультет";
            // 
            // cbFaculties
            // 
            this.cbFaculties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFaculties.FormattingEnabled = true;
            this.cbFaculties.Location = new System.Drawing.Point(142, 15);
            this.cbFaculties.Name = "cbFaculties";
            this.cbFaculties.Size = new System.Drawing.Size(237, 21);
            this.cbFaculties.TabIndex = 12;
            this.cbFaculties.SelectedIndexChanged += new System.EventHandler(this.comboBoxFaculties_SelectedIndexChanged);
            // 
            // cbChairs
            // 
            this.cbChairs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChairs.FormattingEnabled = true;
            this.cbChairs.Location = new System.Drawing.Point(142, 42);
            this.cbChairs.Name = "cbChairs";
            this.cbChairs.Size = new System.Drawing.Size(237, 21);
            this.cbChairs.TabIndex = 14;
            this.cbChairs.SelectedIndexChanged += new System.EventHandler(this.comboBoxChairs_SelectedIndexChanged);
            // 
            // cbSpecialties
            // 
            this.cbSpecialties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpecialties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSpecialties.FormattingEnabled = true;
            this.cbSpecialties.Location = new System.Drawing.Point(13, 90);
            this.cbSpecialties.Name = "cbSpecialties";
            this.cbSpecialties.Size = new System.Drawing.Size(369, 21);
            this.cbSpecialties.TabIndex = 13;
            this.cbSpecialties.SelectedIndexChanged += new System.EventHandler(this.cbSpecialties_SelectedIndexChanged);
            // 
            // chMark
            // 
            chartArea1.Name = "ChartArea1";
            this.chMark.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chMark.Legends.Add(legend1);
            this.chMark.Location = new System.Drawing.Point(0, 3);
            this.chMark.Name = "chMark";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chMark.Series.Add(series1);
            this.chMark.Size = new System.Drawing.Size(392, 269);
            this.chMark.TabIndex = 0;
            this.chMark.Text = "chart1";
            // 
            // dgvStudentsMark
            // 
            this.dgvStudentsMark.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentsMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudentsMark.Location = new System.Drawing.Point(0, 0);
            this.dgvStudentsMark.Name = "dgvStudentsMark";
            this.dgvStudentsMark.Size = new System.Drawing.Size(623, 489);
            this.dgvStudentsMark.TabIndex = 5;
            // 
            // fmViewMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 489);
            this.Controls.Add(this.splitContainer1);
            this.Name = "fmViewMark";
            this.Text = "fmViewMark";
            this.Shown += new System.EventHandler(this.fmViewMark_Shown);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.fmViewMark_Scroll);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsMark)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFaculties;
        private System.Windows.Forms.ComboBox cbChairs;
        private System.Windows.Forms.ComboBox cbSpecialties;
        private System.Windows.Forms.DataVisualization.Charting.Chart chMark;
        private System.Windows.Forms.DataGridView dgvStudentsMark;
    }
}
namespace ComputerGraphics
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
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tX = new System.Windows.Forms.TrackBar();
            this.tY = new System.Windows.Forms.TrackBar();
            this.tZ = new System.Windows.Forms.TrackBar();
            this.LabelX = new System.Windows.Forms.Label();
            this.LabelY = new System.Windows.Forms.Label();
            this.LabelZ = new System.Windows.Forms.Label();
            this.GroupBoxRotate = new System.Windows.Forms.GroupBox();
            this.numericUpDownZ = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.GroupBoxControl = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownYPoint = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownXPoint = new System.Windows.Forms.NumericUpDown();
            this.labelSize = new System.Windows.Forms.Label();
            this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tZ)).BeginInit();
            this.GroupBoxRotate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            this.GroupBoxControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxMain.Location = new System.Drawing.Point(13, 12);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(425, 426);
            this.pictureBoxMain.TabIndex = 4;
            this.pictureBoxMain.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(615, 415);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 450);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // tX
            // 
            this.tX.Location = new System.Drawing.Point(29, 19);
            this.tX.Maximum = 360;
            this.tX.Name = "tX";
            this.tX.Size = new System.Drawing.Size(151, 45);
            this.tX.TabIndex = 7;
            this.tX.Scroll += new System.EventHandler(this.t_Scroll);
            // 
            // tY
            // 
            this.tY.Location = new System.Drawing.Point(29, 70);
            this.tY.Maximum = 360;
            this.tY.Name = "tY";
            this.tY.Size = new System.Drawing.Size(151, 45);
            this.tY.TabIndex = 8;
            this.tY.Scroll += new System.EventHandler(this.t_Scroll);
            // 
            // tZ
            // 
            this.tZ.Location = new System.Drawing.Point(29, 121);
            this.tZ.Maximum = 360;
            this.tZ.Name = "tZ";
            this.tZ.Size = new System.Drawing.Size(151, 45);
            this.tZ.TabIndex = 9;
            this.tZ.Scroll += new System.EventHandler(this.t_Scroll);
            // 
            // LabelX
            // 
            this.LabelX.AutoSize = true;
            this.LabelX.Location = new System.Drawing.Point(9, 27);
            this.LabelX.Name = "LabelX";
            this.LabelX.Size = new System.Drawing.Size(14, 13);
            this.LabelX.TabIndex = 13;
            this.LabelX.Text = "X";
            // 
            // LabelY
            // 
            this.LabelY.AutoSize = true;
            this.LabelY.Location = new System.Drawing.Point(9, 77);
            this.LabelY.Name = "LabelY";
            this.LabelY.Size = new System.Drawing.Size(14, 13);
            this.LabelY.TabIndex = 14;
            this.LabelY.Text = "Y";
            // 
            // LabelZ
            // 
            this.LabelZ.AutoSize = true;
            this.LabelZ.Location = new System.Drawing.Point(9, 128);
            this.LabelZ.Name = "LabelZ";
            this.LabelZ.Size = new System.Drawing.Size(14, 13);
            this.LabelZ.TabIndex = 15;
            this.LabelZ.Text = "Z";
            // 
            // GroupBoxRotate
            // 
            this.GroupBoxRotate.Controls.Add(this.numericUpDownZ);
            this.GroupBoxRotate.Controls.Add(this.numericUpDownY);
            this.GroupBoxRotate.Controls.Add(this.numericUpDownX);
            this.GroupBoxRotate.Controls.Add(this.tX);
            this.GroupBoxRotate.Controls.Add(this.LabelZ);
            this.GroupBoxRotate.Controls.Add(this.tY);
            this.GroupBoxRotate.Controls.Add(this.LabelY);
            this.GroupBoxRotate.Controls.Add(this.tZ);
            this.GroupBoxRotate.Controls.Add(this.LabelX);
            this.GroupBoxRotate.Location = new System.Drawing.Point(445, 12);
            this.GroupBoxRotate.Name = "GroupBoxRotate";
            this.GroupBoxRotate.Size = new System.Drawing.Size(245, 169);
            this.GroupBoxRotate.TabIndex = 16;
            this.GroupBoxRotate.TabStop = false;
            this.GroupBoxRotate.Text = "Rotate";
            // 
            // numericUpDownZ
            // 
            this.numericUpDownZ.Location = new System.Drawing.Point(186, 126);
            this.numericUpDownZ.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownZ.Name = "numericUpDownZ";
            this.numericUpDownZ.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownZ.TabIndex = 18;
            this.numericUpDownZ.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Location = new System.Drawing.Point(186, 75);
            this.numericUpDownY.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownY.TabIndex = 17;
            this.numericUpDownY.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Location = new System.Drawing.Point(186, 25);
            this.numericUpDownX.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownX.TabIndex = 16;
            this.numericUpDownX.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // GroupBoxControl
            // 
            this.GroupBoxControl.Controls.Add(this.label2);
            this.GroupBoxControl.Controls.Add(this.numericUpDownYPoint);
            this.GroupBoxControl.Controls.Add(this.label1);
            this.GroupBoxControl.Controls.Add(this.numericUpDownXPoint);
            this.GroupBoxControl.Controls.Add(this.labelSize);
            this.GroupBoxControl.Controls.Add(this.numericUpDownSize);
            this.GroupBoxControl.Location = new System.Drawing.Point(445, 188);
            this.GroupBoxControl.Name = "GroupBoxControl";
            this.GroupBoxControl.Size = new System.Drawing.Size(245, 117);
            this.GroupBoxControl.TabIndex = 17;
            this.GroupBoxControl.TabStop = false;
            this.GroupBoxControl.Text = "Control";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Y";
            // 
            // numericUpDownYPoint
            // 
            this.numericUpDownYPoint.Location = new System.Drawing.Point(42, 71);
            this.numericUpDownYPoint.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownYPoint.Name = "numericUpDownYPoint";
            this.numericUpDownYPoint.Size = new System.Drawing.Size(197, 20);
            this.numericUpDownYPoint.TabIndex = 22;
            this.numericUpDownYPoint.ValueChanged += new System.EventHandler(this.numericUpDownPoint_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "X";
            // 
            // numericUpDownXPoint
            // 
            this.numericUpDownXPoint.Location = new System.Drawing.Point(42, 45);
            this.numericUpDownXPoint.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownXPoint.Name = "numericUpDownXPoint";
            this.numericUpDownXPoint.Size = new System.Drawing.Size(197, 20);
            this.numericUpDownXPoint.TabIndex = 20;
            this.numericUpDownXPoint.ValueChanged += new System.EventHandler(this.numericUpDownPoint_ValueChanged);
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(9, 21);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(27, 13);
            this.labelSize.TabIndex = 19;
            this.labelSize.Text = "Size";
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.Location = new System.Drawing.Point(42, 19);
            this.numericUpDownSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(197, 20);
            this.numericUpDownSize.TabIndex = 0;
            this.numericUpDownSize.ValueChanged += new System.EventHandler(this.numericUpDownSize_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 450);
            this.Controls.Add(this.GroupBoxControl);
            this.Controls.Add(this.GroupBoxRotate);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pictureBoxMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tZ)).EndInit();
            this.GroupBoxRotate.ResumeLayout(false);
            this.GroupBoxRotate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            this.GroupBoxControl.ResumeLayout(false);
            this.GroupBoxControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TrackBar tX;
        private System.Windows.Forms.TrackBar tY;
        private System.Windows.Forms.TrackBar tZ;
        private System.Windows.Forms.Label LabelX;
        private System.Windows.Forms.Label LabelY;
        private System.Windows.Forms.Label LabelZ;
        private System.Windows.Forms.GroupBox GroupBoxRotate;
        private System.Windows.Forms.NumericUpDown numericUpDownZ;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.GroupBox GroupBoxControl;
        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownYPoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownXPoint;
    }
}


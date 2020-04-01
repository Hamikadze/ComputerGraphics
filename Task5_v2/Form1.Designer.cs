namespace Task5_v2
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
            this.GroupBoxControl = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownYPoint = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownXPoint = new System.Windows.Forms.NumericUpDown();
            this.labelSize = new System.Windows.Forms.Label();
            this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
            this.GroupBoxRotate = new System.Windows.Forms.GroupBox();
            this.numericUpDownZ = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.tX = new System.Windows.Forms.TrackBar();
            this.LabelZ = new System.Windows.Forms.Label();
            this.tY = new System.Windows.Forms.TrackBar();
            this.LabelY = new System.Windows.Forms.Label();
            this.tZ = new System.Windows.Forms.TrackBar();
            this.LabelX = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.GroupBoxControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            this.GroupBoxRotate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tZ)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMain.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxMain.Location = new System.Drawing.Point(17, 16);
            this.pictureBoxMain.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(699, 653);
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseClick);
            // 
            // GroupBoxControl
            // 
            this.GroupBoxControl.Controls.Add(this.label2);
            this.GroupBoxControl.Controls.Add(this.numericUpDownYPoint);
            this.GroupBoxControl.Controls.Add(this.label1);
            this.GroupBoxControl.Controls.Add(this.numericUpDownXPoint);
            this.GroupBoxControl.Controls.Add(this.labelSize);
            this.GroupBoxControl.Controls.Add(this.numericUpDownSize);
            this.GroupBoxControl.Location = new System.Drawing.Point(724, 232);
            this.GroupBoxControl.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBoxControl.Name = "GroupBoxControl";
            this.GroupBoxControl.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBoxControl.Size = new System.Drawing.Size(327, 144);
            this.GroupBoxControl.TabIndex = 20;
            this.GroupBoxControl.TabStop = false;
            this.GroupBoxControl.Text = "Control";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Y";
            // 
            // numericUpDownYPoint
            // 
            this.numericUpDownYPoint.Location = new System.Drawing.Point(56, 87);
            this.numericUpDownYPoint.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownYPoint.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownYPoint.Name = "numericUpDownYPoint";
            this.numericUpDownYPoint.Size = new System.Drawing.Size(263, 22);
            this.numericUpDownYPoint.TabIndex = 22;
            this.numericUpDownYPoint.ValueChanged += new System.EventHandler(this.numericUpDownPoint_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "X";
            // 
            // numericUpDownXPoint
            // 
            this.numericUpDownXPoint.Location = new System.Drawing.Point(56, 55);
            this.numericUpDownXPoint.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownXPoint.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownXPoint.Name = "numericUpDownXPoint";
            this.numericUpDownXPoint.Size = new System.Drawing.Size(263, 22);
            this.numericUpDownXPoint.TabIndex = 20;
            this.numericUpDownXPoint.ValueChanged += new System.EventHandler(this.numericUpDownPoint_ValueChanged);
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(12, 26);
            this.labelSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(35, 17);
            this.labelSize.TabIndex = 19;
            this.labelSize.Text = "Size";
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.Location = new System.Drawing.Point(56, 23);
            this.numericUpDownSize.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(263, 22);
            this.numericUpDownSize.TabIndex = 0;
            this.numericUpDownSize.ValueChanged += new System.EventHandler(this.numericUpDownSize_ValueChanged);
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
            this.GroupBoxRotate.Location = new System.Drawing.Point(724, 16);
            this.GroupBoxRotate.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBoxRotate.Name = "GroupBoxRotate";
            this.GroupBoxRotate.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBoxRotate.Size = new System.Drawing.Size(327, 208);
            this.GroupBoxRotate.TabIndex = 19;
            this.GroupBoxRotate.TabStop = false;
            this.GroupBoxRotate.Text = "Rotate";
            // 
            // numericUpDownZ
            // 
            this.numericUpDownZ.Location = new System.Drawing.Point(248, 155);
            this.numericUpDownZ.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownZ.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownZ.Name = "numericUpDownZ";
            this.numericUpDownZ.Size = new System.Drawing.Size(71, 22);
            this.numericUpDownZ.TabIndex = 18;
            this.numericUpDownZ.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Location = new System.Drawing.Point(248, 92);
            this.numericUpDownY.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownY.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(71, 22);
            this.numericUpDownY.TabIndex = 17;
            this.numericUpDownY.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Location = new System.Drawing.Point(248, 31);
            this.numericUpDownX.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownX.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(71, 22);
            this.numericUpDownX.TabIndex = 16;
            this.numericUpDownX.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // tX
            // 
            this.tX.Location = new System.Drawing.Point(39, 23);
            this.tX.Margin = new System.Windows.Forms.Padding(4);
            this.tX.Maximum = 360;
            this.tX.Name = "tX";
            this.tX.Size = new System.Drawing.Size(201, 56);
            this.tX.TabIndex = 7;
            this.tX.Scroll += new System.EventHandler(this.t_Scroll);
            // 
            // LabelZ
            // 
            this.LabelZ.AutoSize = true;
            this.LabelZ.Location = new System.Drawing.Point(12, 158);
            this.LabelZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelZ.Name = "LabelZ";
            this.LabelZ.Size = new System.Drawing.Size(17, 17);
            this.LabelZ.TabIndex = 15;
            this.LabelZ.Text = "Z";
            // 
            // tY
            // 
            this.tY.Location = new System.Drawing.Point(39, 86);
            this.tY.Margin = new System.Windows.Forms.Padding(4);
            this.tY.Maximum = 360;
            this.tY.Name = "tY";
            this.tY.Size = new System.Drawing.Size(201, 56);
            this.tY.TabIndex = 8;
            this.tY.Scroll += new System.EventHandler(this.t_Scroll);
            // 
            // LabelY
            // 
            this.LabelY.AutoSize = true;
            this.LabelY.Location = new System.Drawing.Point(12, 95);
            this.LabelY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelY.Name = "LabelY";
            this.LabelY.Size = new System.Drawing.Size(17, 17);
            this.LabelY.TabIndex = 14;
            this.LabelY.Text = "Y";
            // 
            // tZ
            // 
            this.tZ.Location = new System.Drawing.Point(39, 149);
            this.tZ.Margin = new System.Windows.Forms.Padding(4);
            this.tZ.Maximum = 360;
            this.tZ.Name = "tZ";
            this.tZ.Size = new System.Drawing.Size(201, 56);
            this.tZ.TabIndex = 9;
            this.tZ.Scroll += new System.EventHandler(this.t_Scroll);
            // 
            // LabelX
            // 
            this.LabelX.AutoSize = true;
            this.LabelX.Location = new System.Drawing.Point(12, 33);
            this.LabelX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelX.Name = "LabelX";
            this.LabelX.Size = new System.Drawing.Size(17, 17);
            this.LabelX.TabIndex = 13;
            this.LabelX.Text = "X";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(951, 641);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 28);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 684);
            this.Controls.Add(this.GroupBoxControl);
            this.Controls.Add(this.GroupBoxRotate);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pictureBoxMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.GroupBoxControl.ResumeLayout(false);
            this.GroupBoxControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            this.GroupBoxRotate.ResumeLayout(false);
            this.GroupBoxRotate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tZ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.GroupBox GroupBoxControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownYPoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownXPoint;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.GroupBox GroupBoxRotate;
        private System.Windows.Forms.NumericUpDown numericUpDownZ;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.TrackBar tX;
        private System.Windows.Forms.Label LabelZ;
        private System.Windows.Forms.TrackBar tY;
        private System.Windows.Forms.Label LabelY;
        private System.Windows.Forms.TrackBar tZ;
        private System.Windows.Forms.Label LabelX;
        private System.Windows.Forms.Button btnReset;
    }
}


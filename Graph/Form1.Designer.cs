namespace Graph
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
            this.graph1PB = new System.Windows.Forms.PictureBox();
            this.AddNodeBtn = new System.Windows.Forms.RadioButton();
            this.DeleteNodeBtn = new System.Windows.Forms.RadioButton();
            this.GetEdgeBtn = new System.Windows.Forms.RadioButton();
            this.SelectionNodeBtn = new System.Windows.Forms.RadioButton();
            this.StartBtn = new System.Windows.Forms.Button();
            this.openGraph1Btn = new System.Windows.Forms.Button();
            this.saveGraph1Btn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.graph1PB)).BeginInit();
            this.SuspendLayout();
            // 
            // graph1PB
            // 
            this.graph1PB.Location = new System.Drawing.Point(93, 12);
            this.graph1PB.Name = "graph1PB";
            this.graph1PB.Size = new System.Drawing.Size(404, 347);
            this.graph1PB.TabIndex = 0;
            this.graph1PB.TabStop = false;
            this.graph1PB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graph1PB_MouseDown);
            this.graph1PB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graph1PB_MouseMove);
            this.graph1PB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.graph1PB_MouseUp);
            // 
            // AddNodeBtn
            // 
            this.AddNodeBtn.AutoSize = true;
            this.AddNodeBtn.Location = new System.Drawing.Point(34, 373);
            this.AddNodeBtn.Name = "AddNodeBtn";
            this.AddNodeBtn.Size = new System.Drawing.Size(70, 17);
            this.AddNodeBtn.TabIndex = 2;
            this.AddNodeBtn.TabStop = true;
            this.AddNodeBtn.Text = "AddNode";
            this.AddNodeBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteNodeBtn
            // 
            this.DeleteNodeBtn.AutoSize = true;
            this.DeleteNodeBtn.Location = new System.Drawing.Point(34, 396);
            this.DeleteNodeBtn.Name = "DeleteNodeBtn";
            this.DeleteNodeBtn.Size = new System.Drawing.Size(82, 17);
            this.DeleteNodeBtn.TabIndex = 3;
            this.DeleteNodeBtn.TabStop = true;
            this.DeleteNodeBtn.Text = "DeleteNode";
            this.DeleteNodeBtn.UseVisualStyleBackColor = true;
            // 
            // GetEdgeBtn
            // 
            this.GetEdgeBtn.AutoSize = true;
            this.GetEdgeBtn.Location = new System.Drawing.Point(34, 419);
            this.GetEdgeBtn.Name = "GetEdgeBtn";
            this.GetEdgeBtn.Size = new System.Drawing.Size(67, 17);
            this.GetEdgeBtn.TabIndex = 4;
            this.GetEdgeBtn.TabStop = true;
            this.GetEdgeBtn.Text = "GetEdge";
            this.GetEdgeBtn.UseVisualStyleBackColor = true;
            // 
            // SelectionNodeBtn
            // 
            this.SelectionNodeBtn.AutoSize = true;
            this.SelectionNodeBtn.Location = new System.Drawing.Point(34, 442);
            this.SelectionNodeBtn.Name = "SelectionNodeBtn";
            this.SelectionNodeBtn.Size = new System.Drawing.Size(95, 17);
            this.SelectionNodeBtn.TabIndex = 5;
            this.SelectionNodeBtn.TabStop = true;
            this.SelectionNodeBtn.Text = "SelectionNode";
            this.SelectionNodeBtn.UseVisualStyleBackColor = true;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(31, 488);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(85, 48);
            this.StartBtn.TabIndex = 6;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // openGraph1Btn
            // 
            this.openGraph1Btn.Location = new System.Drawing.Point(141, 373);
            this.openGraph1Btn.Name = "openGraph1Btn";
            this.openGraph1Btn.Size = new System.Drawing.Size(106, 23);
            this.openGraph1Btn.TabIndex = 7;
            this.openGraph1Btn.Text = "OpenGraph1";
            this.openGraph1Btn.UseVisualStyleBackColor = true;
            this.openGraph1Btn.Click += new System.EventHandler(this.openGraph1Btn_Click);
            // 
            // saveGraph1Btn
            // 
            this.saveGraph1Btn.Location = new System.Drawing.Point(141, 411);
            this.saveGraph1Btn.Name = "saveGraph1Btn";
            this.saveGraph1Btn.Size = new System.Drawing.Size(106, 23);
            this.saveGraph1Btn.TabIndex = 8;
            this.saveGraph1Btn.Text = "SaveGraph1";
            this.saveGraph1Btn.UseVisualStyleBackColor = true;
            this.saveGraph1Btn.Click += new System.EventHandler(this.saveGraph1Btn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(155, 488);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(75, 48);
            this.ClearBtn.TabIndex = 11;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(289, 373);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(268, 163);
            this.textBox1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 562);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.saveGraph1Btn);
            this.Controls.Add(this.openGraph1Btn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.SelectionNodeBtn);
            this.Controls.Add(this.GetEdgeBtn);
            this.Controls.Add(this.DeleteNodeBtn);
            this.Controls.Add(this.AddNodeBtn);
            this.Controls.Add(this.graph1PB);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.graph1PB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox graph1PB;
        private System.Windows.Forms.RadioButton AddNodeBtn;
        private System.Windows.Forms.RadioButton DeleteNodeBtn;
        private System.Windows.Forms.RadioButton GetEdgeBtn;
        private System.Windows.Forms.RadioButton SelectionNodeBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button openGraph1Btn;
        private System.Windows.Forms.Button saveGraph1Btn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
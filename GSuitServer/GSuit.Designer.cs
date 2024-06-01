namespace GSuitServer
{
    partial class GSuit
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
            this.textBox_debugInput = new System.Windows.Forms.TextBox();
            this.button_apply = new System.Windows.Forms.Button();
            this.textBox_debugOutput = new System.Windows.Forms.TextBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.trackBar_debugForce = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_debugForce)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_debugInput
            // 
            this.textBox_debugInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_debugInput.Location = new System.Drawing.Point(12, 12);
            this.textBox_debugInput.Name = "textBox_debugInput";
            this.textBox_debugInput.Size = new System.Drawing.Size(364, 20);
            this.textBox_debugInput.TabIndex = 0;
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(12, 38);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 1;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // textBox_debugOutput
            // 
            this.textBox_debugOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_debugOutput.Location = new System.Drawing.Point(12, 119);
            this.textBox_debugOutput.Multiline = true;
            this.textBox_debugOutput.Name = "textBox_debugOutput";
            this.textBox_debugOutput.ReadOnly = true;
            this.textBox_debugOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_debugOutput.Size = new System.Drawing.Size(364, 225);
            this.textBox_debugOutput.TabIndex = 2;
            // 
            // button_clear
            // 
            this.button_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_clear.Location = new System.Drawing.Point(12, 350);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 4;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // trackBar_debugForce
            // 
            this.trackBar_debugForce.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_debugForce.LargeChange = 1;
            this.trackBar_debugForce.Location = new System.Drawing.Point(13, 68);
            this.trackBar_debugForce.Maximum = 9;
            this.trackBar_debugForce.Minimum = 1;
            this.trackBar_debugForce.Name = "trackBar_debugForce";
            this.trackBar_debugForce.Size = new System.Drawing.Size(363, 45);
            this.trackBar_debugForce.TabIndex = 5;
            this.trackBar_debugForce.Value = 1;
            this.trackBar_debugForce.Scroll += new System.EventHandler(this.trackBar_debugForce_Scroll);
            // 
            // GSuit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 383);
            this.Controls.Add(this.trackBar_debugForce);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.textBox_debugOutput);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.textBox_debugInput);
            this.Name = "GSuit";
            this.Text = "GSuit Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GSuite_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_debugForce)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_debugInput;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.TextBox textBox_debugOutput;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.TrackBar trackBar_debugForce;
    }
}


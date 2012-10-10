namespace RailView
{
    partial class TestCoordination
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
            this.label2 = new System.Windows.Forms.Label();
            this.offsetText = new System.Windows.Forms.TextBox();
            this.offsetRange = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "offset";
            // 
            // offsetText
            // 
            this.offsetText.Location = new System.Drawing.Point(89, 58);
            this.offsetText.Name = "offsetText";
            this.offsetText.Size = new System.Drawing.Size(79, 21);
            this.offsetText.TabIndex = 3;
            this.offsetText.TextChanged += new System.EventHandler(this.offsetText_TextChanged);
            // 
            // offsetRange
            // 
            this.offsetRange.AutoSize = true;
            this.offsetRange.Location = new System.Drawing.Point(189, 62);
            this.offsetRange.Name = "offsetRange";
            this.offsetRange.Size = new System.Drawing.Size(47, 12);
            this.offsetRange.TabIndex = 5;
            this.offsetRange.Text = "section";
            // 
            // TestCoordination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 127);
            this.Controls.Add(this.offsetRange);
            this.Controls.Add(this.offsetText);
            this.Controls.Add(this.label2);
            this.Name = "TestCoordination";
            this.Text = "TestCoordination";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox offsetText;
        private System.Windows.Forms.Label offsetRange;
    }
}

namespace CreditCompany.UserControls
{
    partial class RequestScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleBoxTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contentBoxTB = new System.Windows.Forms.TextBox();
            this.submitBtn = new MaterialSkin.Controls.MaterialButton(); //System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleBoxTB
            // 
            this.titleBoxTB.Location = new System.Drawing.Point(0, 38);
            this.titleBoxTB.Name = "titleBoxTB";
            this.titleBoxTB.Size = new System.Drawing.Size(685, 27);
            this.titleBoxTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "כותרת";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "תוכן";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contentBoxTB
            // 
            this.contentBoxTB.Location = new System.Drawing.Point(0, 118);
            this.contentBoxTB.Multiline = true;
            this.contentBoxTB.Name = "contentBoxTB";
            this.contentBoxTB.Size = new System.Drawing.Size(685, 156);
            this.contentBoxTB.TabIndex = 2;
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(304, 298);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(94, 29);
            this.submitBtn.TabIndex = 4;
            this.submitBtn.Text = "submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // RequestScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contentBoxTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleBoxTB);
            this.Name = "RequestScreen";
            this.Size = new System.Drawing.Size(685, 346);
            this.Load += new System.EventHandler(this.RequestScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titleBoxTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox contentBoxTB;
        private System.Windows.Forms.Button submitBtn;
    }
}

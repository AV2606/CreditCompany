
namespace CreditCompany.UserControls
{
    partial class Filter
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ClientIdInput = new System.Windows.Forms.NumericUpDown();
            this.TitleTB = new System.Windows.Forms.TextBox();
            this.button1 = new MaterialSkin.Controls.MaterialButton(); //System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ClientIdInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "מספר לקוח";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "כותרת";
            // 
            // ClientIdInput
            // 
            this.ClientIdInput.Location = new System.Drawing.Point(3, 142);
            this.ClientIdInput.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.ClientIdInput.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.ClientIdInput.Name = "ClientIdInput";
            this.ClientIdInput.Size = new System.Drawing.Size(82, 27);
            this.ClientIdInput.TabIndex = 2;
            this.ClientIdInput.Value = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            // 
            // TitleTB
            // 
            this.TitleTB.Location = new System.Drawing.Point(3, 68);
            this.TitleTB.Name = "TitleTB";
            this.TitleTB.Size = new System.Drawing.Size(146, 27);
            this.TitleTB.TabIndex = 3;
            this.TitleTB.Text = "0x";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "סנן";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TitleTB);
            this.Controls.Add(this.ClientIdInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Filter";
            this.Size = new System.Drawing.Size(182, 348);
            this.Load += new System.EventHandler(this.Filter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClientIdInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ClientIdInput;
        private System.Windows.Forms.TextBox TitleTB;
        private System.Windows.Forms.Button button1;
    }
}

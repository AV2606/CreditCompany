
namespace CreditCompany.UserControls
{
    partial class TransactionWritingScreen
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
            this.cardNumberCB = new System.Windows.Forms.ComboBox();
            this.clientCB = new System.Windows.Forms.ComboBox();
            this.businessNameCB = new System.Windows.Forms.ComboBox();
            this.dateDTP = new System.Windows.Forms.DateTimePicker();
            this.paymentNUD = new System.Windows.Forms.NumericUpDown();
            this.cardShowedCB = new MaterialSkin.Controls.MaterialCheckbox();
            this.submitBtn = new MaterialSkin.Controls.MaterialButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.paymentNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // cardNumberCB
            // 
            this.cardNumberCB.FormattingEnabled = true;
            this.cardNumberCB.Location = new System.Drawing.Point(439, 41);
            this.cardNumberCB.Name = "cardNumberCB";
            this.cardNumberCB.Size = new System.Drawing.Size(161, 28);
            this.cardNumberCB.TabIndex = 0;
            // 
            // clientCB
            // 
            this.clientCB.FormattingEnabled = true;
            this.clientCB.Location = new System.Drawing.Point(151, 41);
            this.clientCB.Name = "clientCB";
            this.clientCB.Size = new System.Drawing.Size(282, 28);
            this.clientCB.TabIndex = 1;
            // 
            // businessNameCB
            // 
            this.businessNameCB.FormattingEnabled = true;
            this.businessNameCB.Location = new System.Drawing.Point(449, 101);
            this.businessNameCB.Name = "businessNameCB";
            this.businessNameCB.Size = new System.Drawing.Size(151, 28);
            this.businessNameCB.TabIndex = 2;
            // 
            // dateDTP
            // 
            this.dateDTP.Location = new System.Drawing.Point(217, 102);
            this.dateDTP.Name = "dateDTP";
            this.dateDTP.Size = new System.Drawing.Size(226, 27);
            this.dateDTP.TabIndex = 3;
            // 
            // paymentNUD
            // 
            this.paymentNUD.DecimalPlaces = 2;
            this.paymentNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.paymentNUD.Location = new System.Drawing.Point(61, 101);
            this.paymentNUD.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.paymentNUD.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.paymentNUD.Name = "paymentNUD";
            this.paymentNUD.Size = new System.Drawing.Size(150, 27);
            this.paymentNUD.TabIndex = 4;
            this.paymentNUD.ThousandsSeparator = true;
            // 
            // cardShowedCB
            // 
            this.cardShowedCB.AutoSize = true;
            this.cardShowedCB.Depth = 0;
            this.cardShowedCB.Location = new System.Drawing.Point(30, 37);
            this.cardShowedCB.Margin = new System.Windows.Forms.Padding(0);
            this.cardShowedCB.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cardShowedCB.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardShowedCB.Name = "cardShowedCB";
            this.cardShowedCB.ReadOnly = false;
            this.cardShowedCB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cardShowedCB.Ripple = true;
            this.cardShowedCB.Size = new System.Drawing.Size(118, 37);
            this.cardShowedCB.TabIndex = 5;
            this.cardShowedCB.Text = "כרטיס הוצג";
            this.cardShowedCB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cardShowedCB.UseVisualStyleBackColor = true;
            // 
            // submitBtn
            // 
            this.submitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.submitBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.submitBtn.Depth = 0;
            this.submitBtn.HighEmphasis = true;
            this.submitBtn.Icon = null;
            this.submitBtn.Location = new System.Drawing.Point(250, 187);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.submitBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.submitBtn.Size = new System.Drawing.Size(100, 36);
            this.submitBtn.TabIndex = 6;
            this.submitBtn.Text = "רישום עסקה";
            this.submitBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.submitBtn.UseAccentColor = false;
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(463, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "מספר כרטיס לחיוב";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(352, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "לקוח לזיכוי";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(562, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "עסק";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(391, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 19);
            this.label4.TabIndex = 23;
            this.label4.Text = "תאריך";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(170, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 19);
            this.label5.TabIndex = 24;
            this.label5.Text = "סכום";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TransactionWritingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.cardShowedCB);
            this.Controls.Add(this.paymentNUD);
            this.Controls.Add(this.dateDTP);
            this.Controls.Add(this.businessNameCB);
            this.Controls.Add(this.clientCB);
            this.Controls.Add(this.cardNumberCB);
            this.Name = "TransactionWritingScreen";
            this.Size = new System.Drawing.Size(603, 229);
            this.Load += new System.EventHandler(this.TransactionWritingScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paymentNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cardNumberCB;
        private System.Windows.Forms.ComboBox clientCB;
        private System.Windows.Forms.ComboBox businessNameCB;
        private System.Windows.Forms.DateTimePicker dateDTP;
        private System.Windows.Forms.NumericUpDown paymentNUD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private MaterialSkin.Controls.MaterialButton submitBtn;
        private MaterialSkin.Controls.MaterialCheckbox cardShowedCB;
    }
}

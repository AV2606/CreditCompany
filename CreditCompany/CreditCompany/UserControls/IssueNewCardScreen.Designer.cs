
namespace CreditCompany.UserControls
{
    partial class IssueNewCardScreen
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
            this.ClientsNameLabel = new System.Windows.Forms.Label();
            this.ClientIdLabel = new System.Windows.Forms.Label();
            this.clubNameTB = new System.Windows.Forms.TextBox();
            this.accountsCB = new System.Windows.Forms.ComboBox();
            this.cardCreditInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chooseRespondeBtn = new MaterialSkin.Controls.MaterialButton();
            this.respondRequestLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.issueBtn = new MaterialSkin.Controls.MaterialButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.cardCreditInput)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientsNameLabel
            // 
            this.ClientsNameLabel.AutoSize = true;
            this.ClientsNameLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClientsNameLabel.Location = new System.Drawing.Point(493, 0);
            this.ClientsNameLabel.Name = "ClientsNameLabel";
            this.ClientsNameLabel.Size = new System.Drawing.Size(104, 19);
            this.ClientsNameLabel.TabIndex = 3;
            this.ClientsNameLabel.Text = "ישראל ישראלי";
            // 
            // ClientIdLabel
            // 
            this.ClientIdLabel.AutoSize = true;
            this.ClientIdLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClientIdLabel.Location = new System.Drawing.Point(333, 0);
            this.ClientIdLabel.Name = "ClientIdLabel";
            this.ClientIdLabel.Size = new System.Drawing.Size(106, 19);
            this.ClientIdLabel.TabIndex = 4;
            this.ClientIdLabel.Text = "מספר לקוח: 1";
            // 
            // clubNameTB
            // 
            this.clubNameTB.Location = new System.Drawing.Point(292, 69);
            this.clubNameTB.Name = "clubNameTB";
            this.clubNameTB.Size = new System.Drawing.Size(147, 27);
            this.clubNameTB.TabIndex = 6;
            this.clubNameTB.Text = "הכללי";
            this.clubNameTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clubNameTB.TextChanged += new System.EventHandler(this.clubNameTB_TextChanged);
            // 
            // accountsCB
            // 
            this.accountsCB.FormattingEnabled = true;
            this.accountsCB.Location = new System.Drawing.Point(3, 68);
            this.accountsCB.Name = "accountsCB";
            this.accountsCB.Size = new System.Drawing.Size(283, 28);
            this.accountsCB.TabIndex = 7;
            this.accountsCB.SelectedIndexChanged += new System.EventHandler(this.accountsCB_SelectedIndexChanged);
            // 
            // cardCreditInput
            // 
            this.cardCreditInput.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.cardCreditInput.Location = new System.Drawing.Point(447, 69);
            this.cardCreditInput.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.cardCreditInput.Name = "cardCreditInput";
            this.cardCreditInput.Size = new System.Drawing.Size(147, 27);
            this.cardCreditInput.TabIndex = 8;
            this.cardCreditInput.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.cardCreditInput.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(336, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "מועדון הכרטיס";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(210, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "חשבון בנק";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(539, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "מסגרת";
            // 
            // chooseRespondeBtn
            // 
            this.chooseRespondeBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chooseRespondeBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.chooseRespondeBtn.Depth = 0;
            this.chooseRespondeBtn.HighEmphasis = true;
            this.chooseRespondeBtn.Icon = null;
            this.chooseRespondeBtn.Location = new System.Drawing.Point(302, 135);
            this.chooseRespondeBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.chooseRespondeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.chooseRespondeBtn.Name = "chooseRespondeBtn";
            this.chooseRespondeBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.chooseRespondeBtn.Size = new System.Drawing.Size(136, 36);
            this.chooseRespondeBtn.TabIndex = 13;
            this.chooseRespondeBtn.Text = "בחר בקשה להגבה";
            this.chooseRespondeBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.chooseRespondeBtn.UseAccentColor = false;
            this.chooseRespondeBtn.UseVisualStyleBackColor = true;
            this.chooseRespondeBtn.Click += new System.EventHandler(this.chooseRespondeBtn_Click);
            // 
            // respondRequestLabel
            // 
            this.respondRequestLabel.AutoSize = true;
            this.respondRequestLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.respondRequestLabel.Location = new System.Drawing.Point(3, 0);
            this.respondRequestLabel.Name = "respondRequestLabel";
            this.respondRequestLabel.Size = new System.Drawing.Size(0, 19);
            this.respondRequestLabel.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "בקשה להגבה";
            // 
            // issueBtn
            // 
            this.issueBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.issueBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.issueBtn.Depth = 0;
            this.issueBtn.HighEmphasis = true;
            this.issueBtn.Icon = null;
            this.issueBtn.Location = new System.Drawing.Point(228, 228);
            this.issueBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.issueBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.issueBtn.Name = "issueBtn";
            this.issueBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.issueBtn.Size = new System.Drawing.Size(64, 36);
            this.issueBtn.TabIndex = 17;
            this.issueBtn.Text = "הנפק";
            this.issueBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.issueBtn.UseAccentColor = false;
            this.issueBtn.UseVisualStyleBackColor = true;
            this.issueBtn.Click += new System.EventHandler(this.issueBtn_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.respondRequestLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 128);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(270, 99);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // IssueNewCardScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.issueBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chooseRespondeBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cardCreditInput);
            this.Controls.Add(this.accountsCB);
            this.Controls.Add(this.clubNameTB);
            this.Controls.Add(this.ClientIdLabel);
            this.Controls.Add(this.ClientsNameLabel);
            this.Name = "IssueNewCardScreen";
            this.Size = new System.Drawing.Size(597, 293);
            this.Load += new System.EventHandler(this.IssueNewCardScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cardCreditInput)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ClientsNameLabel;
        private System.Windows.Forms.Label ClientIdLabel;
        private System.Windows.Forms.TextBox clubNameTB;
        private System.Windows.Forms.ComboBox accountsCB;
        private System.Windows.Forms.NumericUpDown cardCreditInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label respondRequestLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialButton chooseRespondeBtn;
        private MaterialSkin.Controls.MaterialButton issueBtn;
    }
}


namespace CreditCompany.UserControls
{
    partial class ManagerCardAction
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
            this.submitBtn = new MaterialSkin.Controls.MaterialButton();
            this.label2 = new System.Windows.Forms.Label();
            this.contentBoxTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.titleBoxTB = new System.Windows.Forms.TextBox();
            this.ClientsNameLabel = new System.Windows.Forms.Label();
            this.chooseRespondeBtn = new MaterialSkin.Controls.MaterialButton();
            this.chooseCardBtn = new MaterialSkin.Controls.MaterialButton();
            this.label3 = new System.Windows.Forms.Label();
            this.respondRequestLabel = new System.Windows.Forms.Label();
            this.cardDetailsLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // submitBtn
            // 
            this.submitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.submitBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.submitBtn.Depth = 0;
            this.submitBtn.HighEmphasis = true;
            this.submitBtn.Icon = null;
            this.submitBtn.Location = new System.Drawing.Point(317, 410);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.submitBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.submitBtn.Size = new System.Drawing.Size(75, 36);
            this.submitBtn.TabIndex = 9;
            this.submitBtn.Text = "submit";
            this.submitBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.submitBtn.UseAccentColor = false;
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 217);
            this.label2.Margin = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "תוכן";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contentBoxTB
            // 
            this.contentBoxTB.Location = new System.Drawing.Point(14, 240);
            this.contentBoxTB.Multiline = true;
            this.contentBoxTB.Name = "contentBoxTB";
            this.contentBoxTB.Size = new System.Drawing.Size(652, 143);
            this.contentBoxTB.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "כותרת";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleBoxTB
            // 
            this.titleBoxTB.Location = new System.Drawing.Point(14, 160);
            this.titleBoxTB.Name = "titleBoxTB";
            this.titleBoxTB.Size = new System.Drawing.Size(652, 27);
            this.titleBoxTB.TabIndex = 5;
            // 
            // ClientsNameLabel
            // 
            this.ClientsNameLabel.AutoSize = true;
            this.ClientsNameLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClientsNameLabel.Location = new System.Drawing.Point(559, 0);
            this.ClientsNameLabel.Name = "ClientsNameLabel";
            this.ClientsNameLabel.Size = new System.Drawing.Size(104, 19);
            this.ClientsNameLabel.TabIndex = 10;
            this.ClientsNameLabel.Text = "ישראל ישראלי";
            // 
            // chooseRespondeBtn
            // 
            this.chooseRespondeBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chooseRespondeBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.chooseRespondeBtn.Depth = 0;
            this.chooseRespondeBtn.HighEmphasis = true;
            this.chooseRespondeBtn.Icon = null;
            this.chooseRespondeBtn.Location = new System.Drawing.Point(523, 76);
            this.chooseRespondeBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.chooseRespondeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.chooseRespondeBtn.Name = "chooseRespondeBtn";
            this.chooseRespondeBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.chooseRespondeBtn.Size = new System.Drawing.Size(136, 36);
            this.chooseRespondeBtn.TabIndex = 11;
            this.chooseRespondeBtn.Text = "בחר בקשה להגבה";
            this.chooseRespondeBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.chooseRespondeBtn.UseAccentColor = false;
            this.chooseRespondeBtn.UseVisualStyleBackColor = true;
            this.chooseRespondeBtn.Click += new System.EventHandler(this.chooseRespondeBtn_Click);
            // 
            // chooseCardBtn
            // 
            this.chooseCardBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chooseCardBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.chooseCardBtn.Depth = 0;
            this.chooseCardBtn.HighEmphasis = true;
            this.chooseCardBtn.Icon = null;
            this.chooseCardBtn.Location = new System.Drawing.Point(282, 6);
            this.chooseCardBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.chooseCardBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.chooseCardBtn.Name = "chooseCardBtn";
            this.chooseCardBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.chooseCardBtn.Size = new System.Drawing.Size(92, 36);
            this.chooseCardBtn.TabIndex = 12;
            this.chooseCardBtn.Text = "בחר כרטיס";
            this.chooseCardBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.chooseCardBtn.UseAccentColor = false;
            this.chooseCardBtn.UseVisualStyleBackColor = true;
            this.chooseCardBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(14, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "בקשה להגבה";
            // 
            // respondRequestLabel
            // 
            this.respondRequestLabel.AutoSize = true;
            this.respondRequestLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.respondRequestLabel.Location = new System.Drawing.Point(14, 27);
            this.respondRequestLabel.Name = "respondRequestLabel";
            this.respondRequestLabel.Size = new System.Drawing.Size(0, 19);
            this.respondRequestLabel.TabIndex = 14;
            // 
            // cardDetailsLabel
            // 
            this.cardDetailsLabel.AutoSize = true;
            this.cardDetailsLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cardDetailsLabel.Location = new System.Drawing.Point(275, 3);
            this.cardDetailsLabel.Margin = new System.Windows.Forms.Padding(3);
            this.cardDetailsLabel.Name = "cardDetailsLabel";
            this.cardDetailsLabel.Size = new System.Drawing.Size(0, 19);
            this.cardDetailsLabel.TabIndex = 15;
            this.cardDetailsLabel.Click += new System.EventHandler(this.cardDetailsLabel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.chooseCardBtn);
            this.flowLayoutPanel1.Controls.Add(this.cardDetailsLabel);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(285, 22);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(378, 48);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // ManagerCardAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.respondRequestLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chooseRespondeBtn);
            this.Controls.Add(this.ClientsNameLabel);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contentBoxTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleBoxTB);
            this.Name = "ManagerCardAction";
            this.Size = new System.Drawing.Size(666, 452);
            this.Load += new System.EventHandler(this.ManagerCardAction_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox contentBoxTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleBoxTB;
        private System.Windows.Forms.Label ClientsNameLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label respondRequestLabel;
        private System.Windows.Forms.Label cardDetailsLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialButton submitBtn;
        private MaterialSkin.Controls.MaterialButton chooseRespondeBtn;
        private MaterialSkin.Controls.MaterialButton chooseCardBtn;
    }
}

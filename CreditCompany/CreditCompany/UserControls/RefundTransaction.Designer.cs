
namespace CreditCompany.UserControls
{
    partial class RefundTransaction
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
            this.requestRespondBtn = new MaterialSkin.Controls.MaterialButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.respondRequestLabel = new CreditCompany.UserControls.RequestLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.TransactToRefundCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.submitBtn = new MaterialSkin.Controls.MaterialButton();
            this.label2 = new System.Windows.Forms.Label();
            this.contentBoxTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleBoxTB = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // requestRespondBtn
            // 
            this.requestRespondBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.requestRespondBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.requestRespondBtn.Depth = 0;
            this.requestRespondBtn.HighEmphasis = true;
            this.requestRespondBtn.Icon = null;
            this.requestRespondBtn.Location = new System.Drawing.Point(289, 3);
            this.requestRespondBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.requestRespondBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.requestRespondBtn.Name = "requestRespondBtn";
            this.requestRespondBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.requestRespondBtn.Size = new System.Drawing.Size(136, 36);
            this.requestRespondBtn.TabIndex = 0;
            this.requestRespondBtn.Text = "בחר בקשה להגבה";
            this.requestRespondBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.requestRespondBtn.UseAccentColor = false;
            this.requestRespondBtn.UseVisualStyleBackColor = true;
            this.requestRespondBtn.Click += new System.EventHandler(this.requestRespondBtn_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.respondRequestLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 31);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(224, 99);
            this.flowLayoutPanel1.TabIndex = 20;
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
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 19);
            this.label5.TabIndex = 19;
            this.label5.Text = "בקשה להגבה";
            // 
            // TransactToRefundCB
            // 
            this.TransactToRefundCB.FormattingEnabled = true;
            this.TransactToRefundCB.Location = new System.Drawing.Point(233, 102);
            this.TransactToRefundCB.Name = "TransactToRefundCB";
            this.TransactToRefundCB.Size = new System.Drawing.Size(194, 28);
            this.TransactToRefundCB.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(275, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "מספר עסקה להחזרה";
            // 
            // submitBtn
            // 
            this.submitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.submitBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.submitBtn.Depth = 0;
            this.submitBtn.HighEmphasis = true;
            this.submitBtn.Icon = null;
            this.submitBtn.Location = new System.Drawing.Point(222, 415);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.submitBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.submitBtn.Size = new System.Drawing.Size(75, 36);
            this.submitBtn.TabIndex = 27;
            this.submitBtn.Text = "submit";
            this.submitBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.submitBtn.UseAccentColor = false;
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 222);
            this.label2.Margin = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "תוכן";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contentBoxTB
            // 
            this.contentBoxTB.Location = new System.Drawing.Point(3, 245);
            this.contentBoxTB.Multiline = true;
            this.contentBoxTB.Name = "contentBoxTB";
            this.contentBoxTB.Size = new System.Drawing.Size(425, 143);
            this.contentBoxTB.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "כותרת";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleBoxTB
            // 
            this.titleBoxTB.Location = new System.Drawing.Point(3, 165);
            this.titleBoxTB.Name = "titleBoxTB";
            this.titleBoxTB.Size = new System.Drawing.Size(424, 27);
            this.titleBoxTB.TabIndex = 23;
            // 
            // RefundTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contentBoxTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.titleBoxTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TransactToRefundCB);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.requestRespondBtn);
            this.Name = "RefundTransaction";
            this.Size = new System.Drawing.Size(430, 457);
            this.Load += new System.EventHandler(this.RefundTransaction_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private RequestLabel respondRequestLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox TransactToRefundCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox contentBoxTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox titleBoxTB;
        private MaterialSkin.Controls.MaterialButton requestRespondBtn;
        private MaterialSkin.Controls.MaterialButton submitBtn;
    }
}


namespace CreditCompany.UserControls
{
    partial class RequestFromClientPicker
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
            this.label3 = new System.Windows.Forms.Label();
            this.RequestsFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.RequestLabelInstance = new System.Windows.Forms.Label();
            this.chosenReqFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.chosenLabel = new CreditCompany.UserControls.RequestLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new MaterialSkin.Controls.MaterialButton();
            this.cancelBtn = new MaterialSkin.Controls.MaterialButton();
            this.RequestsFLP.SuspendLayout();
            this.chosenReqFLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(697, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "בקשות";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RequestsFLP
            // 
            this.RequestsFLP.AutoScroll = true;
            this.RequestsFLP.AutoScrollMargin = new System.Drawing.Size(2, 2);
            this.RequestsFLP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RequestsFLP.Controls.Add(this.RequestLabelInstance);
            this.RequestsFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.RequestsFLP.Location = new System.Drawing.Point(429, 35);
            this.RequestsFLP.Name = "RequestsFLP";
            this.RequestsFLP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RequestsFLP.Size = new System.Drawing.Size(324, 352);
            this.RequestsFLP.TabIndex = 18;
            this.RequestsFLP.WrapContents = false;
            // 
            // RequestLabelInstance
            // 
            this.RequestLabelInstance.AutoSize = true;
            this.RequestLabelInstance.Dock = System.Windows.Forms.DockStyle.Top;
            this.RequestLabelInstance.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RequestLabelInstance.Location = new System.Drawing.Point(162, 0);
            this.RequestLabelInstance.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.RequestLabelInstance.Name = "RequestLabelInstance";
            this.RequestLabelInstance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RequestLabelInstance.Size = new System.Drawing.Size(157, 57);
            this.RequestLabelInstance.TabIndex = 17;
            this.RequestLabelInstance.Text = "לקוח מספר: \r\nחסימת כרטיס לדוגמה\r\nכרטיס מספר: 2561\r\n";
            // 
            // chosenReqFLP
            // 
            this.chosenReqFLP.AutoScroll = true;
            this.chosenReqFLP.AutoScrollMargin = new System.Drawing.Size(2, 2);
            this.chosenReqFLP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chosenReqFLP.Controls.Add(this.chosenLabel);
            this.chosenReqFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.chosenReqFLP.Location = new System.Drawing.Point(3, 36);
            this.chosenReqFLP.Name = "chosenReqFLP";
            this.chosenReqFLP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chosenReqFLP.Size = new System.Drawing.Size(324, 352);
            this.chosenReqFLP.TabIndex = 19;
            this.chosenReqFLP.WrapContents = false;
            // 
            // chosenLabel
            // 
            this.chosenLabel.AutoSize = true;
            this.chosenLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.chosenLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chosenLabel.Location = new System.Drawing.Point(319, 0);
            this.chosenLabel.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.chosenLabel.Name = "chosenLabel";
            this.chosenLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chosenLabel.Size = new System.Drawing.Size(0, 19);
            this.chosenLabel.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(209, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "בקשה שנבחרה";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button1.Depth = 0;
            this.button1.HighEmphasis = true;
            this.button1.Icon = null;
            this.button1.Location = new System.Drawing.Point(334, 168);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button1.Size = new System.Drawing.Size(64, 36);
            this.button1.TabIndex = 21;
            this.button1.Text = "בחר";
            this.button1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button1.UseAccentColor = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.cancelBtn.Depth = 0;
            this.cancelBtn.HighEmphasis = true;
            this.cancelBtn.Icon = null;
            this.cancelBtn.Location = new System.Drawing.Point(333, 216);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cancelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.cancelBtn.Size = new System.Drawing.Size(64, 36);
            this.cancelBtn.TabIndex = 22;
            this.cancelBtn.Text = "ביטול";
            this.cancelBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.cancelBtn.UseAccentColor = false;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // RequestFromClientPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chosenReqFLP);
            this.Controls.Add(this.RequestsFLP);
            this.Name = "RequestFromClientPicker";
            this.Size = new System.Drawing.Size(756, 396);
            this.Load += new System.EventHandler(this.RequestFromClientPicker_Load);
            this.RequestsFLP.ResumeLayout(false);
            this.RequestsFLP.PerformLayout();
            this.chosenReqFLP.ResumeLayout(false);
            this.chosenReqFLP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel RequestsFLP;
        private System.Windows.Forms.Label RequestLabelInstance;
        private System.Windows.Forms.FlowLayoutPanel chosenReqFLP;
        private RequestLabel chosenLabel;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialButton button1;
        private MaterialSkin.Controls.MaterialButton cancelBtn;
    }
}

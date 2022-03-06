
namespace CreditCompany.UserControls
{
    partial class ManagerScreen
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
            this.ClientsInfoBtn = new MaterialSkin.Controls.MaterialButton();
            this.UserAdderBtn = new MaterialSkin.Controls.MaterialButton();
            this.TransactBtn = new MaterialSkin.Controls.MaterialButton();
            this.FilterBtn = new MaterialSkin.Controls.MaterialButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CardNumberTB = new System.Windows.Forms.TextBox();
            this.ClientIdTB = new System.Windows.Forms.TextBox();
            this.RequestsFLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(864, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "בקשות";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // RequestsFLP
            // 
            this.RequestsFLP.AutoScroll = true;
            this.RequestsFLP.AutoScrollMargin = new System.Drawing.Size(2, 2);
            this.RequestsFLP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RequestsFLP.Controls.Add(this.RequestLabelInstance);
            this.RequestsFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.RequestsFLP.Location = new System.Drawing.Point(596, 75);
            this.RequestsFLP.Name = "RequestsFLP";
            this.RequestsFLP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RequestsFLP.Size = new System.Drawing.Size(324, 352);
            this.RequestsFLP.TabIndex = 16;
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
            this.RequestLabelInstance.Click += new System.EventHandler(this.RequestLabelClick);
            this.RequestLabelInstance.DoubleClick += new System.EventHandler(this.RequestLabelInstance_DoubleClick);
            // 
            // ClientsInfoBtn
            // 
            this.ClientsInfoBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientsInfoBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ClientsInfoBtn.Depth = 0;
            this.ClientsInfoBtn.HighEmphasis = true;
            this.ClientsInfoBtn.Icon = null;
            this.ClientsInfoBtn.Location = new System.Drawing.Point(69, 248);
            this.ClientsInfoBtn.Margin = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.ClientsInfoBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ClientsInfoBtn.Name = "ClientsInfoBtn";
            this.ClientsInfoBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ClientsInfoBtn.Size = new System.Drawing.Size(88, 36);
            this.ClientsInfoBtn.TabIndex = 18;
            this.ClientsInfoBtn.Text = "פרטי לקוח";
            this.ClientsInfoBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ClientsInfoBtn.UseAccentColor = false;
            this.ClientsInfoBtn.UseVisualStyleBackColor = true;
            this.ClientsInfoBtn.Click += new System.EventHandler(this.ClientsInfoBtn_Click);
            // 
            // UserAdderBtn
            // 
            this.UserAdderBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.UserAdderBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.UserAdderBtn.Depth = 0;
            this.UserAdderBtn.HighEmphasis = true;
            this.UserAdderBtn.Icon = null;
            this.UserAdderBtn.Location = new System.Drawing.Point(465, 310);
            this.UserAdderBtn.Margin = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.UserAdderBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.UserAdderBtn.Name = "UserAdderBtn";
            this.UserAdderBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.UserAdderBtn.Size = new System.Drawing.Size(129, 36);
            this.UserAdderBtn.TabIndex = 19;
            this.UserAdderBtn.Text = "הוסף לקוח\\מנהל";
            this.UserAdderBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.UserAdderBtn.UseAccentColor = false;
            this.UserAdderBtn.UseVisualStyleBackColor = true;
            this.UserAdderBtn.Click += new System.EventHandler(this.UserAdderBtn_Click);
            // 
            // TransactBtn
            // 
            this.TransactBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TransactBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.TransactBtn.Depth = 0;
            this.TransactBtn.HighEmphasis = true;
            this.TransactBtn.Icon = null;
            this.TransactBtn.Location = new System.Drawing.Point(478, 250);
            this.TransactBtn.Margin = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.TransactBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.TransactBtn.Name = "TransactBtn";
            this.TransactBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.TransactBtn.Size = new System.Drawing.Size(115, 36);
            this.TransactBtn.TabIndex = 20;
            this.TransactBtn.Text = "רישום עסקאות";
            this.TransactBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.TransactBtn.UseAccentColor = false;
            this.TransactBtn.UseVisualStyleBackColor = true;
            this.TransactBtn.Click += new System.EventHandler(this.TransactBtn_Click);
            // 
            // FilterBtn
            // 
            this.FilterBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FilterBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.FilterBtn.Depth = 0;
            this.FilterBtn.HighEmphasis = true;
            this.FilterBtn.Icon = null;
            this.FilterBtn.Location = new System.Drawing.Point(530, 76);
            this.FilterBtn.Margin = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.FilterBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.FilterBtn.Name = "FilterBtn";
            this.FilterBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.FilterBtn.Size = new System.Drawing.Size(64, 36);
            this.FilterBtn.TabIndex = 21;
            this.FilterBtn.Text = "סינון";
            this.FilterBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.FilterBtn.UseAccentColor = false;
            this.FilterBtn.UseVisualStyleBackColor = true;
            this.FilterBtn.Click += new System.EventHandler(this.FilterBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(54, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "מספר כרטיס לקוח";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "מספר לקוח";
            // 
            // CardNumberTB
            // 
            this.CardNumberTB.Enabled = false;
            this.CardNumberTB.Location = new System.Drawing.Point(55, 163);
            this.CardNumberTB.Name = "CardNumberTB";
            this.CardNumberTB.Size = new System.Drawing.Size(125, 27);
            this.CardNumberTB.TabIndex = 23;
            this.CardNumberTB.Visible = false;
            // 
            // ClientIdTB
            // 
            this.ClientIdTB.Location = new System.Drawing.Point(55, 63);
            this.ClientIdTB.Name = "ClientIdTB";
            this.ClientIdTB.Size = new System.Drawing.Size(125, 27);
            this.ClientIdTB.TabIndex = 22;
            // 
            // ManagerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CardNumberTB);
            this.Controls.Add(this.ClientIdTB);
            this.Controls.Add(this.FilterBtn);
            this.Controls.Add(this.TransactBtn);
            this.Controls.Add(this.UserAdderBtn);
            this.Controls.Add(this.ClientsInfoBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RequestsFLP);
            this.Name = "ManagerScreen";
            this.Size = new System.Drawing.Size(923, 430);
            this.Load += new System.EventHandler(this.ManagerScreen_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ManagerScreen_KeyPress);
            this.RequestsFLP.ResumeLayout(false);
            this.RequestsFLP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel RequestsFLP;
        private System.Windows.Forms.Label RequestLabelInstance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CardNumberTB;
        private System.Windows.Forms.TextBox ClientIdTB;
        private MaterialSkin.Controls.MaterialButton ClientsInfoBtn;
        private MaterialSkin.Controls.MaterialButton UserAdderBtn;
        private MaterialSkin.Controls.MaterialButton TransactBtn;
        private MaterialSkin.Controls.MaterialButton FilterBtn;
    }
}

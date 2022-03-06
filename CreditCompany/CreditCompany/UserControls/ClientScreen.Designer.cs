
namespace CreditCompany.UserControls
{
    partial class ClientScreen
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TransactionListFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.transactionLabelInstance = new System.Windows.Forms.Label();
            this.CardListFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.cardLabelInstance = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.NewCardRequestBtn = new MaterialSkin.Controls.MaterialButton();
            this.BlockCardBtn = new MaterialSkin.Controls.MaterialButton();
            this.TransactionsBtn = new MaterialSkin.Controls.MaterialButton();
            this.UsedCreditLabel = new System.Windows.Forms.Label();
            this.TotalCreditLabel = new System.Windows.Forms.Label();
            this.RequestsToCompanyBtn = new MaterialSkin.Controls.MaterialButton();
            this.ClientsNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TransactionListFLP.SuspendLayout();
            this.CardListFLP.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(25, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 19);
            this.label4.TabIndex = 38;
            this.label4.Text = "רשימת עסקאות לחודש נוכחי";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(270, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 19);
            this.label3.TabIndex = 37;
            this.label3.Text = "רשימת כרטיסים";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TransactionListFLP
            // 
            this.TransactionListFLP.Controls.Add(this.transactionLabelInstance);
            this.TransactionListFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.TransactionListFLP.Location = new System.Drawing.Point(5, 77);
            this.TransactionListFLP.Name = "TransactionListFLP";
            this.TransactionListFLP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TransactionListFLP.Size = new System.Drawing.Size(221, 352);
            this.TransactionListFLP.TabIndex = 36;
            // 
            // transactionLabelInstance
            // 
            this.transactionLabelInstance.AutoSize = true;
            this.transactionLabelInstance.Dock = System.Windows.Forms.DockStyle.Top;
            this.transactionLabelInstance.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.transactionLabelInstance.Location = new System.Drawing.Point(17, 0);
            this.transactionLabelInstance.Name = "transactionLabelInstance";
            this.transactionLabelInstance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.transactionLabelInstance.Size = new System.Drawing.Size(201, 57);
            this.transactionLabelInstance.TabIndex = 18;
            this.transactionLabelInstance.Text = "01.01.1970, עסקה לדוגמה: 100.00₪\r\nבכרטיס שמסתיים ב: 0000";
            // 
            // CardListFLP
            // 
            this.CardListFLP.Controls.Add(this.cardLabelInstance);
            this.CardListFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.CardListFLP.Location = new System.Drawing.Point(251, 77);
            this.CardListFLP.Name = "CardListFLP";
            this.CardListFLP.Size = new System.Drawing.Size(136, 352);
            this.CardListFLP.TabIndex = 35;
            // 
            // cardLabelInstance
            // 
            this.cardLabelInstance.AutoSize = true;
            this.cardLabelInstance.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardLabelInstance.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cardLabelInstance.Location = new System.Drawing.Point(3, 0);
            this.cardLabelInstance.Name = "cardLabelInstance";
            this.cardLabelInstance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cardLabelInstance.Size = new System.Drawing.Size(124, 133);
            this.cardLabelInstance.TabIndex = 17;
            this.cardLabelInstance.Text = "מועדון: הכללי\r\nמסתיים בספרות: 0000\r\nמסגרת: 10,000.00₪\r\nמסגרת פנויה: 3672.59₪";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.NewCardRequestBtn);
            this.flowLayoutPanel1.Controls.Add(this.BlockCardBtn);
            this.flowLayoutPanel1.Controls.Add(this.TransactionsBtn);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(750, 159);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(158, 198);
            this.flowLayoutPanel1.TabIndex = 33;
            // 
            // NewCardRequestBtn
            // 
            this.NewCardRequestBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NewCardRequestBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.NewCardRequestBtn.Depth = 0;
            this.NewCardRequestBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.NewCardRequestBtn.HighEmphasis = true;
            this.NewCardRequestBtn.Icon = null;
            this.NewCardRequestBtn.Location = new System.Drawing.Point(0, 15);
            this.NewCardRequestBtn.Margin = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.NewCardRequestBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewCardRequestBtn.Name = "NewCardRequestBtn";
            this.NewCardRequestBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.NewCardRequestBtn.Size = new System.Drawing.Size(158, 36);
            this.NewCardRequestBtn.TabIndex = 9;
            this.NewCardRequestBtn.Text = "הזמנת כרטיס חדש";
            this.NewCardRequestBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.NewCardRequestBtn.UseAccentColor = false;
            this.NewCardRequestBtn.UseVisualStyleBackColor = true;
            // 
            // BlockCardBtn
            // 
            this.BlockCardBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BlockCardBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BlockCardBtn.Depth = 0;
            this.BlockCardBtn.HighEmphasis = true;
            this.BlockCardBtn.Icon = null;
            this.BlockCardBtn.Location = new System.Drawing.Point(0, 81);
            this.BlockCardBtn.Margin = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.BlockCardBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.BlockCardBtn.Name = "BlockCardBtn";
            this.BlockCardBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BlockCardBtn.Size = new System.Drawing.Size(154, 36);
            this.BlockCardBtn.TabIndex = 10;
            this.BlockCardBtn.Text = "חסימת כרטיס אשראי";
            this.BlockCardBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BlockCardBtn.UseAccentColor = false;
            this.BlockCardBtn.UseVisualStyleBackColor = true;
            // 
            // TransactionsBtn
            // 
            this.TransactionsBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TransactionsBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.TransactionsBtn.Depth = 0;
            this.TransactionsBtn.HighEmphasis = true;
            this.TransactionsBtn.Icon = null;
            this.TransactionsBtn.Location = new System.Drawing.Point(0, 147);
            this.TransactionsBtn.Margin = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.TransactionsBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.TransactionsBtn.Name = "TransactionsBtn";
            this.TransactionsBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.TransactionsBtn.Size = new System.Drawing.Size(158, 36);
            this.TransactionsBtn.TabIndex = 11;
            this.TransactionsBtn.Text = "פירוט עסקאות מורחב";
            this.TransactionsBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.TransactionsBtn.UseAccentColor = false;
            this.TransactionsBtn.UseVisualStyleBackColor = true;
            // 
            // UsedCreditLabel
            // 
            this.UsedCreditLabel.AutoSize = true;
            this.UsedCreditLabel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UsedCreditLabel.ForeColor = System.Drawing.Color.Maroon;
            this.UsedCreditLabel.Location = new System.Drawing.Point(804, 96);
            this.UsedCreditLabel.Name = "UsedCreditLabel";
            this.UsedCreditLabel.Size = new System.Drawing.Size(113, 22);
            this.UsedCreditLabel.TabIndex = 32;
            this.UsedCreditLabel.Text = "₪10,000.00";
            this.UsedCreditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalCreditLabel
            // 
            this.TotalCreditLabel.AutoSize = true;
            this.TotalCreditLabel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TotalCreditLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.TotalCreditLabel.Location = new System.Drawing.Point(804, 37);
            this.TotalCreditLabel.Name = "TotalCreditLabel";
            this.TotalCreditLabel.Size = new System.Drawing.Size(113, 22);
            this.TotalCreditLabel.TabIndex = 31;
            this.TotalCreditLabel.Text = "₪10,000.00";
            this.TotalCreditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RequestsToCompanyBtn
            // 
            this.RequestsToCompanyBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RequestsToCompanyBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.RequestsToCompanyBtn.Depth = 0;
            this.RequestsToCompanyBtn.HighEmphasis = true;
            this.RequestsToCompanyBtn.Icon = null;
            this.RequestsToCompanyBtn.Location = new System.Drawing.Point(475, 159);
            this.RequestsToCompanyBtn.Margin = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.RequestsToCompanyBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.RequestsToCompanyBtn.Name = "RequestsToCompanyBtn";
            this.RequestsToCompanyBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.RequestsToCompanyBtn.Size = new System.Drawing.Size(158, 36);
            this.RequestsToCompanyBtn.TabIndex = 34;
            this.RequestsToCompanyBtn.Text = "שליחת בקשות לחברה";
            this.RequestsToCompanyBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.RequestsToCompanyBtn.UseAccentColor = false;
            this.RequestsToCompanyBtn.UseVisualStyleBackColor = true;
            // 
            // ClientsNameLabel
            // 
            this.ClientsNameLabel.AutoSize = true;
            this.ClientsNameLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClientsNameLabel.Location = new System.Drawing.Point(393, 2);
            this.ClientsNameLabel.Name = "ClientsNameLabel";
            this.ClientsNameLabel.Size = new System.Drawing.Size(104, 19);
            this.ClientsNameLabel.TabIndex = 30;
            this.ClientsNameLabel.Text = "ישראל ישראלי";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(795, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 19);
            this.label2.TabIndex = 29;
            this.label2.Text = "סה\"כ התחייבויות";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(822, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 28;
            this.label1.Text = "סה\"כ אשראי";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ClientScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TransactionListFLP);
            this.Controls.Add(this.CardListFLP);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.UsedCreditLabel);
            this.Controls.Add(this.TotalCreditLabel);
            this.Controls.Add(this.RequestsToCompanyBtn);
            this.Controls.Add(this.ClientsNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ClientScreen";
            this.Size = new System.Drawing.Size(923, 430);
            this.Load += new System.EventHandler(this.ClientScreen_Load);
            this.Validated += new System.EventHandler(this.ClientScreen_Validated);
            this.TransactionListFLP.ResumeLayout(false);
            this.TransactionListFLP.PerformLayout();
            this.CardListFLP.ResumeLayout(false);
            this.CardListFLP.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel TransactionListFLP;
        private System.Windows.Forms.Label transactionLabelInstance;
        private System.Windows.Forms.FlowLayoutPanel CardListFLP;
        private System.Windows.Forms.Label cardLabelInstance;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialButton NewCardRequestBtn;
        private MaterialSkin.Controls.MaterialButton BlockCardBtn;
        private MaterialSkin.Controls.MaterialButton TransactionsBtn;
        private System.Windows.Forms.Label UsedCreditLabel;
        private System.Windows.Forms.Label TotalCreditLabel;
        private MaterialSkin.Controls.MaterialButton RequestsToCompanyBtn;
        private System.Windows.Forms.Label ClientsNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

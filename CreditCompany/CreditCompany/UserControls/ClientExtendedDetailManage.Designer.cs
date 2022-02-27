
namespace CreditCompany.UserControls
{
    partial class ClientExtendedDetailManage
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
            this.refundTransactionBtn = new MaterialSkin.Controls.MaterialButton(); //System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.selectedTransactionFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.extendedDetailLabel = new CreditCompany.UserControls.TransactionLabel();
            this.TransactionListFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.transactionLabelInstance = new System.Windows.Forms.Label();
            this.clearSearchBtn = new MaterialSkin.Controls.MaterialButton();//System.Windows.Forms.Button();
            this.cardPickerBtn = new MaterialSkin.Controls.MaterialButton(); //System.Windows.Forms.Button();
            this.datePickerBtn = new MaterialSkin.Controls.MaterialButton(); //System.Windows.Forms.Button();
            this.ClientsNameLabel = new System.Windows.Forms.Label();
            this.selectedTransactionFLP.SuspendLayout();
            this.TransactionListFLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // refundTransactionBtn
            // 
            this.refundTransactionBtn.AutoSize = true;
            this.refundTransactionBtn.Enabled = false;
            this.refundTransactionBtn.Location = new System.Drawing.Point(481, 407);
            this.refundTransactionBtn.Name = "refundTransactionBtn";
            this.refundTransactionBtn.Size = new System.Drawing.Size(113, 30);
            this.refundTransactionBtn.TabIndex = 28;
            this.refundTransactionBtn.Text = "החזר עסקה";
            this.refundTransactionBtn.UseVisualStyleBackColor = true;
            this.refundTransactionBtn.Visible = false;
            this.refundTransactionBtn.Click += new System.EventHandler(this.denyTransactionBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(612, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 19);
            this.label4.TabIndex = 26;
            this.label4.Text = "רשימת עסקאות לחיפוש נוכחי";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // selectedTransactionFLP
            // 
            this.selectedTransactionFLP.Controls.Add(this.extendedDetailLabel);
            this.selectedTransactionFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.selectedTransactionFLP.Location = new System.Drawing.Point(373, 96);
            this.selectedTransactionFLP.Name = "selectedTransactionFLP";
            this.selectedTransactionFLP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectedTransactionFLP.Size = new System.Drawing.Size(221, 305);
            this.selectedTransactionFLP.TabIndex = 27;
            // 
            // extendedDetailLabel
            // 
            this.extendedDetailLabel.AutoSize = true;
            this.extendedDetailLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.extendedDetailLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.extendedDetailLabel.Location = new System.Drawing.Point(131, 0);
            this.extendedDetailLabel.Name = "extendedDetailLabel";
            this.extendedDetailLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.extendedDetailLabel.Size = new System.Drawing.Size(87, 19);
            this.extendedDetailLabel.TabIndex = 19;
            this.extendedDetailLabel.Text = "פרטי עסקה";
            // 
            // TransactionListFLP
            // 
            this.TransactionListFLP.Controls.Add(this.transactionLabelInstance);
            this.TransactionListFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.TransactionListFLP.Location = new System.Drawing.Point(600, 96);
            this.TransactionListFLP.Name = "TransactionListFLP";
            this.TransactionListFLP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TransactionListFLP.Size = new System.Drawing.Size(221, 340);
            this.TransactionListFLP.TabIndex = 25;
            // 
            // transactionLabelInstance
            // 
            this.transactionLabelInstance.AutoSize = true;
            this.transactionLabelInstance.Dock = System.Windows.Forms.DockStyle.Top;
            this.transactionLabelInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transactionLabelInstance.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.transactionLabelInstance.Location = new System.Drawing.Point(17, 3);
            this.transactionLabelInstance.Margin = new System.Windows.Forms.Padding(3);
            this.transactionLabelInstance.Name = "transactionLabelInstance";
            this.transactionLabelInstance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.transactionLabelInstance.Size = new System.Drawing.Size(201, 57);
            this.transactionLabelInstance.TabIndex = 18;
            this.transactionLabelInstance.Text = "01.01.1970, עסקה לדוגמה: 100.00₪\r\nבכרטיס שמסתיים ב: 0000";
            this.transactionLabelInstance.Click += new System.EventHandler(this.transactionLabelInstance_Click);
            // 
            // clearSearchBtn
            // 
            this.clearSearchBtn.Location = new System.Drawing.Point(476, 41);
            this.clearSearchBtn.Name = "clearSearchBtn";
            this.clearSearchBtn.Size = new System.Drawing.Size(94, 29);
            this.clearSearchBtn.TabIndex = 24;
            this.clearSearchBtn.Text = "נקה חיפוש";
            this.clearSearchBtn.UseVisualStyleBackColor = true;
            // 
            // cardPickerBtn
            // 
            this.cardPickerBtn.AutoSize = true;
            this.cardPickerBtn.Location = new System.Drawing.Point(576, 41);
            this.cardPickerBtn.Name = "cardPickerBtn";
            this.cardPickerBtn.Size = new System.Drawing.Size(119, 30);
            this.cardPickerBtn.TabIndex = 23;
            this.cardPickerBtn.Text = "בחירת כרטיסים";
            this.cardPickerBtn.UseVisualStyleBackColor = true;
            this.cardPickerBtn.Click += new System.EventHandler(this.cardPickerBtn_Click);
            // 
            // datePickerBtn
            // 
            this.datePickerBtn.AutoSize = true;
            this.datePickerBtn.Location = new System.Drawing.Point(701, 41);
            this.datePickerBtn.Name = "datePickerBtn";
            this.datePickerBtn.Size = new System.Drawing.Size(120, 30);
            this.datePickerBtn.TabIndex = 22;
            this.datePickerBtn.Text = "בחירת תאריכים";
            this.datePickerBtn.UseVisualStyleBackColor = true;
            // 
            // ClientsNameLabel
            // 
            this.ClientsNameLabel.AutoSize = true;
            this.ClientsNameLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClientsNameLabel.Location = new System.Drawing.Point(337, 4);
            this.ClientsNameLabel.Name = "ClientsNameLabel";
            this.ClientsNameLabel.Size = new System.Drawing.Size(104, 19);
            this.ClientsNameLabel.TabIndex = 21;
            this.ClientsNameLabel.Text = "ישראל ישראלי";
            // 
            // ClientExtendedDetailManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.refundTransactionBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selectedTransactionFLP);
            this.Controls.Add(this.TransactionListFLP);
            this.Controls.Add(this.clearSearchBtn);
            this.Controls.Add(this.cardPickerBtn);
            this.Controls.Add(this.datePickerBtn);
            this.Controls.Add(this.ClientsNameLabel);
            this.Name = "ClientExtendedDetailManage";
            this.Size = new System.Drawing.Size(824, 452);
            this.Load += new System.EventHandler(this.ClientExtendedDetailManage_Load);
            this.selectedTransactionFLP.ResumeLayout(false);
            this.selectedTransactionFLP.PerformLayout();
            this.TransactionListFLP.ResumeLayout(false);
            this.TransactionListFLP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refundTransactionBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel selectedTransactionFLP;
        private TransactionLabel extendedDetailLabel;
        private System.Windows.Forms.FlowLayoutPanel TransactionListFLP;
        private System.Windows.Forms.Label transactionLabelInstance;
        private System.Windows.Forms.Button clearSearchBtn;
        private System.Windows.Forms.Button cardPickerBtn;
        private System.Windows.Forms.Button datePickerBtn;
        private System.Windows.Forms.Label ClientsNameLabel;
    }
}

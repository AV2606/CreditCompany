
namespace CreditCompany.UserControls
{
    partial class ClientTransactionDetails
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
            this.datePickerBtn = new MaterialSkin.Controls.MaterialButton(); //System.Windows.Forms.Button();
            this.cardPickerBtn = new MaterialSkin.Controls.MaterialButton(); //System.Windows.Forms.Button();
            this.clearSearchBtn = new MaterialSkin.Controls.MaterialButton(); //System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TransactionListFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.transactionLabelInstance = new System.Windows.Forms.Label();
            this.selectedTransactionFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.extendedDetailLabel = new CreditCompany.UserControls.TransactionLabel();
            this.denyTransactionBtn = new MaterialSkin.Controls.MaterialButton(); //System.Windows.Forms.Button();
            this.TransactionListFLP.SuspendLayout();
            this.selectedTransactionFLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientsNameLabel
            // 
            this.ClientsNameLabel.AutoSize = true;
            this.ClientsNameLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClientsNameLabel.Location = new System.Drawing.Point(337, 0);
            this.ClientsNameLabel.Name = "ClientsNameLabel";
            this.ClientsNameLabel.Size = new System.Drawing.Size(104, 19);
            this.ClientsNameLabel.TabIndex = 3;
            this.ClientsNameLabel.Text = "ישראל ישראלי";
            // 
            // datePickerBtn
            // 
            this.datePickerBtn.AutoSize = true;
            this.datePickerBtn.Location = new System.Drawing.Point(701, 37);
            this.datePickerBtn.Name = "datePickerBtn";
            this.datePickerBtn.Size = new System.Drawing.Size(120, 30);
            this.datePickerBtn.TabIndex = 4;
            this.datePickerBtn.Text = "בחירת תאריכים";
            this.datePickerBtn.UseVisualStyleBackColor = true;
            this.datePickerBtn.Click += new System.EventHandler(this.datePickerBtn_Click);
            // 
            // cardPickerBtn
            // 
            this.cardPickerBtn.AutoSize = true;
            this.cardPickerBtn.Location = new System.Drawing.Point(576, 37);
            this.cardPickerBtn.Name = "cardPickerBtn";
            this.cardPickerBtn.Size = new System.Drawing.Size(119, 30);
            this.cardPickerBtn.TabIndex = 5;
            this.cardPickerBtn.Text = "בחירת כרטיסים";
            this.cardPickerBtn.UseVisualStyleBackColor = true;
            this.cardPickerBtn.Click += new System.EventHandler(this.cardPickerBtn_Click);
            // 
            // clearSearchBtn
            // 
            this.clearSearchBtn.Location = new System.Drawing.Point(476, 37);
            this.clearSearchBtn.Name = "clearSearchBtn";
            this.clearSearchBtn.Size = new System.Drawing.Size(94, 29);
            this.clearSearchBtn.TabIndex = 6;
            this.clearSearchBtn.Text = "נקה חיפוש";
            this.clearSearchBtn.UseVisualStyleBackColor = true;
            this.clearSearchBtn.Click += new System.EventHandler(this.clearSearchBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(612, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "רשימת עסקאות לחיפוש נוכחי";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TransactionListFLP
            // 
            this.TransactionListFLP.Controls.Add(this.transactionLabelInstance);
            this.TransactionListFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.TransactionListFLP.Location = new System.Drawing.Point(600, 92);
            this.TransactionListFLP.Name = "TransactionListFLP";
            this.TransactionListFLP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TransactionListFLP.Size = new System.Drawing.Size(221, 340);
            this.TransactionListFLP.TabIndex = 17;
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
            // 
            // selectedTransactionFLP
            // 
            this.selectedTransactionFLP.Controls.Add(this.extendedDetailLabel);
            this.selectedTransactionFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.selectedTransactionFLP.Location = new System.Drawing.Point(373, 92);
            this.selectedTransactionFLP.Name = "selectedTransactionFLP";
            this.selectedTransactionFLP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectedTransactionFLP.Size = new System.Drawing.Size(221, 305);
            this.selectedTransactionFLP.TabIndex = 19;
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
            // denyTransactionBtn
            // 
            this.denyTransactionBtn.AutoSize = true;
            this.denyTransactionBtn.Enabled = false;
            this.denyTransactionBtn.Location = new System.Drawing.Point(481, 403);
            this.denyTransactionBtn.Name = "denyTransactionBtn";
            this.denyTransactionBtn.Size = new System.Drawing.Size(113, 30);
            this.denyTransactionBtn.TabIndex = 20;
            this.denyTransactionBtn.Text = "הכחשת עסקה";
            this.denyTransactionBtn.UseVisualStyleBackColor = true;
            this.denyTransactionBtn.Visible = false;
            this.denyTransactionBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // ClientTransactionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.denyTransactionBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selectedTransactionFLP);
            this.Controls.Add(this.TransactionListFLP);
            this.Controls.Add(this.clearSearchBtn);
            this.Controls.Add(this.cardPickerBtn);
            this.Controls.Add(this.datePickerBtn);
            this.Controls.Add(this.ClientsNameLabel);
            this.Name = "ClientTransactionDetails";
            this.Size = new System.Drawing.Size(824, 452);
            this.Load += new System.EventHandler(this.ClientTransactionDetails_Load);
            this.TransactionListFLP.ResumeLayout(false);
            this.TransactionListFLP.PerformLayout();
            this.selectedTransactionFLP.ResumeLayout(false);
            this.selectedTransactionFLP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ClientsNameLabel;
        private System.Windows.Forms.Button datePickerBtn;
        private System.Windows.Forms.Button cardPickerBtn;
        private System.Windows.Forms.Button clearSearchBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel TransactionListFLP;
        private System.Windows.Forms.Label transactionLabelInstance;
        private System.Windows.Forms.FlowLayoutPanel selectedTransactionFLP;
        private TransactionLabel extendedDetailLabel;
        private System.Windows.Forms.Button denyTransactionBtn;
    }
}

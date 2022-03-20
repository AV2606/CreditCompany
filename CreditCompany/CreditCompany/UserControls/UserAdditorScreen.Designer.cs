
namespace CreditCompany.UserControls
{
    partial class UserAdditorScreen
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
            this.userNameTB = new System.Windows.Forms.TextBox();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.creditScoreNUD = new System.Windows.Forms.NumericUpDown();
            this.startDateDTP = new System.Windows.Forms.DateTimePicker();
            this.firstNameTB = new System.Windows.Forms.TextBox();
            this.lastNameTB = new System.Windows.Forms.TextBox();
            this.bankCB = new System.Windows.Forms.ComboBox();
            this.branchCB = new System.Windows.Forms.ComboBox();
            this.accountNUD = new System.Windows.Forms.NumericUpDown();
            this.sendBtn = new MaterialSkin.Controls.MaterialButton();
            this.ClientsNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.takenUserNameLabel = new System.Windows.Forms.Label();
            this.incorrectPasswordLabel = new System.Windows.Forms.Label();
            this.creditScoreInvalidLabel = new System.Windows.Forms.Label();
            this.chooseBankLabel = new System.Windows.Forms.Label();
            this.chooseBranchLabel = new System.Windows.Forms.Label();
            this.accountInvalidLabel = new System.Windows.Forms.Label();
            this.identityNullLabel = new System.Windows.Forms.Label();
            this.isManagerRB = new MaterialSkin.Controls.MaterialCheckbox();
            this.isClientRB = new MaterialSkin.Controls.MaterialCheckbox();
            ((System.ComponentModel.ISupportInitialize)(this.creditScoreNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // userNameTB
            // 
            this.userNameTB.Location = new System.Drawing.Point(402, 28);
            this.userNameTB.Name = "userNameTB";
            this.userNameTB.Size = new System.Drawing.Size(125, 27);
            this.userNameTB.TabIndex = 0;
            this.userNameTB.Text = "Avichay12";
            this.userNameTB.TextChanged += new System.EventHandler(this.userNameTB_TextChanged);
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(183, 28);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(213, 27);
            this.passwordTB.TabIndex = 1;
            this.passwordTB.Text = "12345678901234567890";
            this.passwordTB.TextChanged += new System.EventHandler(this.passwordTB_TextChanged);
            // 
            // creditScoreNUD
            // 
            this.creditScoreNUD.Location = new System.Drawing.Point(84, 29);
            this.creditScoreNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.creditScoreNUD.Name = "creditScoreNUD";
            this.creditScoreNUD.Size = new System.Drawing.Size(93, 27);
            this.creditScoreNUD.TabIndex = 2;
            this.creditScoreNUD.ValueChanged += new System.EventHandler(this.creditScoreNUD_ValueChanged);
            // 
            // startDateDTP
            // 
            this.startDateDTP.Location = new System.Drawing.Point(315, 101);
            this.startDateDTP.Name = "startDateDTP";
            this.startDateDTP.Size = new System.Drawing.Size(212, 27);
            this.startDateDTP.TabIndex = 3;
            // 
            // firstNameTB
            // 
            this.firstNameTB.Location = new System.Drawing.Point(144, 101);
            this.firstNameTB.Name = "firstNameTB";
            this.firstNameTB.Size = new System.Drawing.Size(164, 27);
            this.firstNameTB.TabIndex = 4;
            this.firstNameTB.Text = "Avichay12";
            // 
            // lastNameTB
            // 
            this.lastNameTB.Location = new System.Drawing.Point(1, 101);
            this.lastNameTB.Name = "lastNameTB";
            this.lastNameTB.Size = new System.Drawing.Size(137, 27);
            this.lastNameTB.TabIndex = 5;
            this.lastNameTB.Text = "Avichay12";
            // 
            // bankCB
            // 
            this.bankCB.FormattingEnabled = true;
            this.bankCB.Location = new System.Drawing.Point(376, 165);
            this.bankCB.Name = "bankCB";
            this.bankCB.Size = new System.Drawing.Size(151, 28);
            this.bankCB.TabIndex = 6;
            this.bankCB.SelectedIndexChanged += new System.EventHandler(this.bankCB_SelectedIndexChanged);
            // 
            // branchCB
            // 
            this.branchCB.FormattingEnabled = true;
            this.branchCB.Location = new System.Drawing.Point(219, 165);
            this.branchCB.Name = "branchCB";
            this.branchCB.Size = new System.Drawing.Size(151, 28);
            this.branchCB.TabIndex = 7;
            this.branchCB.SelectedIndexChanged += new System.EventHandler(this.branchCB_SelectedIndexChanged);
            // 
            // accountNUD
            // 
            this.accountNUD.Location = new System.Drawing.Point(112, 166);
            this.accountNUD.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.accountNUD.Name = "accountNUD";
            this.accountNUD.Size = new System.Drawing.Size(101, 27);
            this.accountNUD.TabIndex = 8;
            this.accountNUD.Value = new decimal(new int[] {
            123456789,
            0,
            0,
            0});
            this.accountNUD.ValueChanged += new System.EventHandler(this.accountNUD_ValueChanged);
            // 
            // sendBtn
            // 
            this.sendBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sendBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.sendBtn.Depth = 0;
            this.sendBtn.HighEmphasis = true;
            this.sendBtn.Icon = null;
            this.sendBtn.Location = new System.Drawing.Point(219, 239);
            this.sendBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.sendBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.sendBtn.Size = new System.Drawing.Size(145, 36);
            this.sendBtn.TabIndex = 11;
            this.sendBtn.Text = "הוסף\r\nוהנפק כרטיס ראשון";
            this.sendBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.sendBtn.UseAccentColor = false;
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // ClientsNameLabel
            // 
            this.ClientsNameLabel.AutoSize = true;
            this.ClientsNameLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClientsNameLabel.Location = new System.Drawing.Point(434, 7);
            this.ClientsNameLabel.Name = "ClientsNameLabel";
            this.ClientsNameLabel.Size = new System.Drawing.Size(93, 19);
            this.ClientsNameLabel.TabIndex = 12;
            this.ClientsNameLabel.Text = "שם משתמש";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(342, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "סיסמה";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(84, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "דירוג אשראי";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(354, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "תאריך תחילת התקשרות";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(238, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "שם פרטי";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(49, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 17;
            this.label5.Text = "שם משפחה";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(446, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 19);
            this.label6.TabIndex = 18;
            this.label6.Text = "מספר בנק";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(285, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 19;
            this.label7.Text = "מספר סניף";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(119, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 19);
            this.label8.TabIndex = 20;
            this.label8.Text = "מספר חשבון";
            // 
            // takenUserNameLabel
            // 
            this.takenUserNameLabel.AutoSize = true;
            this.takenUserNameLabel.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.takenUserNameLabel.ForeColor = System.Drawing.Color.Red;
            this.takenUserNameLabel.Location = new System.Drawing.Point(426, 58);
            this.takenUserNameLabel.Name = "takenUserNameLabel";
            this.takenUserNameLabel.Size = new System.Drawing.Size(101, 15);
            this.takenUserNameLabel.TabIndex = 21;
            this.takenUserNameLabel.Text = "שם משתמש תפוס";
            this.takenUserNameLabel.Visible = false;
            // 
            // incorrectPasswordLabel
            // 
            this.incorrectPasswordLabel.AutoSize = true;
            this.incorrectPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.incorrectPasswordLabel.ForeColor = System.Drawing.Color.Red;
            this.incorrectPasswordLabel.Location = new System.Drawing.Point(207, 58);
            this.incorrectPasswordLabel.Name = "incorrectPasswordLabel";
            this.incorrectPasswordLabel.Size = new System.Drawing.Size(189, 15);
            this.incorrectPasswordLabel.TabIndex = 22;
            this.incorrectPasswordLabel.Text = "הסיסמה צריכה להיות בין 6-20 תווים";
            this.incorrectPasswordLabel.Visible = false;
            // 
            // creditScoreInvalidLabel
            // 
            this.creditScoreInvalidLabel.AutoSize = true;
            this.creditScoreInvalidLabel.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.creditScoreInvalidLabel.ForeColor = System.Drawing.Color.Red;
            this.creditScoreInvalidLabel.Location = new System.Drawing.Point(0, 58);
            this.creditScoreInvalidLabel.Name = "creditScoreInvalidLabel";
            this.creditScoreInvalidLabel.Size = new System.Drawing.Size(195, 15);
            this.creditScoreInvalidLabel.TabIndex = 23;
            this.creditScoreInvalidLabel.Text = "דירוג אשראי צריך להיות בין 100-1000";
            this.creditScoreInvalidLabel.Visible = false;
            // 
            // chooseBankLabel
            // 
            this.chooseBankLabel.AutoSize = true;
            this.chooseBankLabel.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chooseBankLabel.ForeColor = System.Drawing.Color.Red;
            this.chooseBankLabel.Location = new System.Drawing.Point(475, 196);
            this.chooseBankLabel.Name = "chooseBankLabel";
            this.chooseBankLabel.Size = new System.Drawing.Size(52, 15);
            this.chooseBankLabel.TabIndex = 24;
            this.chooseBankLabel.Text = "בחר בנק";
            this.chooseBankLabel.Visible = false;
            // 
            // chooseBranchLabel
            // 
            this.chooseBranchLabel.AutoSize = true;
            this.chooseBranchLabel.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chooseBranchLabel.ForeColor = System.Drawing.Color.Red;
            this.chooseBranchLabel.Location = new System.Drawing.Point(311, 196);
            this.chooseBranchLabel.Name = "chooseBranchLabel";
            this.chooseBranchLabel.Size = new System.Drawing.Size(55, 15);
            this.chooseBranchLabel.TabIndex = 25;
            this.chooseBranchLabel.Text = "בחר סניף";
            this.chooseBranchLabel.Visible = false;
            // 
            // accountInvalidLabel
            // 
            this.accountInvalidLabel.AutoSize = true;
            this.accountInvalidLabel.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.accountInvalidLabel.ForeColor = System.Drawing.Color.Red;
            this.accountInvalidLabel.Location = new System.Drawing.Point(57, 196);
            this.accountInvalidLabel.Name = "accountInvalidLabel";
            this.accountInvalidLabel.Size = new System.Drawing.Size(156, 15);
            this.accountInvalidLabel.TabIndex = 26;
            this.accountInvalidLabel.Text = "מספר חשבון הוא עד 9 ספרות";
            this.accountInvalidLabel.Visible = false;
            // 
            // identityNullLabel
            // 
            this.identityNullLabel.AutoSize = true;
            this.identityNullLabel.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.identityNullLabel.ForeColor = System.Drawing.Color.Red;
            this.identityNullLabel.Location = new System.Drawing.Point(402, 288);
            this.identityNullLabel.Name = "identityNullLabel";
            this.identityNullLabel.Size = new System.Drawing.Size(121, 15);
            this.identityNullLabel.TabIndex = 27;
            this.identityNullLabel.Text = "בחר אופציה, או שתיהן";
            this.identityNullLabel.Visible = false;
            // 
            // isManagerRB
            // 
            this.isManagerRB.AutoSize = true;
            this.isManagerRB.Depth = 0;
            this.isManagerRB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.isManagerRB.Location = new System.Drawing.Point(410, 214);
            this.isManagerRB.Margin = new System.Windows.Forms.Padding(0);
            this.isManagerRB.MouseLocation = new System.Drawing.Point(-1, -1);
            this.isManagerRB.MouseState = MaterialSkin.MouseState.HOVER;
            this.isManagerRB.Name = "isManagerRB";
            this.isManagerRB.ReadOnly = false;
            this.isManagerRB.Ripple = true;
            this.isManagerRB.Size = new System.Drawing.Size(111, 37);
            this.isManagerRB.TabIndex = 28;
            this.isManagerRB.Text = "האם מנהל";
            this.isManagerRB.UseVisualStyleBackColor = true;
            this.isManagerRB.CheckedChanged += new System.EventHandler(this.isManagerRB_CheckedChanged_1);
            // 
            // isClientRB
            // 
            this.isClientRB.AutoSize = true;
            this.isClientRB.Depth = 0;
            this.isClientRB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.isClientRB.Location = new System.Drawing.Point(410, 251);
            this.isClientRB.Margin = new System.Windows.Forms.Padding(0);
            this.isClientRB.MouseLocation = new System.Drawing.Point(-1, -1);
            this.isClientRB.MouseState = MaterialSkin.MouseState.HOVER;
            this.isClientRB.Name = "isClientRB";
            this.isClientRB.ReadOnly = false;
            this.isClientRB.Ripple = true;
            this.isClientRB.Size = new System.Drawing.Size(109, 37);
            this.isClientRB.TabIndex = 29;
            this.isClientRB.Text = "האם לקוח";
            this.isClientRB.UseVisualStyleBackColor = true;
            this.isClientRB.CheckedChanged += new System.EventHandler(this.isClientRB_CheckedChanged_1);
            // 
            // UserAdditorScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.isClientRB);
            this.Controls.Add(this.isManagerRB);
            this.Controls.Add(this.identityNullLabel);
            this.Controls.Add(this.accountInvalidLabel);
            this.Controls.Add(this.chooseBranchLabel);
            this.Controls.Add(this.chooseBankLabel);
            this.Controls.Add(this.creditScoreInvalidLabel);
            this.Controls.Add(this.incorrectPasswordLabel);
            this.Controls.Add(this.takenUserNameLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClientsNameLabel);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.accountNUD);
            this.Controls.Add(this.branchCB);
            this.Controls.Add(this.bankCB);
            this.Controls.Add(this.lastNameTB);
            this.Controls.Add(this.firstNameTB);
            this.Controls.Add(this.startDateDTP);
            this.Controls.Add(this.creditScoreNUD);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.userNameTB);
            this.Name = "UserAdditorScreen";
            this.Size = new System.Drawing.Size(530, 335);
            this.Load += new System.EventHandler(this.UserAdditorScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.creditScoreNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userNameTB;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.NumericUpDown creditScoreNUD;
        private System.Windows.Forms.DateTimePicker startDateDTP;
        private System.Windows.Forms.TextBox firstNameTB;
        private System.Windows.Forms.TextBox lastNameTB;
        private System.Windows.Forms.ComboBox bankCB;
        private System.Windows.Forms.ComboBox branchCB;
        private System.Windows.Forms.NumericUpDown accountNUD;
        private System.Windows.Forms.Label ClientsNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label takenUserNameLabel;
        private System.Windows.Forms.Label incorrectPasswordLabel;
        private System.Windows.Forms.Label creditScoreInvalidLabel;
        private System.Windows.Forms.Label chooseBankLabel;
        private System.Windows.Forms.Label chooseBranchLabel;
        private System.Windows.Forms.Label accountInvalidLabel;
        private System.Windows.Forms.Label identityNullLabel;
        private MaterialSkin.Controls.MaterialButton sendBtn;
        private MaterialSkin.Controls.MaterialCheckbox isManagerRB;
        private MaterialSkin.Controls.MaterialCheckbox isClientRB;
    }
}

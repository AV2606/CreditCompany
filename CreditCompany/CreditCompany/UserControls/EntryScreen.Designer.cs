
namespace CreditCompany.UserControls
{
    partial class EntryScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.enterBtn = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // userNameTB
            // 
            this.userNameTB.Location = new System.Drawing.Point(105, 79);
            this.userNameTB.Name = "userNameTB";
            this.userNameTB.Size = new System.Drawing.Size(125, 27);
            this.userNameTB.TabIndex = 0;
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(105, 179);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(125, 27);
            this.passwordTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "שם משתמש";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "סיסמה";
            // 
            // enterBtn
            // 
            this.enterBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.enterBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.enterBtn.Depth = 0;
            this.enterBtn.HighEmphasis = true;
            this.enterBtn.Icon = null;
            this.enterBtn.Location = new System.Drawing.Point(119, 333);
            this.enterBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.enterBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.enterBtn.Size = new System.Drawing.Size(64, 36);
            this.enterBtn.TabIndex = 4;
            this.enterBtn.Text = "כניסה";
            this.enterBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.enterBtn.UseAccentColor = false;
            this.enterBtn.UseVisualStyleBackColor = true;
            this.enterBtn.Click += new System.EventHandler(this.enterBtn_Click);
            // 
            // EntryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.enterBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.userNameTB);
            this.Name = "EntryScreen";
            this.Size = new System.Drawing.Size(341, 460);
            this.Load += new System.EventHandler(this.EntryScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userNameTB;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialButton enterBtn;
    }
}

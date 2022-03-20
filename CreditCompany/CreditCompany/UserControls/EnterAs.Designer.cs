
namespace CreditCompany.UserControls
{
    partial class EnterAs
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
            this.EAManagerBtn = new MaterialSkin.Controls.MaterialButton();
            this.EAClientBtn = new MaterialSkin.Controls.MaterialButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EAManagerBtn
            // 
            this.EAManagerBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EAManagerBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.EAManagerBtn.Depth = 0;
            this.EAManagerBtn.HighEmphasis = true;
            this.EAManagerBtn.Icon = null;
            this.EAManagerBtn.Location = new System.Drawing.Point(3, 76);
            this.EAManagerBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.EAManagerBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.EAManagerBtn.Name = "EAManagerBtn";
            this.EAManagerBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.EAManagerBtn.Size = new System.Drawing.Size(89, 36);
            this.EAManagerBtn.TabIndex = 0;
            this.EAManagerBtn.Text = "כנס כמנהל";
            this.EAManagerBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.EAManagerBtn.UseAccentColor = false;
            this.EAManagerBtn.UseVisualStyleBackColor = true;
            this.EAManagerBtn.Click += new System.EventHandler(this.EAManagerBtn_Click);
            // 
            // EAClientBtn
            // 
            this.EAClientBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EAClientBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.EAClientBtn.Depth = 0;
            this.EAClientBtn.HighEmphasis = true;
            this.EAClientBtn.Icon = null;
            this.EAClientBtn.Location = new System.Drawing.Point(84, 3);
            this.EAClientBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.EAClientBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.EAClientBtn.Name = "EAClientBtn";
            this.EAClientBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.EAClientBtn.Size = new System.Drawing.Size(88, 36);
            this.EAClientBtn.TabIndex = 1;
            this.EAClientBtn.Text = "כנס כלקוח";
            this.EAClientBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.EAClientBtn.UseAccentColor = false;
            this.EAClientBtn.UseVisualStyleBackColor = true;
            this.EAClientBtn.Click += new System.EventHandler(this.EAClientBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.EAClientBtn);
            this.panel1.Controls.Add(this.EAManagerBtn);
            this.panel1.Location = new System.Drawing.Point(91, 186);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 115);
            this.panel1.TabIndex = 2;
            // 
            // EnterAs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "EnterAs";
            this.Size = new System.Drawing.Size(359, 447);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialButton EAManagerBtn;
        private MaterialSkin.Controls.MaterialButton EAClientBtn;
    }
}

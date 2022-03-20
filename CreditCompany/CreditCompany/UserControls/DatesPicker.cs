using CreditCompany.UserControls.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreditCompany.UserControls
{
    public partial class DatesPicker : UserControl
    {
        private DateTime start;
        private DateTime end;
        private bool valid = false;

        public DatesPicker()
        {
            InitializeComponent();
            foreach (Control item in Controls)
            {
                item.CenterHorizontal();
            }
        }

        private void DatesPicker_Load(object sender, EventArgs e)
        {

        }
        public static (DateTime start,DateTime end)? GetDates(IWin32Window owner)
        {
            var dp = new DatesPicker();
            Form f = new Form();
            f.AutoSizeMode = AutoSizeMode.GrowOnly;
            f.AutoSize = true;
            f.Controls.Add(dp);
            f.ShowDialog(owner);
            if (dp.valid == true)
                return (dp.start, dp.end);
            else
                return null;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (endDTP.Value < startDTP.Value)
                MessageBox.Show(this, "End date should be after or at the start date", "yesterday is a histroy, tommorrow is a mystery");
            else
            {
                start = startDTP.Value;
                end = endDTP.Value;
                valid = true;
                var p = this.Parent as Form;
                p.Close();
            }
            
        }
    }
}

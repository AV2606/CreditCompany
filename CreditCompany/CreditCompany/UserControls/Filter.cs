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
    public partial class Filter : UserControl
    {
        private (int id, string title) Answer => (castToId(ClientIdInput.Value), TitleTB.Text);
        public Filter()
        {
            InitializeComponent();
            foreach (object item in this.Controls)
            {
                if(item is Control c)
                c.CenterHorizontal();
            }
        }
        private int castToId(decimal id)
        {
            int i = Convert.ToInt32(id);
            if (i == 0)
                return -2;
            return i;
        }

        private void Filter_Load(object sender, EventArgs e)
        {

        }

        public static (int id, string title) GetFilter(IWin32Window owner)
        {
            Form f = new Form();
            var filter = new Filter();
            f.AutoSize = true;
            f.AutoSizeMode = AutoSizeMode.GrowOnly;
            f.Controls.Add(filter);
            filter.button1.Click += (sender, e) => {
                f.Close();
            };
            f.ShowDialog(owner);
            return filter.Answer;
        }
    }
}

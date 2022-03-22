using CreditCompany.UserControls.Extensions;
using CreditCompanyEF.Models;
using CreditCompanyEF.Proxies;
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
    public partial class CardsPicker : UserControl
    {
        private List<CreditCardClientProxy> cardsList;
        private CreditCardClientProxy chosen =null;

        private CardsPicker(IEnumerable<CreditCardClientProxy> creditCards)
        {
            InitializeComponent();
            this.cardsList = creditCards.ToList();
            cardsBox.Items.AddRange(cardsList.ToCardDisplay().ToArray());
        }

        private void CardsPicker_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CardDisplay display = cardsBox.SelectedItem as CardDisplay;
            chosen = display.card;
            if(chosen is not null)
            {
                var p = this.Parent as Form;
                p.Close();
            }
            else
            {
                MessageBox.Show(this, "Cant find the card", "what card??", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Chooses a card via a user control
        /// </summary>
        /// <param name="owner">The owner to hold when picking up a card.</param>
        /// <param name="cards">A list of cards to choose from.</param>
        /// <returns></returns>
        public static CreditCardClientProxy ChooseCard(IWin32Window owner,IEnumerable<CreditCardClientProxy> cards)
        {
            var picker = new CardsPicker(cards);
            Form f = new Form();
            f.Controls.Add(picker);
            f.AutoSize = true;
            f.ShowDialog(owner);
            return picker.chosen;
        }

        private void cardsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    public class CardDisplay:Displayer<CreditCardClientProxy>
    {
        public CreditCompanyEF.Proxies.CreditCardClientProxy card
        {
            get => Item;
            set { item = value; }
        }

        public CardDisplay(CreditCardClientProxy card) : base(card, null) { }

        public override string ToString()
        {
            
            return $"{card.CreditCardNumber}   \"{card.Club}\"";
        }
        public static explicit operator CardDisplay(CreditCompanyEF.Proxies.CreditCardClientProxy card)
        {
            return new CardDisplay(card);// { card = card };
        }
    }
}

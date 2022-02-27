using CreditCompany.UserControls.Extensions;
using CreditCompanyEF;
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
    public delegate void CardAction(CreditCardClientProxy card, RequestsFromClient respondRequest, string title, string content);

    public partial class ManagerCardAction : UserControl
    {
        readonly EventedObject<ManagerAgent> managerAgent = new EventedObject<ManagerAgent>();
        readonly EventedObject<ClientAgent> clientAgent = new EventedObject<ClientAgent>();
        readonly EventedObject<CreditCardClientProxy> chosenCard = new EventedObject<CreditCardClientProxy>();
        readonly EventedObject<RequestsFromClient> respondRequest = new EventedObject<RequestsFromClient>();
        CardAction Action { get; set; }

        /// <summary>
        /// Occurs when the user-control has submmited its data.
        /// </summary>
        public event EventHandler Submitted;


        public ManagerCardAction(ManagerAgent manager,ClientAgent client,CardAction action,CreditCardClientProxy card=null,RequestsFromClient respondMessage=null)
        {
            InitializeComponent();
            label1.CenterHorizontal();
            label2.CenterHorizontal();
            submitBtn.CenterHorizontal();
            contentBoxTB.CenterHorizontal();
            titleBoxTB.CenterHorizontal();


            this.Action = action;
            this.managerAgent.Set(manager);
            this.clientAgent.Set(client);
            this.chosenCard.Set(card);
            this.respondRequest.Set(respondMessage);

            chosenCard.ValueChanged += (sender,values)=>{
                if(values != default&&values.newValue is not null)
                cardDetailsLabel.Text = values.newValue.CreditCardNumber.Substring(12)+"- \""+values.newValue.Club+"\"";
            };
            this.respondRequest.ValueChanged += (sender, values) => {
                if (values != default && values.newValue is not null)
                    respondRequestLabel.Text = GetRequestText(values.newValue);
            };

            this.Submitted += (sender, e) => {
                MessageBox.Show(this, "The action was submmited!", "we did it!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            cardDetailsLabel.TextChanged += (sender, e) => {
               int XRight() {
                    return cardDetailsLabel.Location.X + cardDetailsLabel.Width;
                }
                //int diff = XRight() - chooseCardBtn.Location.X;

                //cardDetailsLabel.Location = new Point(0, cardDetailsLabel.Location.Y);
            };
        }
        private string GetRequestText(RequestsFromClient request)
        {
            return $"מספר לקוח: {request.ClientId}{Environment.NewLine}" +
                            $"{request.Title}{Environment.NewLine}" +
                            $"{request.Content}";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            chosenCard.Set((CreditCardClientProxy)CardsPicker.ChooseCard(this,clientAgent.Value.Client.CreditCards));   
        }

        private void ManagerCardAction_Load(object sender, EventArgs e)
        {
           
        }

        private void chooseRespondeBtn_Click(object sender, EventArgs e)
        {
            var temp=RequestFromClientPicker.Pick(this, managerAgent.Value.GetRequestsFromClients());
            if (temp is null)
                return;
                //throw new NullReferenceException(nameof(temp) + "is null!");
            respondRequest.Set(temp);
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if(chosenCard.Value is null)
            {
                MessageBox.Show(this, "Choose a card to do the action on it", "you had one job", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }   
            Action.Invoke(chosenCard.Value, respondRequest.Value, titleBoxTB.Text, contentBoxTB.Text);
            OnSubmmited();
        }

        private void OnSubmmited()
        {
            Submitted?.Invoke(this,new EventArgs());
        }

        private void cardDetailsLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

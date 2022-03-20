using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCompanyEF.Models
{
    class Creator
    {
        internal static void HasData(EntityTypeBuilder<Bank> entity)
        {
            var banks = new Bank[] { 
                new Bank(){BankNumber=11,BankName="Discount"},
                new Bank(){BankNumber=31,BankName="Habenleumi"},
                new Bank(){BankNumber=12,BankName="Hapoalim"},
                new Bank(){BankNumber=10,BankName="Leumi"},
                new Bank(){BankNumber=17,BankName="Marcentil Discount"},
                new Bank(){BankNumber=46,BankName="Massad"},
                new Bank(){BankNumber=20,BankName="Mizrahi Tfahot"},
                new Bank(){BankNumber=14,BankName="Otsar Hahayal"},
                new Bank(){BankNumber=9,BankName="Post Bank"},
                new Bank(){BankNumber=26,BankName="UBank"},
                new Bank(){BankNumber=13,BankName="Union"},
                new Bank(){BankNumber=4,BankName="Yahav"},
            };
            entity.HasData(banks);
        }

        internal static void HasData(EntityTypeBuilder<Account> entity)
        {
            var accounts = new Account[] {
                new Account(){UniqueAccountId=1, AccountNumber=130226, BranchNumber=109},
                new Account(){UniqueAccountId=2, AccountNumber=211544, BranchNumber=686}
            };

            entity.HasData(accounts);
        }

        internal static void HasData(EntityTypeBuilder<Branch> entity)
        {
            var branches = new Branch[] {
                new Branch(){ BranchNumber=1, BankNumber=9, BranchName="Israel"},
                new Branch(){ BranchNumber=109, BankNumber=31, BranchName="Ashkelon"},
                new Branch(){ BranchNumber=125, BankNumber=4, BranchName="Ashkelon"},
                new Branch(){ BranchNumber=128, BankNumber=11, BranchName="Ashkelon"},
                new Branch(){ BranchNumber=427, BankNumber=20, BranchName="Ashkelon"},
                new Branch(){ BranchNumber=650, BankNumber=12, BranchName="Afridar"},
                new Branch(){ BranchNumber=651, BankNumber=12, BranchName="Barnea"},
                new Branch(){ BranchNumber=686, BankNumber=12, BranchName="Shimshon"},
                new Branch(){ BranchNumber=925, BankNumber=10, BranchName="Ashkelon"},
                new Branch(){ BranchNumber=926, BankNumber=10, BranchName="Ashkelon"},
                new Branch(){ BranchNumber=927, BankNumber=10, BranchName="Qiryat-Gat"},
                new Branch(){BranchNumber=314,BankNumber=14,BranchName="Glilot"},
                new Branch(){BranchNumber=312,BankNumber=14,BranchName="Yavne"},
                new Branch(){BranchNumber=165,BankNumber=13,BranchName="romema"},
                new Branch(){BranchNumber=192,BankNumber=13,BranchName="Ashkelon"},
                new Branch(){BranchNumber=159,BankNumber=11,BranchName="Jerusalm central"},
                new Branch(){BranchNumber=374,BankNumber=31,BranchName="Lod"},
                new Branch(){BranchNumber=461,BankNumber=4,BranchName="Beit Shemesh"},
                new Branch(){BranchNumber=552,BankNumber=20,BranchName="Migdal HaEmeck"},
                new Branch(){BranchNumber=642,BankNumber=17,BranchName="Jerusalem main"},
                new Branch(){BranchNumber=646,BankNumber=17,BranchName="Egron"},
                new Branch(){BranchNumber=502,BankNumber=46,BranchName="Kfar Sava"},
                new Branch(){BranchNumber=515,BankNumber=46,BranchName="Jerusalem"},
                new Branch(){BranchNumber=280,BankNumber=26,BranchName="Raanana"},
                new Branch(){BranchNumber=262,BankNumber=26,BranchName="Rehavia"},
            };

            entity.HasData(branches);
        }

        internal static void HasData(EntityTypeBuilder<Client> entity)
        {
            var clients = new Client[] { 
                new Client(){ClientId=-1,FirstName="Deleted",LastName="Client",CreditScore=0,AssignDate=new DateTime(2022,1,31)},
                new Client(){ClientId=1,FirstName="Avichay",LastName="Vaknin",CreditScore=675, AssignDate=new DateTime(2022,1,1)},
                new Client(){ClientId=2,FirstName="Super",LastName="Pharm",CreditScore=800,AssignDate=new DateTime(2022,1,1)}
            };

            entity.HasData(clients);
        }

        internal static void HasData(EntityTypeBuilder<ClientsAccount> entity)
        {
            var cas = new ClientsAccount[] {
                new ClientsAccount(){Id=1,ClientId=1,AccountId=1},
                new ClientsAccount(){Id=2,ClientId=2,AccountId=2},
            };

            entity.HasData(cas);
        }

        internal static void HasData(EntityTypeBuilder<CreditCard> entity)
        {
            var cards = new CreditCard[] { 
                new CreditCard(){CreditCardNumber="0000111122223333",ClientId=-1,Credit=-1,UsedCredit=0,IsCanceled=false,AccountId=null,IsRecievingOnly=false,Club=null},
                new CreditCard(){CreditCardNumber="3755123456789012",ClientId=2,Credit=1000000,UsedCredit=0,IsCanceled=false,AccountId=2,IsRecievingOnly=false,Club="Black Centurion"},
                new CreditCard(){CreditCardNumber="4580123456789012",ClientId=1,Credit=10000,UsedCredit=0,IsCanceled=false,AccountId=1,IsRecievingOnly=false,Club="Default"},
                new CreditCard(){CreditCardNumber="4023356041624013",ClientId=1,Credit=1500,UsedCredit=0,IsCanceled=true,AccountId=1,IsRecievingOnly=true,Club="הכללי"}
            };

            entity.HasData(cards);
        }

        internal static void HasData(EntityTypeBuilder<Manager> entity)
        {
            var managers = new Manager[] { 
                new Manager(){ManagerId=1, ManagerName="Avichay"}
            };

            entity.HasData(managers);
        }

        internal static void HasData(EntityTypeBuilder<Message> entity)
        {
            var messages = new Message[] {
                new Message(){MessageId=1,ManagerSenderId=1,ClientRecieverId=1,MessageTitle="Card Issued",MessageContent="Your card has been issued succefully, with the club \"Default\", number ending with 9012",IsViewed=true},
                new Message(){MessageId=2,ManagerSenderId=1,ClientRecieverId=2,MessageTitle="Card Issued",MessageContent="Your card has been issued succefully, with the club \"Default\", number ending with 9012",IsViewed=false},
                new Message(){MessageId=3,ManagerSenderId=1,ClientRecieverId=1,MessageTitle="Thanks for joining",MessageContent="Thank you for joining us",IsViewed=true}
            };

            entity.HasData(messages);
        }

        internal static void HasData(EntityTypeBuilder<RequestsFromClient> entity)
        {
            var rfcs = new RequestsFromClient[] {
                new RequestsFromClient(){RequestId=1,ClientId=1,Title="New Card",Content="I want a card with the \"Default\" club",HasBeenViewd=true,Answered=true,Date=new DateTime(2022,1,1) },
                new RequestsFromClient(){RequestId=2,ClientId=2,Title="New Card",Content="I want a card with \"Default\" club",HasBeenViewd=true,Answered=true,Date=new DateTime(2022,1,1)},
                new RequestsFromClient(){RequestId=28,ClientId=1,Title="*Immidiate* Block Credit Card.",Content="",HasBeenViewd=true,Answered=true,Date=new DateTime(2022,2,21,16,59,4,157)},
                new RequestsFromClient(){RequestId=30,ClientId=1,Title="Denial of transaction.",Content="I wish to deny the transaction number: 4\n"+
"which been done at 10/02/2022 00:00:00\n"+
"at business: SuperPharm",HasBeenViewd=true,Answered=true,Date=new DateTime(2022,2,21,16,59,43,423)}
            };

            entity.HasData(rfcs);
        }

        internal static void HasData(EntityTypeBuilder<User> entity)
        {
            var users = new User[] {
                new User(){UserId=1,UserName="Avichay",UserPassword="123456",IsManager=true,IfManagerId=1,IfClientId=1},
                new User(){UserId=2,UserName="Super-Pharm",UserPassword="1234567",IsManager=false,IfManagerId=null,IfClientId=2}
            };

            entity.HasData(users);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CreditCompanyEF.Models
{
    public partial class CreditCompanyContext : DbContext
    {
        static List<CreditCompanyContext> list = new List<CreditCompanyContext>();
        public CreditCompanyContext()
        {
            list.Add(this);
        }

        public CreditCompanyContext(DbContextOptions<CreditCompanyContext> options)
            : base(options)
        {
            list.Add(this);
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientsAccount> ClientsAccounts { get; set; }
        public virtual DbSet<ClientsInfo> ClientsInfos { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<NumberOfCardsView> NumberOfCardsViews { get; set; }
        public virtual DbSet<RequestsFromClient> RequestsFromClients { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//#warning Change the catalog to CreditCompany!!
//Not so important actually
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=CreditCompany2;Integrated Security=True");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");
            
            modelBuilder.Entity<Bank>(entity =>
            {
                Creator.HasData(entity);
                entity.HasKey(e => e.BankNumber)
                    .HasName("PK_Table_1");

                entity.HasIndex(e => e.BankName, "IX_Table_1")
                    .IsUnique();

                entity.Property(e => e.BankNumber).ValueGeneratedNever();

                entity.Property(e => e.BankName).HasMaxLength(50);
            });
            modelBuilder.Entity<Branch>(entity =>
            {
                Creator.HasData(entity);
                entity.HasKey(e => e.BranchNumber);

                entity.Property(e => e.BranchNumber).ValueGeneratedNever();

                entity.Property(e => e.BranchName).HasMaxLength(50);

                entity.HasOne(d => d.BankNumberNavigation)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.BankNumber)
                    .HasConstraintName("FK_Branches_Table_1");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                Creator.HasData(entity);
                entity.HasKey(e => e.UniqueAccountId);

                entity.HasOne(d => d.BranchNumberNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.BranchNumber)
                    .HasConstraintName("FK_Accounts_Branches");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                Creator.HasData(entity);
                entity.Property(e => e.AssignDate).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<ClientsAccount>(entity =>
            {
                Creator.HasData(entity);
                entity.ToTable("Clients_Accounts");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ClientsAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Clients_Accounts_Accounts");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientsAccounts)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Clients_Accounts_Clients");
            });

            modelBuilder.Entity<ClientsInfo>(entity =>
            {
                //Creator.HasData(entity);
                entity.HasNoKey();

                entity.ToView("ClientsInfo");

                entity.Property(e => e.MainCardLastDigits)
                    .HasMaxLength(4)
                    .HasColumnName("Main Card Last Digits");

                entity.Property(e => e.Name).HasMaxLength(101);

                entity.Property(e => e.NumberOfCards).HasColumnName("Number Of Cards");

                entity.Property(e => e.TotalCredit).HasColumnName("Total credit");

                entity.Property(e => e.TotalUsedCredit).HasColumnName("Total Used Credit");
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                Creator.HasData(entity);
                entity.HasKey(e => e.CreditCardNumber);

                entity.Property(e => e.CreditCardNumber).HasMaxLength(50);

                entity.Property(e => e.Club).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.CreditCards)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_CreditCards_Accounts");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.CreditCards)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_CreditCards_Clients");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                Creator.HasData(entity);
                entity.Property(e => e.ManagerName)
                    .HasMaxLength(50)
                    .HasColumnName("Manager_Name");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                Creator.HasData(entity);
                entity.Property(e => e.ClientRecieverId).HasColumnName("Client_RecieverId");

                entity.Property(e => e.ManagerSenderId).HasColumnName("Manager_SenderId");

                entity.Property(e => e.MessageTitle).HasMaxLength(50);

                entity.HasOne(d => d.ClientReciever)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ClientRecieverId)
                    .HasConstraintName("FK_Messages_Clients");

                entity.HasOne(d => d.ManagerSender)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ManagerSenderId)
                    .HasConstraintName("FK_Messages_Managers");
            });

            modelBuilder.Entity<NumberOfCardsView>(entity =>
            {
                //Creator.HasData(entity);
                entity.HasNoKey();

                entity.ToView("NumberOfCards_View");

                entity.Property(e => e.NumberOfCards).HasColumnName("Number Of Cards");
            });

            modelBuilder.Entity<RequestsFromClient>(entity =>
            {
                Creator.HasData(entity);
                entity.HasKey(e => e.RequestId)
                    .HasName("PK_ClientsRequests");

                entity.ToTable("Requests_From_Clients");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.RequestsFromClients)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_ClientsRequests_Clients");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                //Creator.HasData(entity);
                entity.Property(e => e.Business).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.PayerCardNumber).HasMaxLength(50);

                entity.HasOne(d => d.DenyRequest)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.DenyRequestId)
                    .HasConstraintName("FK_Transactions_Requests_From_Clients");

                entity.HasOne(d => d.PayerCardNumberNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.PayerCardNumber)
                    .HasConstraintName("FK_Transactions_Cards_payer");

                entity.HasOne(d => d.ReciverClient)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.ReciverClientId)
                    .HasConstraintName("FK_Transactions_Clients_reciver");
            });

            modelBuilder.Entity<User>(entity =>
            {
                Creator.HasData(entity);
                entity.Property(e => e.IfClientId).HasColumnName("If_Client_Id");

                entity.Property(e => e.IfManagerId).HasColumnName("If_Manager_Id");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserPassword).HasMaxLength(50);

                entity.HasOne(d => d.IfClient)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IfClientId)
                    .HasConstraintName("FK_Users_Clients1");

                entity.HasOne(d => d.IfManager)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IfManagerId)
                    .HasConstraintName("FK_Users_Clients");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

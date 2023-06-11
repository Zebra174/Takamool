using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class LawerDataContext : DbContext
{
    public LawerDataContext()
    {
    }

    public LawerDataContext(DbContextOptions<LawerDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BillingGroup> BillingGroups { get; set; }

    public virtual DbSet<BillingRate> BillingRates { get; set; }

    public virtual DbSet<ClientCare> ClientCares { get; set; }

    public virtual DbSet<ClientMngt> ClientMngts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExpenseMatter> ExpenseMatters { get; set; }

    public virtual DbSet<ExternalSession> ExternalSessions { get; set; }

    public virtual DbSet<Fee> Fees { get; set; }

    public virtual DbSet<FeeMatter> FeeMatters { get; set; }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<FormField> FormFields { get; set; }

    public virtual DbSet<FormFieldMatter> FormFieldMatters { get; set; }

    public virtual DbSet<Htmlfile> Htmlfiles { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceExpense> InvoiceExpenses { get; set; }

    public virtual DbSet<InvoiceFee> InvoiceFees { get; set; }

    public virtual DbSet<InvoiceTime> InvoiceTimes { get; set; }

    public virtual DbSet<Isuue> Isuues { get; set; }

    public virtual DbSet<IsuuesAgency> IsuuesAgencies { get; set; }

    public virtual DbSet<IsuuesDatum> IsuuesData { get; set; }

    public virtual DbSet<IsuuesLokupTable> IsuuesLokupTables { get; set; }

    public virtual DbSet<IsuuesRecord> IsuuesRecords { get; set; }

    public virtual DbSet<IsuuesSession> IsuuesSessions { get; set; }

    public virtual DbSet<MatterType> MatterTypes { get; set; }

    public virtual DbSet<Name> Names { get; set; }

    public virtual DbSet<NoteNotification> NoteNotifications { get; set; }

    public virtual DbSet<TaskTemplate> TaskTemplates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BillingGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("billing_group");

            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.BillToContactId).HasColumnName("bill_to_contact_id");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LastRun)
                .HasColumnType("datetime")
                .HasColumnName("last_run");
            entity.Property(e => e.NextRun)
                .HasColumnType("datetime")
                .HasColumnName("next_run");
            entity.Property(e => e.Title)
                .HasColumnType("text")
                .HasColumnName("title");
        });

        modelBuilder.Entity<BillingRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("billing_rates_pkey");

            entity.ToTable("billing_rate");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.PricePerUnit)
                .HasColumnType("money")
                .HasColumnName("price_per_unit");
            entity.Property(e => e.Title)
                .HasColumnType("text")
                .HasColumnName("title");
        });

        modelBuilder.Entity<ClientCare>(entity =>
        {
            entity.HasKey(e => e.EocId);

            entity.ToTable("Client_Care");

            entity.Property(e => e.EocId).HasColumnName("EOC_ID");
            entity.Property(e => e.CaseManager)
                .HasMaxLength(50)
                .HasColumnName("Case_Manager");
            entity.Property(e => e.Caseload)
                .HasMaxLength(50)
                .HasColumnName("CASELOAD");
            entity.Property(e => e.ClientStatus)
                .HasMaxLength(50)
                .HasColumnName("Client_Status");
            entity.Property(e => e.ClientType)
                .HasMaxLength(50)
                .HasColumnName("Client_Type");
            entity.Property(e => e.DependencyStatusBeginning).HasMaxLength(50);
            entity.Property(e => e.DependencyStatusEnd).HasMaxLength(50);
            entity.Property(e => e.DischargeDate)
                .HasColumnType("datetime")
                .HasColumnName("Discharge_Date");
            entity.Property(e => e.DisciplineIntake)
                .HasMaxLength(50)
                .HasColumnName("DISCIPLINE_INTAKE");
            entity.Property(e => e.Facility)
                .HasMaxLength(50)
                .HasColumnName("FACILITY");
            entity.Property(e => e.FirstDateOfEpisode)
                .HasColumnType("datetime")
                .HasColumnName("First_Date_of_Episode");
            entity.Property(e => e.IntakeId).HasColumnName("INTAKE_ID");
            entity.Property(e => e.NameId).HasColumnName("NAME_ID");
            entity.Property(e => e.NatureOfCare)
                .HasMaxLength(50)
                .HasColumnName("Nature_of_Care");
            entity.Property(e => e.Operation)
                .HasMaxLength(50)
                .HasColumnName("OPERATION");
            entity.Property(e => e.OperationCost)
                .HasColumnType("money")
                .HasColumnName("OPERATION_COST");
            entity.Property(e => e.OverallEocStatus)
                .HasMaxLength(10)
                .HasColumnName("OVERALL_EOC_STATUS");
            entity.Property(e => e.SubIntakeNumber).HasColumnName("Sub_Intake_Number");
        });

        modelBuilder.Entity<ClientMngt>(entity =>
        {
            entity.HasKey(e => e.CmId);

            entity.ToTable("Client_Mngt");

            entity.Property(e => e.CmId).HasColumnName("CM_ID");
            entity.Property(e => e.CaseManager)
                .HasMaxLength(4)
                .HasColumnName("Case_Manager");
            entity.Property(e => e.ClientStatus)
                .HasMaxLength(50)
                .HasColumnName("Client_Status");
            entity.Property(e => e.DischargeDate)
                .HasColumnType("datetime")
                .HasColumnName("Discharge_Date");
            entity.Property(e => e.Discipline).HasMaxLength(50);
            entity.Property(e => e.EocId).HasColumnName("EOC_ID");
            entity.Property(e => e.Facility)
                .HasMaxLength(50)
                .HasColumnName("FACILITY");
            entity.Property(e => e.FirstDateOfContact)
                .HasColumnType("datetime")
                .HasColumnName("First_Date_of_Contact");
            entity.Property(e => e.FirstDateOfEpisode)
                .HasColumnType("datetime")
                .HasColumnName("First_Date_of_Episode");
            entity.Property(e => e.FundSource)
                .HasMaxLength(100)
                .HasColumnName("FUND_SOURCE");
            entity.Property(e => e.Operation)
                .HasMaxLength(50)
                .HasColumnName("OPERATION");
            entity.Property(e => e.OperationCost)
                .HasColumnType("money")
                .HasColumnName("OPERATION_COST");
            entity.Property(e => e.PhaseCare)
                .HasMaxLength(100)
                .HasColumnName("PHASE_CARE");
            entity.Property(e => e.Research1)
                .HasMaxLength(50)
                .HasColumnName("Research_1");
            entity.Property(e => e.Research2)
                .HasMaxLength(50)
                .HasColumnName("Research_2");
            entity.Property(e => e.Research3)
                .HasMaxLength(50)
                .HasColumnName("Research_3");
            entity.Property(e => e.WhyReferred)
                .HasMaxLength(100)
                .HasColumnName("Why_referred");
            entity.Property(e => e.WorkerNumber).HasColumnName("Worker_Number");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            

            entity.Property(e => e.CustAddress)
                .HasMaxLength(250)
                .HasColumnName("Cust_Address");
            entity.Property(e => e.CustCity)
                .HasMaxLength(50)
                .HasColumnName("Cust_City");
            entity.Property(e => e.CustEmail)
                .HasMaxLength(200)
                .HasColumnName("Cust_Email");
            entity.Property(e => e.CustId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Cust_Id");
            entity.Property(e => e.CustIdNumber)
                .HasMaxLength(25)
                .HasColumnName("Cust_IdNumber");
            entity.Property(e => e.CustMobile)
                .HasMaxLength(200)
                .HasColumnName("Cust_Mobile");
            entity.Property(e => e.CustName)
                .HasMaxLength(150)
                .HasColumnName("Cust_Name");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("expense_pkey");

            entity.ToTable("expense");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.Details)
                .HasColumnType("text")
                .HasColumnName("details");
            entity.Property(e => e.Incurred)
                .HasColumnType("datetime")
                .HasColumnName("incurred");
            entity.Property(e => e.Paid)
                .HasColumnType("datetime")
                .HasColumnName("paid");
            entity.Property(e => e.Vendor)
                .HasColumnType("text")
                .HasColumnName("vendor");
        });

        modelBuilder.Entity<ExpenseMatter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("expense_matter_pkey");

            entity.ToTable("expense_matter");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ExpenseId).HasColumnName("expense_id");
            entity.Property(e => e.MatterId).HasColumnName("matter_id");

            entity.HasOne(d => d.Expense).WithMany(p => p.ExpenseMatters)
                .HasForeignKey(d => d.ExpenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_expense_matter_ExpenseId");
        });

        modelBuilder.Entity<ExternalSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("external_session_pkey");

            entity.ToTable("external_session");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AppName)
                .HasColumnType("text")
                .HasColumnName("app_name");
            entity.Property(e => e.MachineId).HasColumnName("machine_id");
            entity.Property(e => e.Timeout).HasColumnName("timeout");
            entity.Property(e => e.UserPid).HasColumnName("user_pid");
            entity.Property(e => e.UtcCreated)
                .HasColumnType("datetime")
                .HasColumnName("utc_created");
            entity.Property(e => e.UtcExpires)
                .HasColumnType("datetime")
                .HasColumnName("utc_expires");
        });

        modelBuilder.Entity<Fee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fee_pkey");

            entity.ToTable("fee");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.Details)
                .HasColumnType("text")
                .HasColumnName("details");
            entity.Property(e => e.Incurred)
                .HasColumnType("datetime")
                .HasColumnName("incurred");
        });

        modelBuilder.Entity<FeeMatter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fee_matter_pkey");

            entity.ToTable("fee_matter");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FeeId).HasColumnName("fee_id");
            entity.Property(e => e.MatterId).HasColumnName("matter_id");
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("form_pkey");

            entity.ToTable("form");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.MatterTypeId).HasColumnName("matter_type_id");
            entity.Property(e => e.Path)
                .HasColumnType("text")
                .HasColumnName("path");
            entity.Property(e => e.Title)
                .HasColumnType("text")
                .HasColumnName("title");
        });

        modelBuilder.Entity<FormField>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("form_field_PK");

            entity.ToTable("form_field");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasColumnType("text")
                .HasColumnName("title");
        });

        modelBuilder.Entity<FormFieldMatter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("form_field_matter_PK");

            entity.ToTable("form_field_matter");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FormFieldId).HasColumnName("form_field_id");
            entity.Property(e => e.MatterId).HasColumnName("matter_id");
        });

        modelBuilder.Entity<Htmlfile>(entity =>
        {
            entity.HasKey(e => e.TextId).HasName("PK__htmlfile__4F63CC2CC367CC44");

            entity.ToTable("htmlfiles");

            entity.Property(e => e.TextId).HasColumnName("Text_id");
            entity.Property(e => e.CustId).HasColumnName("Cust_Id");
            entity.Property(e => e.TextHtml)
                .HasColumnType("ntext")
                .HasColumnName("Text_Html");
            entity.Property(e => e.TextLawId).HasColumnName("Text_Law_Id");
            entity.Property(e => e.TextName)
                .HasMaxLength(255)
                .HasColumnName("Text_name");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("invoice_pkey");

            entity.ToTable("invoice");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BillToContactId).HasColumnName("bill_to_contact_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Due)
                .HasColumnType("datetime")
                .HasColumnName("due");
            entity.Property(e => e.Subtotal)
                .HasColumnType("money")
                .HasColumnName("subtotal");
            entity.Property(e => e.TaxAmount)
                .HasColumnType("money")
                .HasColumnName("tax_amount");
            entity.Property(e => e.Total)
                .HasColumnType("money")
                .HasColumnName("total");
        });

        modelBuilder.Entity<InvoiceExpense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("invoice_expense_pkey");

            entity.ToTable("invoice_expense");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.Details)
                .HasColumnType("text")
                .HasColumnName("details");
            entity.Property(e => e.ExpenseId).HasColumnName("expense_id");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
        });

        modelBuilder.Entity<InvoiceFee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("invoice_fee_pkey");

            entity.ToTable("invoice_fee");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.Details)
                .HasColumnType("text")
                .HasColumnName("details");
            entity.Property(e => e.FeeId).HasColumnName("fee_id");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.TaxAmount)
                .HasColumnType("money")
                .HasColumnName("tax_amount");

            entity.HasOne(d => d.Fee).WithMany(p => p.InvoiceFees)
                .HasForeignKey(d => d.FeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoice_fee_fee_FeeId");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceFees)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoice_fee_invoice_InvoiceId");
        });

        modelBuilder.Entity<InvoiceTime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("invoice_time_pkey");

            entity.ToTable("invoice_time");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Details)
                .HasColumnType("text")
                .HasColumnName("details");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.PricePerUnit)
                .HasColumnType("money")
                .HasColumnName("price_per_unit");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("((1))")
                .HasColumnType("numeric(10, 4)")
                .HasColumnName("quantity");
            entity.Property(e => e.TimeId).HasColumnName("time_id");
        });

        modelBuilder.Entity<Isuue>(entity =>
        {
           

            entity.Property(e => e.AgnName).HasMaxLength(200);
            entity.Property(e => e.Agnaddress).HasMaxLength(200);
            entity.Property(e => e.Agnphone).HasMaxLength(200);
            entity.Property(e => e.ContractNumber)
                .HasMaxLength(255)
                .HasColumnName("contractNumber");
            entity.Property(e => e.ContractType).HasColumnName("contractType");
            entity.Property(e => e.IsseName).HasMaxLength(200);
            entity.Property(e => e.IsuueDetail).HasColumnType("text");
            entity.Property(e => e.IsuueId)
                .ValueGeneratedOnAdd()
                .HasColumnName("IsuueID");
            entity.Property(e => e.IsuueOpenDate).HasColumnType("datetime");
            entity.Property(e => e.IsuueSubject).HasMaxLength(255);
            entity.Property(e => e.IsuueSummary).HasMaxLength(255);
            entity.Property(e => e.Isuuenumber)
                .HasMaxLength(25)
                .HasColumnName("isuuenumber");
            entity.Property(e => e.LowerName).HasMaxLength(200);
        });

        modelBuilder.Entity<IsuuesAgency>(entity =>
        {
            entity
                
                .ToTable("Isuues_Agencies");

            entity.Property(e => e.AgenceDate).HasColumnType("datetime");
            entity.Property(e => e.AgenceFromDate).HasColumnType("datetime");
            entity.Property(e => e.AgenceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("AgenceID");
            entity.Property(e => e.AgenceName).HasMaxLength(255);
            entity.Property(e => e.AgenceNote).HasMaxLength(255);
            entity.Property(e => e.AgencePic).HasMaxLength(255);
            entity.Property(e => e.AgenceTo).HasColumnType("datetime");
            entity.Property(e => e.IsuueNumber)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IsuuesDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Isuues_Data");

            entity.Property(e => e.AssessorName).HasMaxLength(255);
            entity.Property(e => e.CoureName).HasMaxLength(255);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsuueNumber).HasMaxLength(255);
        });

        modelBuilder.Entity<IsuuesLokupTable>(entity =>
        {
            entity.HasKey(e => new { e.LokupType, e.LokupId }).HasName("PK_LokupTable");

            entity.ToTable("Isuues_LokupTable");

            entity.Property(e => e.LokupValue).HasMaxLength(255);
        });

        modelBuilder.Entity<IsuuesRecord>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Isuues_Record");

            entity.Property(e => e.IsuueNumber)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.RecordDate).HasColumnType("datetime");
            entity.Property(e => e.RecordEmp)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RecordId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<IsuuesSession>(entity =>
        {
            entity
                
                .ToTable("Isuues_Session");

            entity.Property(e => e.AisuueNumber).HasColumnName("AIsuueNumber");
            entity.Property(e => e.SessionDate).HasColumnType("datetime");
            entity.Property(e => e.SessionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SessionID");
            entity.Property(e => e.SessionName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SessionNextDate).HasColumnType("datetime");
            entity.Property(e => e.SessionNextName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SessionNote)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MatterType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("matter_type_pkey");

            entity.ToTable("matter_type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnType("text")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Name>(entity =>
        {
            entity.Property(e => e.NameId).HasColumnName("NAME_ID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.ContactPhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("Contact_Phone_number");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("Date_of_birth");
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(50)
                .HasColumnName("Home_phone");
            entity.Property(e => e.InterpretorNeeded).HasColumnName("Interpretor_needed");
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Sex).HasMaxLength(7);
            entity.Property(e => e.Suburb).HasMaxLength(50);
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.WorkerId).HasColumnName("WORKER_ID");
            entity.Property(e => e.WorkerType)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Worker_Type");
            entity.Property(e => e.WorkerTypeId).HasColumnName("Worker_Type_ID");
        });

        modelBuilder.Entity<NoteNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("note_notification_pkey");

            entity.ToTable("note_notification");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.NoteId).HasColumnName("note_id");
        });

        modelBuilder.Entity<TaskTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("task_template_pkey");

            entity.ToTable("task_template");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.ActualEnd)
                .HasColumnType("text")
                .HasColumnName("actual_end");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DueDate)
                .HasColumnType("text")
                .HasColumnName("due_date");
            entity.Property(e => e.ProjectedEnd)
                .HasColumnType("text")
                .HasColumnName("projected_end");
            entity.Property(e => e.ProjectedStart)
                .HasColumnType("text")
                .HasColumnName("projected_start");
            entity.Property(e => e.TaskTemplateTitle)
                .HasColumnType("text")
                .HasColumnName("task_template_title");
            entity.Property(e => e.Title)
                .HasColumnType("text")
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

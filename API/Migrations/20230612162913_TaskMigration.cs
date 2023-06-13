using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class TaskMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "billing_group",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    last_run = table.Column<DateTime>(type: "datetime", nullable: true),
                    next_run = table.Column<DateTime>(type: "datetime", nullable: true),
                    amount = table.Column<decimal>(type: "money", nullable: false),
                    bill_to_contact_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "billing_rate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    price_per_unit = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("billing_rates_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Client_Care",
                columns: table => new
                {
                    EOC_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INTAKE_ID = table.Column<long>(type: "bigint", nullable: true),
                    Sub_Intake_Number = table.Column<long>(type: "bigint", nullable: true),
                    NAME_ID = table.Column<long>(type: "bigint", nullable: true),
                    First_Date_of_Episode = table.Column<DateTime>(type: "datetime", nullable: false),
                    Case_Manager = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Client_Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DependencyStatusBeginning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DependencyStatusEnd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nature_of_Care = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Discharge_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Client_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CASELOAD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OVERALL_EOC_STATUS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FACILITY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DISCIPLINE_INTAKE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OPERATION_COST = table.Column<decimal>(type: "money", nullable: true),
                    OPERATION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Care", x => x.EOC_ID);
                });

            migrationBuilder.CreateTable(
                name: "Client_Mngt",
                columns: table => new
                {
                    CM_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EOC_ID = table.Column<long>(type: "bigint", nullable: true),
                    First_Date_of_Episode = table.Column<DateTime>(type: "datetime", nullable: true),
                    First_Date_of_Contact = table.Column<DateTime>(type: "datetime", nullable: true),
                    Discipline = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Worker_Number = table.Column<int>(type: "int", nullable: true),
                    Case_Manager = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Why_referred = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Discharge_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Client_Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Research_1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Research_2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Research_3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FACILITY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PHASE_CARE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FUND_SOURCE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OPERATION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OPERATION_COST = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Mngt", x => x.CM_ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Cust_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cust_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cust_Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Cust_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cust_IdNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Cust_Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cust_Mobile = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Cust_Id);
                });

            migrationBuilder.CreateTable(
                name: "expense",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    incurred = table.Column<DateTime>(type: "datetime", nullable: false),
                    paid = table.Column<DateTime>(type: "datetime", nullable: true),
                    vendor = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<decimal>(type: "money", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("expense_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "external_session",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    user_pid = table.Column<int>(type: "int", nullable: false),
                    app_name = table.Column<string>(type: "text", nullable: false),
                    machine_id = table.Column<int>(type: "int", nullable: false),
                    utc_created = table.Column<DateTime>(type: "datetime", nullable: false),
                    utc_expires = table.Column<DateTime>(type: "datetime", nullable: false),
                    timeout = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("external_session_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    incurred = table.Column<DateTime>(type: "datetime", nullable: false),
                    amount = table.Column<decimal>(type: "money", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("fee_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fee_matter",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    matter_id = table.Column<int>(type: "int", nullable: false),
                    fee_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("fee_matter_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "form",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    matter_type_id = table.Column<int>(type: "int", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("form_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "form_field",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("form_field_PK", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "form_field_matter",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    matter_id = table.Column<int>(type: "int", nullable: false),
                    form_field_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("form_field_matter_PK", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "htmlfiles",
                columns: table => new
                {
                    Text_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text_Law_Id = table.Column<int>(type: "int", nullable: true),
                    Text_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Text_Html = table.Column<string>(type: "ntext", nullable: true),
                    Cust_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__htmlfile__4F63CC2CC367CC44", x => x.Text_id);
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    bill_to_contact_id = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    due = table.Column<DateTime>(type: "datetime", nullable: false),
                    subtotal = table.Column<decimal>(type: "money", nullable: false),
                    tax_amount = table.Column<decimal>(type: "money", nullable: false),
                    total = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "invoice_expense",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    invoice_id = table.Column<int>(type: "int", nullable: false),
                    expense_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "money", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_expense_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "invoice_time",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    invoice_id = table.Column<int>(type: "int", nullable: false),
                    time_id = table.Column<int>(type: "int", nullable: false),
                    price_per_unit = table.Column<decimal>(type: "money", nullable: false),
                    quantity = table.Column<decimal>(type: "numeric(10,4)", nullable: false, defaultValueSql: "((1))"),
                    details = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_time_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Isuues",
                columns: table => new
                {
                    IsuueID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    IsuueType = table.Column<int>(type: "int", nullable: true),
                    IsuueStatus = table.Column<int>(type: "int", nullable: true),
                    IsuueSubject = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CustomerType = table.Column<int>(type: "int", nullable: true),
                    IsuueOpenDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsuueSummary = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsuueDetail = table.Column<string>(type: "text", nullable: true),
                    contractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    contractType = table.Column<int>(type: "int", nullable: true),
                    LowerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    isuuenumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AgnName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Agnphone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Agnaddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsseName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isuues", x => x.IsuueID);
                });

            migrationBuilder.CreateTable(
                name: "Isuues_Agencies",
                columns: table => new
                {
                    AgenceID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgenceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AgenceName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AgenceNote = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AgenceType = table.Column<int>(type: "int", nullable: true),
                    AgenceFromDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AgenceTo = table.Column<DateTime>(type: "datetime", nullable: true),
                    AgencePic = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsuueNumber = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    AgenceNo = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isuues_Agencies", x => x.AgenceID);
                });

            migrationBuilder.CreateTable(
                name: "Isuues_Data",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: true),
                    IsuueNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CoureName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AssessorName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Lawer1 = table.Column<int>(type: "int", nullable: true),
                    Lawer2 = table.Column<int>(type: "int", nullable: true),
                    Lawer3 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Isuues_LokupTable",
                columns: table => new
                {
                    LokupType = table.Column<int>(type: "int", nullable: false),
                    LokupId = table.Column<int>(type: "int", nullable: false),
                    LokupValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LokupTable", x => new { x.LokupType, x.LokupId });
                });

            migrationBuilder.CreateTable(
                name: "Isuues_Record",
                columns: table => new
                {
                    RecordId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsuueNumber = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: true),
                    RecordEmp = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    RecordDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Isuues_Session",
                columns: table => new
                {
                    SessionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SessionName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    SessionNote = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    SessionNextDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SessionNextName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CustomerInv = table.Column<int>(type: "int", nullable: true),
                    AIsuueNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isuues_Session", x => x.SessionID);
                });

            migrationBuilder.CreateTable(
                name: "matter_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("matter_type_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Names",
                columns: table => new
                {
                    NAME_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date_of_birth = table.Column<DateTime>(type: "datetime", nullable: true),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Home_phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Contact_Phone_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Language = table.Column<int>(type: "int", nullable: true),
                    Interpretor_needed = table.Column<bool>(type: "bit", nullable: true),
                    WORKER_ID = table.Column<long>(type: "bigint", nullable: true),
                    Worker_Type_ID = table.Column<long>(type: "bigint", nullable: true),
                    Worker_Type = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Names", x => x.NAME_ID);
                });

            migrationBuilder.CreateTable(
                name: "note_notification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    contact_id = table.Column<int>(type: "int", nullable: false),
                    note_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("note_notification_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task_template",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    task_template_title = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    projected_start = table.Column<string>(type: "text", nullable: true),
                    due_date = table.Column<string>(type: "text", nullable: true),
                    actual_end = table.Column<string>(type: "text", nullable: true),
                    projected_end = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("task_template_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "expense_matter",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    matter_id = table.Column<int>(type: "int", nullable: false),
                    expense_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("expense_matter_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_expense_matter_ExpenseId",
                        column: x => x.expense_id,
                        principalTable: "expense",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "invoice_fee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    invoice_id = table.Column<int>(type: "int", nullable: false),
                    fee_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "money", nullable: false),
                    tax_amount = table.Column<decimal>(type: "money", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_fee_pkey", x => x.id);
                    table.ForeignKey(
                        name: "invoice_fee_fee_FeeId",
                        column: x => x.fee_id,
                        principalTable: "fee",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "invoice_fee_invoice_InvoiceId",
                        column: x => x.invoice_id,
                        principalTable: "invoice",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_expense_matter_expense_id",
                table: "expense_matter",
                column: "expense_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_fee_fee_id",
                table: "invoice_fee",
                column: "fee_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_fee_invoice_id",
                table: "invoice_fee",
                column: "invoice_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "billing_group");

            migrationBuilder.DropTable(
                name: "billing_rate");

            migrationBuilder.DropTable(
                name: "Client_Care");

            migrationBuilder.DropTable(
                name: "Client_Mngt");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "expense_matter");

            migrationBuilder.DropTable(
                name: "external_session");

            migrationBuilder.DropTable(
                name: "fee_matter");

            migrationBuilder.DropTable(
                name: "form");

            migrationBuilder.DropTable(
                name: "form_field");

            migrationBuilder.DropTable(
                name: "form_field_matter");

            migrationBuilder.DropTable(
                name: "htmlfiles");

            migrationBuilder.DropTable(
                name: "invoice_expense");

            migrationBuilder.DropTable(
                name: "invoice_fee");

            migrationBuilder.DropTable(
                name: "invoice_time");

            migrationBuilder.DropTable(
                name: "Isuues");

            migrationBuilder.DropTable(
                name: "Isuues_Agencies");

            migrationBuilder.DropTable(
                name: "Isuues_Data");

            migrationBuilder.DropTable(
                name: "Isuues_LokupTable");

            migrationBuilder.DropTable(
                name: "Isuues_Record");

            migrationBuilder.DropTable(
                name: "Isuues_Session");

            migrationBuilder.DropTable(
                name: "matter_type");

            migrationBuilder.DropTable(
                name: "Names");

            migrationBuilder.DropTable(
                name: "note_notification");

            migrationBuilder.DropTable(
                name: "task_template");

            migrationBuilder.DropTable(
                name: "expense");

            migrationBuilder.DropTable(
                name: "fee");

            migrationBuilder.DropTable(
                name: "invoice");
        }
    }
}

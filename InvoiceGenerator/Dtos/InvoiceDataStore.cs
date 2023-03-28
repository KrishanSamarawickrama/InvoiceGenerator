namespace InvoiceGenerator.Dtos;

public class InvoiceDataStore
{
    public LastInvoice? LastInvoice { get; set; }
    public InvoiceData? InvoiceData { get; set; }
}

public class LastInvoice
{
    public string InvoiceNumberPrefix { get; set; } = "INV";
    public int LastInvoiceNumber { get; set; } = 1;
}

public class InvoiceData
{
    public string? InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; } = DateTime.Now;
    public string? MailInfo { get; set; }
    public string? BillTo { get; set; }
    public string? LineDescription { get; set; }
    public string? Amount { get; set; }
}
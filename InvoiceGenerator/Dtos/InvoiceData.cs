namespace InvoiceGenerator.Dtos;

public class GenerateInvoiceDto
{
    public DateTime? InvoiceDate { get; set; }
    public string? MailInfo { get; set; }
    public string? BillTo { get; set; }
    public string? LineDescription { get; set; }
    public string? Amount { get; set; }
}
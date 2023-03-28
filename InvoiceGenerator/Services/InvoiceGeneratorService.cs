using InvoiceGenerator.Dtos;
using iTextSharp.text.pdf;
using PdfTemplate = InvoiceGenerator.Helper.PdfTemplate;

namespace InvoiceGenerator.Services;

public sealed class InvoiceGeneratorService
{
    private readonly InvoiceDataService _dataService;

    public InvoiceGeneratorService(InvoiceDataService dataService)
    {
        _dataService = dataService;
    }
    
    public byte[] GeneratePdf(InvoiceData data)
    {
        data.InvoiceNumber =  _dataService.GetInvoiceNumber(data);
        
        var template = LoadInvoiceTemplate();
        var pdfData = GeneratePdfFromTemplate(template, data);
        return pdfData;
    }

    private PdfTemplate LoadInvoiceTemplate()
    {
        var templatePath = "invoice_template.pdf";
        var reader = new PdfReader(templatePath);
        
        var page = reader.GetPageN(1);
        var template = PdfTemplate.CreateTemplate(reader);

        var formFields = reader.AcroFields;
        template.FormFields = formFields;
        template.Fields = formFields.Fields;

        return template;
    }

    private byte[] GeneratePdfFromTemplate(PdfTemplate template, InvoiceData data)
    {
        var stream = new MemoryStream();

        var stamper = new PdfStamper(template.Reader, stream);

        stamper.AcroFields.SetField("Text1", data.InvoiceNumber);
        stamper.AcroFields.SetField("Text3", data.InvoiceDate.ToShortDateString());
        stamper.AcroFields.SetField("Text4", data.MailInfo);
        stamper.AcroFields.SetField("Text5", data.BillTo);
        stamper.AcroFields.SetField("Text6", data.LineDescription);
        stamper.AcroFields.SetField("Text7", $"$ {data.Amount}");
        stamper.AcroFields.SetField("Text8", $"$ {data.Amount}");
        stamper.AcroFields.SetField("Text9", $"$ {data.Amount}");

        stamper.FormFlattening = true;

        stamper.Close();

        return stream.ToArray();
    }
}
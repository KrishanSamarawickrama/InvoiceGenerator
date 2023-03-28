using iTextSharp.text.pdf;

namespace InvoiceGenerator.Helper;

public class PdfTemplate
{
    public PdfReader? Reader { get; set; }
    public AcroFields? FormFields { get; set; }
    public IDictionary<string, AcroFields.Item>? Fields { get; set; }

    public static PdfTemplate CreateTemplate(PdfReader reader)
    {
        var template = new PdfTemplate { Reader = reader };
        var formFields = reader.AcroFields;
        template.FormFields = formFields;
        template.Fields = formFields.Fields;
        return template;
    }
}

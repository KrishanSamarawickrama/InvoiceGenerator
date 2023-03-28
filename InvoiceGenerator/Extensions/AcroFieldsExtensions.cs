using iTextSharp.text.pdf;

namespace InvoiceGenerator.Extensions;

public static class AcroFieldsExtensions
{
    public static string GetValue(this AcroFields.Item item)
    {
        if (item?.GetValue() is { } pdfString)
        {
            return pdfString.ToString();
        }

        return string.Empty;
    }
}
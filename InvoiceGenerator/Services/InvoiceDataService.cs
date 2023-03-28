using InvoiceGenerator.Dtos;
using Newtonsoft.Json;

namespace InvoiceGenerator.Services;

public sealed class InvoiceDataService
{
    private void WriteInvoiceData(InvoiceDataStore data)
    {
        var json = JsonConvert.SerializeObject(data);

        var path = "invoice_data.json";
        File.WriteAllText(path, json);
    }

    private InvoiceDataStore? ReadInvoiceData()
    {
        var path = "invoice_data.json";
        var json = File.ReadAllText(path);

        var invoiceData = JsonConvert.DeserializeObject<InvoiceDataStore>(json);
        return invoiceData;
    }

    public string GetInvoiceNumber(InvoiceData invoiceData)
    {
        var invData = ReadInvoiceData();

        if (invData is not {LastInvoice: { }}) return "0";
        
        invData.LastInvoice.LastInvoiceNumber += 1;
        var invoiceNumber =
            $"{invData.LastInvoice.InvoiceNumberPrefix}-{invData.LastInvoice.LastInvoiceNumber:D6}";

        invData.InvoiceData = invoiceData;
        WriteInvoiceData(invData);

        return invoiceNumber;

    }
}
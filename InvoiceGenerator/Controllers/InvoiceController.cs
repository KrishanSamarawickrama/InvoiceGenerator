using InvoiceGenerator.Dtos;
using InvoiceGenerator.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceGenerator.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class InvoiceController : ControllerBase
{
    private readonly InvoiceGeneratorService _service;

    public InvoiceController(InvoiceGeneratorService service)
    {
        _service = service;
    }
    
    [HttpPost("generate-invoice")]
    public IActionResult GenerateInvoice([FromBody] GenerateInvoiceDto dto)
    {
        var data = dto.Adapt<InvoiceData>();
        var pdfData = _service.GeneratePdf(data);
        return File(pdfData, "application/pdf", $"Invoice-{DateTime.Today:MMM-yyyy}-Krishan.pdf");
    }
}
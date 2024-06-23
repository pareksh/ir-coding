using ir_coding_task_csv_validator.Application.Features.Csv.Commands.ValidateCsv;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ir_coding_task_csv_validator.Controllers;
[ApiController]
[Route("[controller]")]
public class ValidatorController : ControllerBase
{
    private readonly ILogger<ValidatorController> _logger;

    private readonly IMediator _mediator;

    public ValidatorController(ILogger<ValidatorController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [Route("Validate")]
    [HttpPost]
    public async Task<IActionResult> Validate(IFormFile csvFile, IFormFile stateFile)
    {
        
        if (csvFile == null || stateFile == null)
        {
            return BadRequest("Both CSV file and state file are required.");
        }

        string csvData;
        using (var reader = new StreamReader(csvFile.OpenReadStream()))
        {
            csvData = await reader.ReadToEndAsync();
        }

        string stateData;
        using (var reader = new StreamReader(stateFile.OpenReadStream()))
        {
            stateData = await reader.ReadToEndAsync();
        }
        var result = await _mediator.Send(new ValidateCsvCommand { CsvData = csvData, StateData = stateData });
        return Ok(result);
    }
}

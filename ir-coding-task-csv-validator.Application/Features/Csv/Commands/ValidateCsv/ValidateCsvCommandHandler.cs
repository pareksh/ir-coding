using ir_coding_task_csv_validator.Application.Contract;
using ir_coding_task_csv_validator.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir_coding_task_csv_validator.Application.Features.Csv.Commands.ValidateCsv
{
    public class ValidateCsvCommandHandler : IRequestHandler<ValidateCsvCommand, List<ValidationResult>>
    {
        private readonly IValidatorService _validator;
        public ValidateCsvCommandHandler(IValidatorService validator) {
            _validator = validator;
        }
        public async Task<List<ValidationResult>> Handle(ValidateCsvCommand request, CancellationToken cancellationToken)
        {
           var result = await _validator.ValidateData(request.CsvData, request.StateData);
            return result;
        }
    }
}

using ir_coding_task_csv_validator.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir_coding_task_csv_validator.Application.Features.Csv.Commands.ValidateCsv
{
    public class ValidateCsvCommand:IRequest<List<ValidationResult>>
    {
        public string CsvData { get; set; }
        public string StateData { get; set; }
    }
}

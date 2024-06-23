using ir_coding_task_csv_validator.Application.Contract;
using ir_coding_task_csv_validator.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir_coding_task_csv_validator.Application.Service.Validators
{
    public class PostcodeMadatoryValidationRule : IValidationRule
    {
        public void Validate(DataRecord record, ValidationResult result)
        {
            if (string.IsNullOrEmpty(record.Postcode))
            {
                result.Errors.Add("Postcode is required.");
            }
        }
    }
}

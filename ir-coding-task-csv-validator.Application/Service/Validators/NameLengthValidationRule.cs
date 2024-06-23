using ir_coding_task_csv_validator.Application.Contract;
using ir_coding_task_csv_validator.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir_coding_task_csv_validator.Application.Service.Validators
{
    public class NameLengthValidationRule : IValidationRule
    {
        public void Validate(DataRecord record, ValidationResult result)
        {
            if (record.Name.Length < 4)
            {
                result.Warnings.Add("Name is less than four characters.");
            }
        }
    }
}

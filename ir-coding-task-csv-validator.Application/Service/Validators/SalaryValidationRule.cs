using ir_coding_task_csv_validator.Application.Contract;
using ir_coding_task_csv_validator.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir_coding_task_csv_validator.Application.Service.Validators
{
    public class SalaryValidationRule : IValidationRule
    {
        public void Validate(DataRecord record, ValidationResult result)
        {
            if (record.Salary <= 0)
            {
                result.Warnings.Add("Salary is not a positive integer.");
            }
        }
    }
}

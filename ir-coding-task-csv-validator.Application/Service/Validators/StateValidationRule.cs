using ir_coding_task_csv_validator.Application.Contract;
using ir_coding_task_csv_validator.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir_coding_task_csv_validator.Application.Service.Validators
{
    public class StateValidationRule : IValidationRule
    {
        private readonly Dictionary<int, string> _statesTable;

        public StateValidationRule(Dictionary<int, string> statesTable)
        {
            _statesTable = statesTable;
        }

        public void Validate(DataRecord record, ValidationResult result)
        {
            if (!_statesTable.ContainsKey(record.State))
            {
                result.Errors.Add("Invalid state code.");
            }
        }
    }
}

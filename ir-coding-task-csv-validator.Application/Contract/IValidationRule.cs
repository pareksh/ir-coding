﻿using ir_coding_task_csv_validator.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir_coding_task_csv_validator.Application.Contract
{
    public interface IValidationRule
    {
        void Validate(DataRecord record, ValidationResult result);
    }
}
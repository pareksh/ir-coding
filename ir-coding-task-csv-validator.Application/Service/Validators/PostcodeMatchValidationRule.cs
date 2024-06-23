using ir_coding_task_csv_validator.Application.Contract;
using ir_coding_task_csv_validator.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir_coding_task_csv_validator.Application.Service.Validators
{
    public class PostcodeMatchValidationRule: IValidationRule
    {
        public void Validate(DataRecord record, ValidationResult result)
        {
           
            if (!StatePostcodeRanges.Ranges.TryGetValue(record.State, out var range))
            {
                result.Errors.Add($"Invalid state code: {record.State}");
                return;
            }

            if (string.IsNullOrWhiteSpace(record.Postcode))
            {
                //result.Errors.Add("Postcode is required.");
                return;
            }

            if (int.TryParse(record.Postcode, out int postcode))
            {
                if (postcode < range.Min || postcode > range.Max)
                {
                    result.Warnings.Add($"Postcode {record.Postcode} is not valid for the state code {record.State}.");
                }
            }
            //else
            //{
            //    result.Warnings.Add($"Postcode {record.Postcode} is not a valid number.");
            //}
        }
    }

    public static class StatePostcodeRanges
    {
        public static readonly Dictionary<int, (int Min, int Max)> Ranges = new Dictionary<int, (int Min, int Max)>
    {
        { 1, (7000, 7999) }, // Tasmania
        { 2, (3000, 3999) }, // Victoria
        { 3, (2000, 2999) }, // New South Wales
        { 4, (2600, 2618) }, // Australian Capital Territory
        { 5, (4000, 4999) }, // Queensland
        { 6, (0800, 0999) }, // Northern Territory
        { 7, (5000, 5799) }, // South Australia
        { 8, (6000, 6999) }  // Western Australia
    };
    }
}

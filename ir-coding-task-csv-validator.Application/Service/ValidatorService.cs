using CsvHelper;
using CsvHelper.Configuration;
using ir_coding_task_csv_validator.Application.Contract;
using ir_coding_task_csv_validator.Application.Models;
using ir_coding_task_csv_validator.Application.Service.Validators;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir_coding_task_csv_validator.Application.Service
{
    public class ValidatorService : IValidatorService
    {
        
        public async Task<List<ValidationResult>> ValidateData(string csvData, string stateData)
        {
            var statesTable = ParseStateData(stateData);
            var validationRules = new List<IValidationRule>
                {
                    new NameLengthValidationRule(),
                    new StateValidationRule(statesTable),
                    new SalaryValidationRule(),
                    new PostcodeMadatoryValidationRule(),
                    new PostcodeMatchValidationRule()
                };

            var results = new List<ValidationResult>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (var reader = new StringReader(csvData))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<DataRecord>();

                foreach (var record in records)
                {
                    var result = new ValidationResult { Name = record.Name };
                    foreach (var rule in validationRules)
                    {
                        rule.Validate(record, result);
                    }
                    results.Add(result);
                }
            }

            return await Task.FromResult(results);
        }
        private Dictionary<int, string> ParseStateData(string stateData)
        {
            var statesTable = new Dictionary<int, string>();
            var lines = stateData.Split('\n');
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[0], out var stateCode))
                {
                    statesTable[stateCode] = parts[1].Trim();
                }
            }
            return statesTable;
        }
    }
}

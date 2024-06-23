using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir_coding_task_csv_validator.Application.Models
{
    public class DataRecord
    {
        [Name("Name")]
        public string Name { get; set; }

        [Name("State")]
        public int State { get; set; }
        [Name("Salary")]
        public int Salary { get; set; }

        [Name("Date of birth")]
       // [TypeConverter(typeof(CustomDateConverter), "yyyyMMdd")]
        public int DateOfBirth { get; set; }

        [Name("Postcode")]
        public string Postcode { get; set; }
    }

   
}

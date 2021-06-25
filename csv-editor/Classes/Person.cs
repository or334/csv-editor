using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace csv_editor.Classes
{
    public class Person
    {
        [MinLength(1)]
        [Name("First name")]
        public string FirstName { get; set; }

        [MinLength(1)]
        [Name("Last name")]
        public string LastName { get; set; }
    }
}

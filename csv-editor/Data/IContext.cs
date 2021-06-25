using csv_editor.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csv_editor.Data
{
    public interface IContext
    {
        List<Person> GetRecords();
        Task<bool> WriteRecordsAsync(List<Person> records);
    }
}

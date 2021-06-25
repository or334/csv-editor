using csv_editor.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csv_editor.Repository
{
    public interface IRepository
    {
        int RowsLength { get; }
        List<Person> Records { get; }
        Task<List<Person>> GetRecordsAsync();
        Task<bool> UpdateCsvRecordsAsync(List<Person> persons);
    }
}

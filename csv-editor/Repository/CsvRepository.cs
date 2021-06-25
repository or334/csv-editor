﻿using csv_editor.Classes;
using csv_editor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csv_editor.Repository
{
    public class CsvRepository : IRepository
    {
        public int RowsLength { get; set; }
        public List<Person> Records { get; set; }

        private readonly IContext _context;
        public CsvRepository (IContext context)
        {
            _context = context ?? throw new ArgumentNullException("context"); ;
        }

        public async Task<List<Person>> GetRecordsAsync()
        {
            Records = await Task.Run(() => _context.GetRecords()).ConfigureAwait(false);
            RowsLength = Records.Count();
            return Records;
        }

        public async Task<bool> UpdateCsvRecordsAsync(List<Person> persons)
        {
           return await _context.WriteRecordsAsync(persons).ConfigureAwait(false);
        }
    }
}

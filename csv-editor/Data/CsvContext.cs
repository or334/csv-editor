using csv_editor.Classes;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace csv_editor.Data
{
    /// <summary>
    /// This class is reponsible to read and write data to the CSV.
    /// It gets the path of the CSV inside the project, and then using StreamReader/StreamWriter,
    /// With the help of the CsvHelper library, to do such actions.
    /// It returns the records in case of reading the file,
    /// And returns true if the write operation has been succeed.
    /// </summary>
    public class CsvContext : IContext
    {
        private const string PATH_OF_CSV_FILE = "./Files/oolo-worker-names.csv";
        public List<Person> GetRecords()
        {
            try
            {
                using (var streamReader = new StreamReader(PATH_OF_CSV_FILE))
                {
                    using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                    {
                        var records = csvReader.GetRecords<Person>().ToList();
                        return records;
                    }
                }
            }
            catch (CsvHelperException e)
            {
                Console.WriteLine($"{e.Message} " + (e.InnerException == null ? string.Empty : e.InnerException.Message));
                throw;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message} " + (ex.InnerException == null ? string.Empty : ex.InnerException.Message));
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} " + (ex.InnerException == null ? string.Empty : ex.InnerException.Message));
                throw;
            }
        }


        public async Task<bool> WriteRecordsAsync(List<Person> records)
        {
            try
            {
                using (var streamWriter = new StreamWriter(PATH_OF_CSV_FILE))
                {
                    using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                    {
                        await csvWriter.WriteRecordsAsync(records).ConfigureAwait(false);
                        await csvWriter.FlushAsync().ConfigureAwait(false);
                        return true;
                    }
                }
            }
            catch (CsvHelperException e)
            {
                Console.WriteLine($"{e.Message} " + (e.InnerException == null ? string.Empty : e.InnerException.Message));
                throw;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"{ex.Message} " + (ex.InnerException == null ? string.Empty : ex.InnerException.Message));
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} " + (ex.InnerException == null ? string.Empty : ex.InnerException.Message));
                throw;
            }
        }
    }
}

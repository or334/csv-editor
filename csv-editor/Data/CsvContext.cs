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
    public class CsvContext : IContext
    {
        private const string PATH_OF_CSV_FILE = "./Files/oolo-worker-names.csv";
        public List<Person> GetRecords()
        {
            using (var streamReader = new StreamReader(PATH_OF_CSV_FILE))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    try
                    {
                        var records = csvReader.GetRecords<Person>().ToList();
                        return records;
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
            }
        }

        public async Task<bool> WriteRecordsAsync(List<Person> records)
        {
            using (var streamWriter = new StreamWriter(PATH_OF_CSV_FILE))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    try
                    {
                        await csvWriter.WriteRecordsAsync(records).ConfigureAwait(false);
                        await csvWriter.FlushAsync().ConfigureAwait(false);
                        return true;
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
    }
}

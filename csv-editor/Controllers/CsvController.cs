using csv_editor.Classes;
using csv_editor.Data;
using csv_editor.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csv_editor.Controllers
{
    [Route("api/v1/csv")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        private readonly IRepository _repository;

        public CsvController(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException("repository");
        }

        [HttpGet]
        [Route("get-persons")]
        public async Task<List<Person>> GetCsvRecords()
        {
            return await _repository.GetRecordsAsync().ConfigureAwait(false);
        }

        [HttpPut]
        [Route("update-persons")]
        public async Task<IActionResult> UpdateCsvRecords([FromBody] List<Person> persons)
        {
/*            if (persons.Count() != _repository.RowsLength)
                return BadRequest("The rows amount must be the same in order to edit the document!");
            if (persons.SequenceEqual(_repository.Records))
                return BadRequest("No new data has been detected!");*/
            var operationSuccess = await _repository.UpdateCsvRecordsAsync(persons);
            if (operationSuccess)
                return Ok(operationSuccess);
            else
                return StatusCode(500);
        }
    }
}

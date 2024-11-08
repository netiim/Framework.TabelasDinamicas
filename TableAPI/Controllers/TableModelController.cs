using Core.Entidades;
using Core.Interfaces.Services;
using DTOs.TablesModel;
using Microsoft.AspNetCore.Mvc;

namespace TableAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableModelController : ControllerBase
    {
        private readonly ITableModelService _service;

        public TableModelController(ITableModelService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<TableModel>> GetAllTables()
        {
            return await _service.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable(CreateTableModelDTO table)
        {
            //Auto Mapper
            //await _service.CreateAsync(table);
            return Ok();
        }
    }
}

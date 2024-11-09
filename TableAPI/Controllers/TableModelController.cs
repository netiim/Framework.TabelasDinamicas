using AutoMapper;
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
        private readonly IMapper _mapper;

        public TableModelController(ITableModelService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TableModel>> GetAllTables()
        {
            return await _service.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable(CreateTableModelDTO tableDTO)
        {
            TableModel table = _mapper.Map<TableModel>(tableDTO);
            await _service.CreateAsync(table);
            return Ok();
        }
    }
}

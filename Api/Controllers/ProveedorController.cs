using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorController(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        [HttpPost("InsertAgenda")]
        public async Task<IActionResult> InsertAgenda([FromBody] Agenda proveedor)
        {
            var agenda = await _proveedorRepository.InsertAgendaDate(proveedor.id,proveedor.orden,proveedor.fechaAgenda);
            return Ok(new { agenda = agenda });
        }

        [HttpPost("InsertAgendaDetalle")]
        public async Task<IActionResult> InsertAgendaDetalle([FromBody] AgendaDetalle agenda)
        {
            var a = await _proveedorRepository.InsertAgendaDetalle(agenda.idAgenda, agenda.codProducto, agenda.cantidad);
            return Ok(new { agenda = a });
        }
    }
}

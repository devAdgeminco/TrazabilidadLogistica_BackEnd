using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequerimientoController : ControllerBase
    {
        private readonly IRequerimientoRepository _requerimientoRepository;
        private readonly IConfiguration _configuration;
        public RequerimientoController(IRequerimientoRepository requerimientoRepository, IConfiguration configuration)
        {
            _requerimientoRepository = requerimientoRepository;
            _configuration = configuration;
        }


        [HttpPost("getRequerimientos")]
        public async Task<IActionResult> getRequerimientos([FromForm]DateTime fecIni, [FromForm] DateTime fecFin)
        {
            var requerimientos = await _requerimientoRepository.GetRequerimientos(fecIni, fecFin);
            return Ok(new { requerimientos = requerimientos });
        }

        [HttpPost("getRequerimientoDetalle")]
        public async Task<IActionResult> getRequerimientoDetalle([FromBody]Requerimiento requerimiento)
        {
            var requerimientoDetalle = await _requerimientoRepository.GetRequerimientoDetalle(requerimiento.idReq);
            return Ok(new { requerimientoDetalle = requerimientoDetalle });
        }

        [HttpPost("getOrdenCompra")]
        public async Task<IActionResult> getOrdenCompra([FromForm] DateTime fecIni, [FromForm] DateTime fecFin)
        {
            var ordenCompra = await _requerimientoRepository.getOrdenCompra(fecIni, fecFin);
            return Ok(new { ordenCompra = ordenCompra });
        }

        [HttpPost("getOrdenCompraDetalle")]
        public async Task<IActionResult> getOrdenCompraDetalle([FromBody]OrdenCompra oCompra)
        {
            var ordenCompra = await _requerimientoRepository.getOrdenCompraDetalle(oCompra.id);
            return Ok(new { ordenCompra = ordenCompra });
        }

        [HttpPost("getPartesEntrada")]
        public async Task<IActionResult> getPartesEntrada([FromForm] DateTime fecIni, [FromForm] DateTime fecFin)
        {
            var partesEntrada = await _requerimientoRepository.getPartesEntrada(fecIni, fecFin);
            return Ok(new { partesEntrada = partesEntrada });
        }

        [HttpPost("getPartesEntradaDetalle")]
        public async Task<IActionResult> getPartesEntradaDetalle([FromBody] ParteEntrada pEntrada)
        {
            var parteEntraDetalle = await _requerimientoRepository.getPartesEntradaDetalle(pEntrada.id);
            return Ok(new { parteEntraDetalle = parteEntraDetalle });
        }
    }
}

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
        public async Task<IActionResult> getRequerimientos([FromForm]DateTime fecIni, [FromForm] DateTime fecFin, [FromForm]int empresa)
        {
            var requerimientos = await _requerimientoRepository.GetRequerimientos(fecIni, fecFin,empresa);
            return Ok(new { requerimientos = requerimientos });
        }

        [HttpPost("getRequerimiento")]
        public async Task<IActionResult> getRequerimiento(Requerimiento req)
        {
            var requerimiento = await _requerimientoRepository.GetRequerimiento(req.idReq, req.empresa);
            return Ok(new { requerimiento = requerimiento });
        }

        [HttpPost("getRequerimientoDetalle")]
        public async Task<IActionResult> getRequerimientoDetalle([FromBody]Requerimiento requerimiento)
        {
            var requerimientoDetalle = await _requerimientoRepository.GetRequerimientoDetalle(requerimiento.idReq);
            return Ok(new { requerimientoDetalle = requerimientoDetalle });
        }

        [HttpPost("getTrazabilidadDetalle")]
        public async Task<IActionResult> getTrazabilidadDetalle([FromBody] Requerimiento requerimiento)
        {
            var TrazabilidadDetalle = await _requerimientoRepository.GetTrazabilidadDetalle(requerimiento.idReq);
            return Ok(new { TrazabilidadDetalle = TrazabilidadDetalle });
        }

        [HttpPost("getOrdenCompra")]
        public async Task<IActionResult> getOrdenCompra([FromForm] DateTime fecIni, [FromForm] DateTime fecFin, [FromForm] int empresa)
        {
            var ordenCompra = await _requerimientoRepository.getOrdenCompra(fecIni, fecFin, empresa);
            return Ok(new { ordenCompra = ordenCompra });
        }

        [HttpPost("getOCompra")]
        public async Task<IActionResult> getOCompra([FromBody] Requerimiento requerimiento)
        {
            var oCompra = await _requerimientoRepository.getOCompra(requerimiento.idReq, requerimiento.empresa);
            return Ok(new { oCompra = oCompra });
        }

        [HttpPost("getOrdenCompraDetalle")]
        public async Task<IActionResult> getOrdenCompraDetalle([FromBody]OrdenCompra oCompra)
        {
            var ordenCompra = await _requerimientoRepository.getOrdenCompraDetalle(oCompra.id);
            return Ok(new { ordenCompra = ordenCompra });
        }

        [HttpPost("getOCDetalleAgenda")]
        public async Task<IActionResult> getOCDetalleAgenda([FromBody] OrdenCompra oCompra)
        {
            var ordenCompra = await _requerimientoRepository.getOCDetalleAgenda(oCompra.idOrdenC,oCompra.ruc);
            return Ok(new { ordenCompra = ordenCompra });
        }

        [HttpPost("getAgenda")]
        public async Task<IActionResult> getAgenda([FromBody] OrdenCompra oCompra)
        {
            var agenda = await _requerimientoRepository.getAgenda(oCompra.idOrdenC);
            return Ok(new { agenda = agenda });
        }

        [HttpPost("getPartesEntrada")]
        public async Task<IActionResult> getPartesEntrada([FromForm] DateTime fecIni, [FromForm] DateTime fecFin, [FromForm] int empresa)
        {
            var partesEntrada = await _requerimientoRepository.getPartesEntrada(fecIni, fecFin, empresa);
            return Ok(new { partesEntrada = partesEntrada });
        }

        [HttpPost("getParteEntrada")]
        public async Task<IActionResult> getParteEntrada([FromBody] Requerimiento requerimiento)
        {
            var parteEntrada = await _requerimientoRepository.getParteEntrada(requerimiento.idReq,requerimiento.empresa);
            return Ok(new { parteEntrada = parteEntrada });
        }

        [HttpPost("getPartesEntradaDetalle")]
        public async Task<IActionResult> getPartesEntradaDetalle([FromBody] ParteEntrada pEntrada)
        {
            var parteEntraDetalle = await _requerimientoRepository.getPartesEntradaDetalle(pEntrada.id);
            return Ok(new { parteEntraDetalle = parteEntraDetalle });
        }
    }
}

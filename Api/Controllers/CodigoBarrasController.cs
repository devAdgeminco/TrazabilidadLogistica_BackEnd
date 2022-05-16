using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodigoBarrasController : ControllerBase
    {
        private readonly ICodigoBarrasRepository _codigoBarrasRepository;
        private readonly IConfiguration _configuration;
        public CodigoBarrasController(ICodigoBarrasRepository codigoBarrasRepository, IConfiguration configuration)
        {
            _codigoBarrasRepository = codigoBarrasRepository;
            _configuration = configuration;
        }

        [HttpPost("getBarraCodigoOC")]
        public async Task<IActionResult> getBarraCodigoOC(Requerimiento req)
        {
            var codigoBarrasOC = await _codigoBarrasRepository.GetBarraCodigoOC(req.idReq, req.empresa);
            return Ok(new { codigoBarrasOC = codigoBarrasOC });
        }

        [HttpPost("getBarraCodigoOCD")]
        public async Task<IActionResult> getBarraCodigoOCD(Requerimiento req)
        {
            var codigoBarrasOCD = await _codigoBarrasRepository.GetBarraCodigoOCD(req.idReq, req.empresa);
            return Ok(new { codigoBarrasOCD = codigoBarrasOCD });
        }
    }
}

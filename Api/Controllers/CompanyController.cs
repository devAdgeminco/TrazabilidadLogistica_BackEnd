using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IConfiguration _configuration;

        public CompanyController(ICompanyRepository companyRepository, IConfiguration configuration)
        {
            _companyRepository = companyRepository;
            _configuration = configuration;
        }

        [HttpGet("companies")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companyRepository.GetCompanies();
            return Ok(new { company = companies });
        }

        [HttpPost("validarEmpresaOC")]
        public async Task<IActionResult> ValidarEmpresaOC([FromBody] Company company)
        {
            var ordenes = await _companyRepository.ValidarEmpresaOC(company.Ruc);
            return Ok(new { ordenes = ordenes });
        }
    }
}

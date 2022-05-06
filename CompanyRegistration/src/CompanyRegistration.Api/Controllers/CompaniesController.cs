using AutoMapper;
using CompanyRegistration.Api.Models;
using CompanyRegistration.Domain.Entities;
using CompanyRegistration.Service;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRegistration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompaniesService _companiesService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompaniesService companiesService, IMapper mapper)
        {
            _companiesService = companiesService ?? throw new ArgumentNullException(nameof(companiesService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var companies = await _companiesService.GetAsync();

            if (companies is null || !companies.Any())
            {
                return NoContent();
            }

            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return Ok(companiesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var company = await _companiesService.GetAsync(id);

            if (company is null)
            {
                return NotFound();
            }

            var companyDto = _mapper.Map<CompanyDto>(company);

            return Ok(companyDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompanyDto companyDto)
        {
            var newCompany = _mapper.Map<Company>(companyDto);

            await _companiesService.AddAsync(newCompany);

            return CreatedAtAction("AddAsync", new { id = newCompany.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CompanyDto companyDto)
        {
            if (await _companiesService.GetAsync(id) is null)
            {
                return NotFound();
            }

            var newCompany = _mapper.Map<Company>(companyDto);

            await _companiesService.UpdateAsync(id, newCompany);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _companiesService.GetAsync(id) is null)
            {
                return NotFound();
            }

            await _companiesService.RemoveAsync(id);

            return NoContent();
        }
    }
}

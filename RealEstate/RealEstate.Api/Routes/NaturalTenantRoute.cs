using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Validators.NaturalTenant;
using RealEstate.App.Services;
using RealEstate.Domain.Entities;
using RealEstate.Shared.Dtos;

namespace RealEstate.Api.Routes;

[ApiController]
[Route("api/tenant/natural")]
public class NaturalTenantsController(INaturalTenantService tenantService) : ControllerBase
{
    private readonly INaturalTenantService _tenantService = tenantService;

    [HttpGet]
    public async Task<ActionResult<List<NaturalTenant>>> GetTenants()
    {
        var tenants = await _tenantService.GetTenantsAsync();
        return Ok(tenants);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NaturalTenant?>> GetTenant(int id)
    {
        var tenant = await _tenantService.GetTenantByIdAsync(id);
        if (tenant == null)
            return NotFound();

        return Ok(tenant);
    }

    [HttpPost]
    public async Task<ActionResult<NaturalTenant>> CreateTenant(CreateNaturalTenantDto dto)
    {
        var validator = new NaturalTenantCreationValidator();
        validator.ValidateAndThrow(dto);

        var createdTenant = await _tenantService.CreateTenantAsync(dto);
        return CreatedAtAction(nameof(CreateTenant), new { id = createdTenant.Id }, createdTenant);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTenant(UpdateNaturalTenantDto dto)
    {
        var validator = new NaturalTenantUpdateValidator();
        validator.ValidateAndThrow(dto);
        await _tenantService.UpdateTenantAsync(dto);
        return Ok(true);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTenant(int id)
    {
        var deleted = await _tenantService.DeleteTenantAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}

using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos;
using RealEstate.Api.Validators.LegalTenant;
using RealEstate.App.Services;
using RealEstate.Domain.Entities;

namespace RealEstate.Api.Routes;

[ApiController]
[Route("api/tenants/legal")]
public class LegalTenantsController(ILegalTenantService tenantService) : ControllerBase
{
    private readonly ILegalTenantService _tenantService = tenantService;

    [HttpGet]
    public async Task<ActionResult<List<LegalTenant>>> GetTenants()
    {
        var tenants = await _tenantService.GetTenantsAsync();
        return Ok(tenants);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LegalTenant?>> GetTenant(int id)
    {
        var tenant = await _tenantService.GetTenantByIdAsync(id);
        if (tenant == null)
            return NotFound();

        return Ok(tenant);
    }

    [HttpPost]
    public async Task<ActionResult<LegalTenant>> CreateTenant(CreateLegalTenantDto dto)
    {
        var validator = new LegalTenantCreationValidator();
        validator.ValidateAndThrow(dto);

        var createdTenant = await _tenantService.CreateTenantAsync(dto);
        return CreatedAtAction(nameof(CreateTenant), new { id = createdTenant.Id }, createdTenant);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTenant(UpdateLegalTenantDto dto)
    {
        var validator = new LegalTenantUpdateValidator();
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

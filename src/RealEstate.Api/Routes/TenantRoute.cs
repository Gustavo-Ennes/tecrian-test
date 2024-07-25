using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos.Tenant;
using RealEstate.App.Services;
using RealEstate.Domain.Entities;

namespace RealEstate.Api.Routes;

[ApiController]
[Route("api/tenants")]
public class TenantsController(ITenantService tenantService) : ControllerBase
{
    private readonly ITenantService _tenantService = tenantService;

    [HttpGet]
    public async Task<ActionResult<List<Tenant>>> GetTenants()
    {
        var tenants = await _tenantService.GetTenantsAsync();
        return Ok(tenants);
    }

    [HttpGet("{id}")]
    
    public async Task<ActionResult<Tenant?>> GetTenant(int id)
    {
        var tenant = await _tenantService.GetTenantByIdAsync(id);
        if (tenant == null)
        {
            return NotFound();
        }
        return Ok(tenant);
    }

    [HttpPost]
    public async Task<ActionResult<Tenant>> CreateTenant(CreateTenantDto tenantDto)
    {
        var createdTenant = await _tenantService.CreateTenantAsync(tenantDto);
        return CreatedAtAction(nameof(CreateTenant), new { id = createdTenant.Id }, createdTenant);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTenant(UpdateTenantDto dto)
    {
        await _tenantService.UpdateTenantAsync(dto);
        return Ok(true);
        
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTenant(int id)
    {
        var deleted = await _tenantService.DeleteTenantAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}

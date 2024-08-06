using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstate.Infra.Database;
using RealEstate.Infra.Profiles;

namespace RealEstate.Test.Integration.Base;

public class BaseIntegration(CustomWebApplicationFactory<Program> factory)
    : IClassFixture<CustomWebApplicationFactory<Program>>
        // ,IDisposable
{
    public readonly HttpClient _client = factory.CreateClient();
}

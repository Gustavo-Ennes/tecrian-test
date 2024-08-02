using System.Text.Json;

namespace RealEstate.Shared.Utils;

public static class JsonSerializerOptionsCache
{
    public static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public static string SerializeIndented(this object obj) =>
        JsonSerializer.Serialize(obj, Options);
}

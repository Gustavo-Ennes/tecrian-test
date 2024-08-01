using RealEstate.Utils;

namespace RealEstate.Api.Dtos.Base;

public class UpdateBaseDto
{
    public int? Id { get; set; }

    public override string ToString() => this.SerializeIndented();
}

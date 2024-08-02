using RealEstate.Shared.Utils;

namespace RealEstate.Shared.Dtos.Base;

public class UpdateBaseDto
{
    public int Id { get; set; }

    public override string ToString() => this.SerializeIndented();
}

public class CreateBaseDto
{
    public int? Id { get; set; }

    public override string ToString() => this.SerializeIndented();
}

using AutoMapper;
using Tecrian.Domain.Entities;
using Tecrian.Test.Integration.Base;
using Tecrian.Test.DataAttributes.UserDto;

namespace Tecrian.Test.Integration.Fixtures;

public class UserFixture : BaseFixture, IFixture
{
  public UserFixture()
  {
    AddData();
  }

  public void AddData()
  {
    IMapper mapper = BaseIntegration.AddAutoMapper();
    User user = mapper.Map<User>(
        CreateUserDtoDataAttribute_Valid.GetUser()
    );
    user.IsEmailVerified = true;

    DbContext.User.Add(user);
    DbContext.SaveChanges();
  }
}

[CollectionDefinition("User")]
public class UserCollection : ICollectionFixture<UserFixture> { }

using CamMaster.Api.Server.GraphQL.Common;
using CamMaster.Api.Server.Models;

namespace CamMaster.Api.Server.GraphQL.Users;

public class UserLoginPayload : Payload
{
    public UserLoginPayload(UserAccount userAccount)
    {
        UserAccount = userAccount;
    }
    public UserLoginPayload(UserError error):base(new []{error})
    {

    }

    public UserAccount UserAccount { get; }
}

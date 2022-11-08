namespace CamMaster.Api.Server.GraphQL.Common
{
    [GraphQLName("UserError")]
    public interface IUserError
    {
        string Message { get; }

        string Code { get; }
    }
    public class UserError : IUserError
    {
        public UserError(string message, string code)
        {
            Message = message;
            Code = code;
        }

        public string Message { get; }

        public string Code { get; }
    }
}
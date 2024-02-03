using Application.Authentication.Common;
using Contracts.Common.Authentication.Responses;
using Mapster;

namespace WebAPI.Common.Mapping
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, RegisterResponse>()
                .Map(destination => destination, source => source.User);

            config.NewConfig<AuthenticationResult, LoginResponse>()
                .Map(destination => destination, source => source.User);
        }
    }
}

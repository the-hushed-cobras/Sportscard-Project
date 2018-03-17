using AutoMapper;

namespace SportscardSystem.Architecture.Automapper.Contracts
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}

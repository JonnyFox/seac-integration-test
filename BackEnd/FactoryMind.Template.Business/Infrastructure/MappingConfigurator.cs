using System.Linq;
using AutoMapper;

namespace FactoryMind.Template.Business.Infrastructure
{
    internal interface IAutomapperConfigurator
    {
        void Configre(IMapperConfigurationExpression cfg);
    }

    internal abstract class AutomapperConfigurator<TSource, TDestination> : IAutomapperConfigurator
    {
        public void Configre(IMapperConfigurationExpression cfg)
        {
            var map = cfg.CreateMap<TSource, TDestination>();
            Configure(map);
            IgnoreNonExisting(map);

            var inverseMap = cfg.CreateMap<TDestination, TSource>();
            Configure(inverseMap);
            IgnoreNonExisting(inverseMap);
        }

        private static void IgnoreNonExisting<T1, T2>(IMappingExpression<T1, T2> map)
        {
            var sourceType = typeof(T1);
            var sourceProperties = sourceType.GetProperties().ToDictionary(p => p.Name);

            map.ForAllOtherMembers(member =>
            {
                if (member.DestinationMember == null || !sourceProperties.ContainsKey(member.DestinationMember.Name))
                {
                    member.Ignore();
                }
            });
        }

        protected virtual void Configure(IMappingExpression<TSource, TDestination> expression)
        {
            // Do notning by default
        }

        protected virtual void Configure(IMappingExpression<TDestination, TSource> expression)
        {
            // Do notning by default
        }
    }
}

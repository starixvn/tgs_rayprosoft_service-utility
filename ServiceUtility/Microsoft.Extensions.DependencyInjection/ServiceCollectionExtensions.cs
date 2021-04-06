using System;
using System.Linq;
using System.Reflection;
using TGS.ServiceUtility;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection RegisterAllServiceUtilityTypes(
			this IServiceCollection services,
			Assembly targetAssembly,
			ServiceLifetime lifetime)
		{
			var allTypes = targetAssembly.GetTypes();

			var searchGenericTypeDefinitions = new[] {
				typeof(ICommandService<>),
				typeof(IGetService<,>),
				typeof(IQueryService<,>)
			};

			var query = from type in allTypes
						from implementedInterfaceType in type.GetInterfaces()
						where implementedInterfaceType.IsGenericType
							&& searchGenericTypeDefinitions.Contains(implementedInterfaceType.GetGenericTypeDefinition())
						select new ServiceDescriptor(implementedInterfaceType, type, lifetime);

			foreach (var desc in query)
				services.Add(desc);

			return services;
		}
	}
}

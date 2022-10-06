using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Tgs.ServiceUtility;

internal class DefaultServiceCoordinator : IServiceCoordinator
{
	private readonly IServiceProvider _serviceProvider;

	public DefaultServiceCoordinator(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
	}

	public ValueTask<TResult> GetAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
		=> _serviceProvider.GetRequiredService<IGetService<TQuery, TResult>>().GetAsync(query, cancellationToken);

	public IAsyncEnumerable<TResult> QueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
		=> _serviceProvider.GetRequiredService<IQueryService<TQuery, TResult>>().QueryAsync(query, cancellationToken);

	public ValueTask ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
		=> _serviceProvider.GetRequiredService<ICommandService<TCommand>>().ExecuteAsync(command, cancellationToken);
}

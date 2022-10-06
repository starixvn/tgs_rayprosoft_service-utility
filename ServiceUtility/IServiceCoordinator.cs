using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tgs.ServiceUtility;

public interface IServiceCoordinator
{
	ValueTask<TResult> GetAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default);

	IAsyncEnumerable<TResult> QueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default);

	ValueTask ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default);
}

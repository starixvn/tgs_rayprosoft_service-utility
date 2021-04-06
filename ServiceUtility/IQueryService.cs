using System.Collections.Generic;
using System.Threading;

namespace TGS.ServiceUtility
{
	public interface IQueryService<TQuery, TResult>
	{
		IAsyncEnumerable<TResult> QueryAsync(TQuery query, CancellationToken cancellationToken = default);
	}
}

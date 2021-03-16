using System.Collections.Generic;

namespace TGS.ServiceUtility
{
	public interface IQueryService<TQuery, TResult>
	{
		IAsyncEnumerable<TResult> QueryAsync(TQuery query);
	}
}

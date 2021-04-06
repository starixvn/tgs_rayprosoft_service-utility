using System.Threading;
using System.Threading.Tasks;

namespace TGS.ServiceUtility
{
	public interface IGetService<TQuery, TResult>
	{
		ValueTask<TResult> GetAsync(TQuery query, CancellationToken cancellationToken = default);
	}
}

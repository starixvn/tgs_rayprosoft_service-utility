using System.Threading;
using System.Threading.Tasks;

namespace Tgs.ServiceUtility
{
	public interface ICommandService<TCommand>
	{
		ValueTask ExecuteAsync(TCommand command, CancellationToken cancellationToken = default);
	}
}

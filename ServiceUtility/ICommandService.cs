using System.Threading.Tasks;

namespace TGS.ServiceUtility
{
	public interface ICommandService<TCommand>
	{
		ValueTask ExecuteAsync(TCommand command);
	}
}

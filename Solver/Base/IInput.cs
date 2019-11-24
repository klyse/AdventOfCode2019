namespace Solver.Base
{
	public interface IInput<out TType>
	{
		TType Parse(string[] values);
	}
}
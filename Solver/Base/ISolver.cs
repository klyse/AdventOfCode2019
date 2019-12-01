namespace Solver.Base
{
	public interface ISolver<out TOutput, in TInput>
	{
		TOutput Star1(TInput input);
		TOutput Star2(TInput input);
	}
}
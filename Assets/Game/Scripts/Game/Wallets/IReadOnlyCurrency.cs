public interface IReadOnlyCurrency
{
	IReadOnlyReactiveVariable<int> Value { get; }
}
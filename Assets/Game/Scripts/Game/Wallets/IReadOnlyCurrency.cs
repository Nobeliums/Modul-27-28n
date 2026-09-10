public interface IReadOnlyCurrency
{
	IReadOnlyReactiveVariable<int> Value { get; }
	
	string Name { get; }
}
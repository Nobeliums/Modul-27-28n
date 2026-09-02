public interface IDestroyable
{
	public bool IsDestroyed { get; }

	public void Destroy();
}
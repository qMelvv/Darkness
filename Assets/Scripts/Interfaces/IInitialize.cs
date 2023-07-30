public interface IInitialize<T>
{
    public void Initialize(T instance);
}

public interface IInitializeStats : IInitialize<Stats>
{

}

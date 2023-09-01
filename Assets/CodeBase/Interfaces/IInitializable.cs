namespace CodeBase.Interfaces
{
    public interface IInitializable
    {
        void Initialize();
    }

    public interface IInitializableComponent<T>
    {
        void InitializeComponent(T component);
    }
}
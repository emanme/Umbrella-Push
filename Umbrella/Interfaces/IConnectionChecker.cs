namespace Umbrella.Interfaces
{
    public interface IConnectionChecker
    {
        bool IsConnected { get; }

        void CheckNetworkConnection();
    }
}

namespace EvanPlayHouse.Core.Services
{
    public interface IApiService
    {
        IProjectApi Speculative { get; }
        IProjectApi UserInitiated { get; }
        IProjectApi Background { get; }
    }
}

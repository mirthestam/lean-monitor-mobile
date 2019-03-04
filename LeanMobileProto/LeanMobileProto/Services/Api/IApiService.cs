using Fusillade;

namespace LeanMobileProto.Services.Api
{
    public interface IApiService
    {
        IApi Background { get; }
        IApi UserInitiated { get; }
        IApi Speculative { get; }

        IApi ForPriority(Priority priority);
    }
}
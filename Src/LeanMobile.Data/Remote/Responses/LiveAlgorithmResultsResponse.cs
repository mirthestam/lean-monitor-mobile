using NullGuard;

namespace LeanMobile.Data.Remote.Responses
{
    public class LiveAlgorithmResultsResponse : RootResponse
    {
        [AllowNull]
        public LiveResultsData LiveResults { get; set; }
    }
}
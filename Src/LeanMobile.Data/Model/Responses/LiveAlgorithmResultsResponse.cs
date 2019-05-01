using NullGuard;

namespace LeanMobile.Data.Model.Responses
{
    public class LiveAlgorithmResultsResponse : RootResponse
    {
        [AllowNull]
        public LiveResultsData LiveResults { get; set; }
    }
}
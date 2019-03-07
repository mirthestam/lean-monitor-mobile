namespace LeanMobile.Algorithm
{
    public class AlgorithmService : IAlgorithmService
    {
        private readonly IAlgorithmRepository _algorithmRepository;
        
        //private Subject<int> _algorithmUpdatedSubject = new Subject<int>();

        //public IObservable<int> AlgoritmUpdated => _algorithmUpdatedSubject.AsObservable();

        //private void UpdateAlgorithm()
        //{
        //    // TODO: Invoke this, when I have new data for an algorithm
        //    _algorithmUpdatedSubject.OnNext(45);
        //}
    }
}

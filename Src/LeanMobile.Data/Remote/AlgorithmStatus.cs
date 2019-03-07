namespace LeanMobile.Data.Remote
{
    public enum AlgorithmStatus
    {
        DeployError, 
        InQueue,    
        Running,    
        Stopped,    
        Liquidated, 
        Deleted,    
        Completed,  
        RuntimeError,
        Invalid,
        LoggingIn,
        Initializing,
        History
    }
}
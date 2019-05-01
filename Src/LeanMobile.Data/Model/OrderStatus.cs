namespace LeanMobile.Data.Model
{
    public enum OrderStatus
    {
        New = 0,
        Submitted = 1,
        PartiallyFilled = 2,
        Filled = 3,
        Canceled = 5,
        None = 6,
        Invalid = 7,
        CancelPending = 8
    }
}
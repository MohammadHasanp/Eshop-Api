namespace Shop.Api.ViewModel.Transaction
{
    public class CreateTransactionViewModel
    {
        public long OrderId { get; set; }
        public string SuccessCallBackUrl { get; set; }
        public string ErrorCallBackUrl { get; set; }
    }
}

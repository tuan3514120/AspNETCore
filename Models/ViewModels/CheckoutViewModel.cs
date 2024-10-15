namespace Shopping.Models.ViewModels
{
	public class CheckoutViewModel
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }

        public string Address { get; set; }

		public List<OrderDetailViewModel> OrderDetails { get; set; }
    }
}

namespace Shopping.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get;set; }
        public decimal GrandTotal { get; set; }
        List<CartViewModel> Cartitem { get; set; }
        public CheckoutViewModel CheckoutModel { get; set; }


    }
}

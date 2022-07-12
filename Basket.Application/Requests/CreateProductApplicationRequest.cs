namespace Basket.Application.Requests
{
    public class CreateProductApplicationRequest
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
namespace Basket.Definition.Request
{
    public class CreateProductApiRequest
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
namespace NLayer.Core.DTOs
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        //EF Core bunu category tablosundaki Idd olduğunu anlar.
        public int CategoryId { get; set; }
    }
}

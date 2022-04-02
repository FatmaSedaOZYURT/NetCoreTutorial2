﻿namespace NLayer.Core.DTOs
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        //EF Core bunu category tablosundaki Idd olduğunu anlar.
        public int CategoryId { get; set; }
    }
}

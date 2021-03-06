namespace shop_mvc.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Count { get; set; } = 1;
    }
}

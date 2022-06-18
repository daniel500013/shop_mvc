namespace shop_mvc.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int Count { get; set; } = 1;
    }
}

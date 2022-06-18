namespace shop_mvc.Models
{
    public class BoughtModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int userID { get; set; }
        [Required]
        public int productID { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        public bool Complete { get; set; }
    }
}

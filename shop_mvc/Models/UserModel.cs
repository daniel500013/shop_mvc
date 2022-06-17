namespace shop_mvc.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }
        
        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Password { get; set; }
        [Required]
        public string? HashPassword { get; set; } = "";

        [Required]
        public string? Email { get; set; }

        [Required]
        [MaxLength(9)]
        public string? Phone { get; set; }
        [Required]
        [MaxLength(7)]
        public string? ZipCode { get; set; }

        [Required]
        public string? State { get; set; }

        [Required]
        public string? Address { get; set; }


        public string? Role { get; set; } = "User";
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC1Crud.Models
{
    public class Store
    {
        [Key]
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Store name is required.")]
      
        public string? StoreName { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
       
        public string? Password { get; set; }

        [Required(ErrorMessage = "GroupId is required.")]
       
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group? Group { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
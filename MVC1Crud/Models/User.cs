using System.ComponentModel.DataAnnotations.Schema;

namespace MVC1Crud.Models
{
    public class User
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int GroupId { get; set; }

        public int StoreId { get; set; }

        public string? Status { get; set; }
       
        [ForeignKey("GroupId")]
        public Group? Group { get; set; }

        [ForeignKey("StoreId")]
        public Store? Store { get; set; }
    }
}

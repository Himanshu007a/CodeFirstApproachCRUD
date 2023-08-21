using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC1Crud.Models
{
    public class Group
    {
        [Key]
        [Column("GroupId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Group name is required.")]
        [Column("GroupName")]
        public string? GroupName { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Column("GroupAge")]
        public int Age { get; set; }

        public ICollection<User>? Users { get; set; }
        public ICollection<Store>? Stores { get; set; }
    }
}

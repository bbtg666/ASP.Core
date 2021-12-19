using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.RazorPage.Models
{
    //[Table("Posts")]
    public class Article {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column(TypeName = "nvarchar")]
        public string Title { get; set; }   

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime Created { get; set; }
        
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
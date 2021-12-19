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
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }   

        [DataType(DataType.DateTime)]
        [Required]
        [Display(Name = "Ngày tạo")]
        public DateTime Created { get; set; }
        
        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
    }
}
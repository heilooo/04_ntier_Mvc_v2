using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ntier.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="عنوان اجباری است")]        
        public string Title { get; set; }
        
        [MaxLength(1000,ErrorMessage ="بیشتر از 1000 کارکتر نمی توانید وارد کنید")]
        public string Description { get; set; }

        public string ShortDescription { get; set; }
        
        public string ISBN { get; set; }
        
        public string Author { get; set; }
        
        public double ListPrice { get; set; }
        
        public double Price { get; set; }
        
        public double Price50 { get; set; }
        
        public double Price100 { get; set; }
        
        public string ImgeUrl { get; set; }

        public string ImgeTitle { get; set; }
        
        public string ImgeAlt { get; set; }
        
        
        
        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        


        public int CoverTypeId { get; set; }
        
        //[ForeignKey("CoverTypeId ")]
        public CoverType coverType { get; set; }


    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ntier.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="عنوان")]
        [DisplayName("عنوان")]
        public string Name { get; set; }
    }
}

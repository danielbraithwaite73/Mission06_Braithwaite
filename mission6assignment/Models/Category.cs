using System.ComponentModel.DataAnnotations;

namespace Mission06_Braithwaite.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } // Connection point to Movies table
        public string CategoryName { get; set; }
    }
}

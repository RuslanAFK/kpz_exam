using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double MoneySpent { get; set; }
        [Required]
        public double SpentPerMonth { get; set; }
        [ForeignKey("CategoryId")]
        ICollection<Spending> Spendings { get; set; }
    }
}

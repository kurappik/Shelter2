using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Shelter2.Models
{
    public class Shelter
    {
        public int Id { get; set; }
        [Display(Name = "Название приюта")]

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? NameShelter { get; set; }
        [Display(Name = "Дата основания")]
        [DataType(DataType.Date)]

        public DateTime Date { get; set; }
      
        [Range(1, 3000)]
        [DataType(DataType.Currency)]
        [Precision(18, 2)]

        [Display(Name = "Накопления")]
        public decimal Priceshelter { get; set; }

        [Range(1, 100)]
        [Display(Name = "Возраст")]
        public int AgeShelter { get; set; }
        public ICollection<Volonteer> Volonteers { get; set; } = new List<Volonteer>();
        public ICollection<Pets> Pets { get; set; } = new List<Pets>();
    }
}

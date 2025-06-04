using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Shelter2.Models
{
    public class Pets
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]

        public DateTime Date { get; set; }
        [Display(Name = "Тип операции")]
        [RegularExpression(@"^[А-Я]+[а-яА-Я\s]*$")]
        [Required]
        [StringLength(30)]
        public string? TypeOfInspection { get; set; }

        [Range(1, 3000)]
        [DataType(DataType.Currency)]
        [Precision(18, 2)]

        [Display(Name = "Возраст")]
        public decimal Price { get; set; }

        [Range(1, 100)]
        [Display(Name = "Цена")]
        public int Age { get; set; }
        [Display(Name = "Приют")]
        public int? ShelterId { get; set; }
        [Display(Name = "Приют")]
        public Shelter? Shelter { get; set; }
    }
}

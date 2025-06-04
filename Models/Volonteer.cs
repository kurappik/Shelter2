using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shelter2.Models
{
    public class Volonteer
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? NameVolonteer { get; set; }
        [Display(Name = "Дата устройства на работу")]
        [DataType(DataType.Date)]
        public DateTime DateVolonteer { get; set; }
        [Display(Name = "Статус работника")]
        [RegularExpression(@"^[А-Я]+[а-яА-Я\s]*$")]
        [Required]
        [StringLength(30)]
        public string? StatusVolonteer { get; set; }
        [Range(1, 3000)]

        [Precision(18, 2)]
        [Display(Name = "Возраст")]
        public decimal AgeVolonteer { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Зарплата")]
        public int PriceVolonteer { get; set; }
        [Display(Name = "Приют")]
        public int? ShelterId { get; set; }
        [Display(Name = "Приют")]
        public Shelter? Shelter { get; set; }
    }
}

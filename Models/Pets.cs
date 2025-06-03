using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Shelter2.Models
{
    public class Pets
    {
        public int Id { get; set; }
        [Display(Name="Имя")]
        public string? Name { get; set; } 
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]

        public DateTime Date { get; set; }
        [Display(Name = "Тип операции")]
        public string? TypeOfInspection { get; set; }
        [Precision(18,2)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}

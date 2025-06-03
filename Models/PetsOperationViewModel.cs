using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shelter2.Models
{
    public class PetsOperationViewModel
    {
        public List<Pets>? Pets { get; set; }
        public SelectList? TypeOfInspection { get; set; }
        public string? PetsTypeOfInspection { get; set; }
        public string? SearchString { get; set; }
    }
}

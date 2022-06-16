using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace _16._06Praktika.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string FoodImage { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Title { get; set; }
        public string Des { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

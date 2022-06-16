using System.Collections.Generic;

namespace _16._06Praktika.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Menu> Menus { get; set; }
    }
}

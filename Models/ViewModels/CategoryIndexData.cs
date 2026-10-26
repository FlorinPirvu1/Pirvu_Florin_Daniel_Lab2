using System.Collections.Generic;
using Pirvu_Florin_Daniel_Lab2.Models;

namespace Pirvu_Florin_Daniel_Lab2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
using EducationalPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationalPortal.MVC.Models
{
    public class BookAuthorModel
    {
        public string BookName { get; set; }

        public int BookId { get; set; }

        public int AuthorId { get; set; }

        public List<SelectListItem> AuthorsList { get; set; }
    }
}

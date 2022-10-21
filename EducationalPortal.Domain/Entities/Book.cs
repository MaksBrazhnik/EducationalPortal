namespace EducationalPortal.Domain.Entities
{
    public class Book : LearnMaterial
    {
        public int PageCount { get; set; }

        public string Format { get; set; }

        public DateTime PublicationDate { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
    }
}

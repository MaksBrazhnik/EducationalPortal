namespace EducationalPortal.Domain.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PageCount { get; set; }

        public string Format { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Author { get; set; }
    }
}

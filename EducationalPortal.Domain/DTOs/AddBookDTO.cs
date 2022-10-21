namespace EducationalPortal.Domain.DTOs
{
    public class AddBookDTO
    {
        public string Name { get; set; }

        public int PageCount { get; set; }

        public string Format { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}

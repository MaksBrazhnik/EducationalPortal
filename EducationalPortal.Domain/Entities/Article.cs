namespace EducationalPortal.Domain.Entities
{
    public class Article : LearnMaterial
    {
        public DateTime PublicationDate { get; set; }

        public string Resource { get; set; }
    }
}

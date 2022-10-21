using EducationalPortal.Domain.Enums;

namespace EducationalPortal.Domain.ViewModels
{
    public class SortViewModel
    {
        public SortViewModel(SortState sortOrder)
        {
            ArticleSort = sortOrder == SortState.ArticleASC ? SortState.ArticleDESC : SortState.ArticleASC;
            BookSort = sortOrder == SortState.BookASC ? SortState.BookDESC : SortState.BookASC;
            VideoSort = sortOrder == SortState.VideoASC ? SortState.VideoDESC : SortState.VideoASC;
            SkillSort = sortOrder == SortState.SkillASC ? SortState.SkillDESC : SortState.SkillASC;
            CourseSort = sortOrder == SortState.CourseASC ? SortState.CourseDESC : SortState.CourseASC;
            Current = sortOrder;
        }

        public SortState ArticleSort { get; }

        public SortState BookSort { get; }

        public SortState VideoSort { get; }

        public SortState SkillSort { get; }

        public SortState CourseSort { get; }

        public SortState Current { get; }
    }
}

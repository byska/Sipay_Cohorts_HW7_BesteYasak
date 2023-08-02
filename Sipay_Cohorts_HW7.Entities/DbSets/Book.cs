using Sipay_Cohorts_HW7.Entities.BaseModel;

namespace Sipay_Cohorts_HW7.Entities.DbSets
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }   
    }
}

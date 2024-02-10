namespace DataNews.Api.Entities
{
    public class NewsEntities
    {
        public NewsEntities()
        {
            IsDeleted = false;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublicateDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Category {  get; set; }
        public void Update(string name, string description, string author, DateTime publicateDate)
        {
            Name = name;
            Description = description;
            Author = author;
            PublicateDate = publicateDate;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}

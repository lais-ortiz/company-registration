namespace CompanyRegistration.Api.Models
{
    public class CompanyDto
    {
        public string BusinessName { get; set; }
        public string FantasyName { get; set; }
        public string BusinessDocument { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime InsertedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}

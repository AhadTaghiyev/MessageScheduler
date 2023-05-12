
namespace MessageScheduler.Service.Dtos.MessageDto
{
    public record MessageGetDto
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
        public string Method { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

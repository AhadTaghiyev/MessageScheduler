

namespace MessageScheduler.Service.Dtos.MessageDto
{
    public record MessagePostDto
    {
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
        public string Method { get; set; }
    }
}

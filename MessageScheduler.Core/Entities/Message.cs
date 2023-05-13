using MessageScheduler.Core.Entities.BaseEntities;

namespace MessageScheduler.Core.Entities
{
    public class Message: BaseEntity
    {
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
        public string Method { get; set; }
        public string JobId { get; set; }
    }
}



namespace MessageScheduler.Service.Dtos
{
    public record ListDto<T>
    {
        public List<T> Items { get; set; }
    }
}

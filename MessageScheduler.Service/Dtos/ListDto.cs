

namespace MessageScheduler.Service.Dtos
{
    public record ListDto<T>
    {
        public IEnumerable<T> Items { get; set; }
    }
}

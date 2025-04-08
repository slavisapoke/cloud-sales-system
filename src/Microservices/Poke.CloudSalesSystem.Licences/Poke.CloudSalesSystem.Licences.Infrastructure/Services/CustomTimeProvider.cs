namespace Infrastructure.Services
{
    public class CustomTimeProvider : TimeProvider
    {
        public override DateTimeOffset GetUtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}

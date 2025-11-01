namespace UserSystem_xUnitTest.Api.Logging
{
    // internal yapıları test projesinde kullanabilmek için yazıyoruz.
    public interface ILoggerAdapter<TType>
    {
        void LogInformation(string? message, params object?[] args);
        void LogError(Exception? exception, string? message, params object?[] args);
    }

}

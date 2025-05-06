interface IDataSender
{
    Task SendFileAsync(Stream targetStream, CancellationToken token = default);
}
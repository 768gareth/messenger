interface IDataReceiver
{
    Task ReceiveFileAsync(Stream targetStream, CancellationToken token = default);
}
interface IDataReceiver
{
    Task ReceiveDataAsync(Stream sourceStream, Stream targetStream, CancellationToken token = default);
}
class ReceiveMessage : IDataReceiver
{
    public async Task ReceiveDataAsync(Stream sourceStream, Stream targetStream, CancellationToken token = default)
    {
        if (sourceStream == null) {throw new ArgumentNullException(nameof(sourceStream));}
        if (targetStream == null) {throw new ArgumentNullException(nameof(targetStream));}
        try
        {
            await sourceStream.CopyToAsync(targetStream, bufferSize: 81920, cancellationToken: token);
        }
        catch (IOException ex)
        {
            throw new InvalidOperationException("Failed to receive message data due to I/O error.", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new InvalidOperationException("Failed to receive message data due to insufficient permissions.", ex);
        }
    }
}
class ReceiveFile : IDataReceiver
{
    public async Task ReceiveDataAsync(Stream sourceStream, Stream targetStream, CancellationToken token = default)
    {
        if (sourceStream == null) {throw new ArgumentNullException(nameof(sourceStream));}
        if (targetStream == null) {throw new ArgumentNullException(nameof(targetStream));}
        try
        {
            await sourceStream.CopyToAsync(targetStream, bufferSize: 81920, cancellationToken: token);
        }
        catch (IOException ex)
        {
            throw new InvalidOperationException("Failed to receive file data due to I/O error.", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new InvalidOperationException("Failed to receive file data due to insufficient permissions.", ex);
        }
    }
}
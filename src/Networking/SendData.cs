using System.Diagnostics;

interface IDataSender
{
    Task SendDataAsync(Stream inputStream, Stream targetStream, CancellationToken token = default);
}
class SendMessage : IDataSender
{
    public async Task SendDataAsync(Stream inputStream, Stream targetStream, CancellationToken token = default)
    {
        if (inputStream == null) {throw new ArgumentNullException(nameof(inputStream));}
        if (targetStream == null) {throw new ArgumentNullException(nameof(targetStream));}
        try
        {
            await inputStream.CopyToAsync(targetStream, bufferSize: 81920, cancellationToken: token);
        }
        catch (IOException ex)
        {
            throw new InvalidOperationException("Failed to send message data due to I/O error.", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new InvalidOperationException("Failed to send message data due to insufficient permissions.", ex);
        }
    }
}
class SendFile : IDataSender
{
    public async Task SendDataAsync(Stream inputStream, Stream targetStream, CancellationToken token = default)
    {
        if (inputStream == null) {throw new ArgumentNullException(nameof(inputStream));}
        if (targetStream == null) {throw new ArgumentNullException(nameof(targetStream));}
        try
        {
            await inputStream.CopyToAsync(targetStream, bufferSize: 81920, cancellationToken: token);
        }
        catch (IOException ex)
        {
            throw new InvalidOperationException("Failed to send file data due to I/O error.", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new InvalidOperationException("Failed to send file data due to insufficient permissions.", ex);
        }
    }
}
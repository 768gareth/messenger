interface IEncryption
{
    Task Encrypt(Stream input, Stream output, CancellationToken token = default);
}

class AESEncryption : IEncryption
{
    public Task Encrypt(Stream input, Stream output, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}
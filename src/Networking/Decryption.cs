interface IDecryption
{
    Task Decrypt(Stream input, Stream output, CancellationToken token = default);
}

class AESDecryption : IDecryption
{
    public Task Decrypt(Stream input, Stream output, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}

class RSADecryption : IDecryption
{
    public Task Decrypt(Stream input, Stream output, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}
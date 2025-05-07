using System.Security.Cryptography;
interface IEncryption
{
    Task Encrypt(Stream input, Stream output, SymmetricAlgorithm algorithm, CancellationToken token = default);
}
class AESEncryption : IEncryption
{
    public Task Encrypt(Stream input, Stream output, SymmetricAlgorithm algorithm, CancellationToken token = default)
    {
        if (input == null) {throw new ArgumentNullException(nameof(input));}
        if (output == null) {throw new ArgumentNullException(nameof(output));}
        if (algorithm == null) {throw new ArgumentNullException(nameof(algorithm));}
        try
        {
            
        }
        catch ()
        {

        }
    }
}
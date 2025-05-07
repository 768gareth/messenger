using System.Security.Cryptography;
interface IDecryption
{
    Task Decrypt(Stream input, Stream output, SymmetricAlgorithm algorithm, CancellationToken token = default);
}
class AESDecryption : IDecryption
{
    public Task Decrypt(Stream input, Stream output, SymmetricAlgorithm algorithm, CancellationToken token = default)
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
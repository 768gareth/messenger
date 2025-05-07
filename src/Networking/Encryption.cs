using System.Security.Cryptography;
interface IEncryption
{
    Task Encrypt(Stream input, Stream output, SymmetricAlgorithm algorithm, CancellationToken token = default);
}
class AESEncryption : IEncryption
{
    public async Task Encrypt(Stream input, Stream output, SymmetricAlgorithm algorithm, CancellationToken token = default)
    {
        if (input == null) {throw new ArgumentNullException(nameof(input));}
        if (output == null) {throw new ArgumentNullException(nameof(output));}
        if (algorithm == null) {throw new ArgumentNullException(nameof(algorithm));}
        try
        {
            using CryptoStream cryptoStream = new CryptoStream(input, algorithm.CreateEncryptor(), CryptoStreamMode.Write);
            await cryptoStream.CopyToAsync(output, bufferSize: 81920, cancellationToken: token);
        }
        catch (CryptographicException ex)
        {
            throw new InvalidOperationException("Encryption failed due to cryptographical error.", ex);
        }
        catch (IOException ex)
        {
            throw new InvalidOperationException("Encryption failed due to I/O error.", ex);
        }
        catch (OperationCanceledException ex)
        {
            throw new TaskCanceledException("Encryption task was cancelled.", ex);
        }
    }
}
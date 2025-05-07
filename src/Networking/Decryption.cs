using System.Security.Cryptography;
interface IDecryption
{
    Task Decrypt(Stream input, Stream output, SymmetricAlgorithm algorithm, CancellationToken token = default);
}
class AESDecryption : IDecryption
{
    public async Task Decrypt(Stream input, Stream output, SymmetricAlgorithm algorithm, CancellationToken token = default)
    {
        if (input == null) {throw new ArgumentNullException(nameof(input));}
        if (output == null) {throw new ArgumentNullException(nameof(output));}
        if (algorithm == null) {throw new ArgumentNullException(nameof(algorithm));}
        try
        {
            using CryptoStream cryptoStream = new CryptoStream(input, algorithm.CreateDecryptor(), CryptoStreamMode.Read);
            await cryptoStream.CopyToAsync(output, bufferSize: 81920, cancellationToken: token);
        }
        catch (CryptographicException ex)
        {
            throw new InvalidOperationException("Decryption failed due to cryptographical error.", ex);
        }
        catch (IOException ex)
        {
            throw new InvalidOperationException("Decryption failed due to I/O error.", ex);
        }
        catch (OperationCanceledException ex)
        {
            throw new TaskCanceledException("Decryption task was cancelled.", ex);
        }
    }
}
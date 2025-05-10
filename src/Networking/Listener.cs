using System.Net.Sockets;
interface IListenerManager
{
    Task Listen(int port, CancellationToken token);
}
class GlobalListenerTCP : IListenerManager
{
    public async Task Listen(int port, CancellationToken token)
    {
        TcpListener tcpListener = new TcpListener(System.Net.IPAddress.Any, port);
        tcpListener.Start();
        try
        {
            while (!token.IsCancellationRequested)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync(token);
                using NetworkStream networkStream = tcpClient.GetStream();
            }
        }
        catch (TaskCanceledException)
        {

        }
        finally
        {
            tcpListener.Stop();
        }
    }
}
class ClientListenerTCP : IListenerManager
{
    private readonly string clientAddress;
    public ClientListenerTCP(string _clientAddress)
    {
        this.clientAddress = _clientAddress;
    }
    public async Task Listen(int port, CancellationToken token)
    {
        TcpListener tcpListener = new TcpListener(System.Net.IPAddress.Parse(clientAddress), port);
        tcpListener.Start();
        try
        {
            while (!token.IsCancellationRequested)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync(token);
            }
        }
        catch (OperationCanceledException ex)
        {
            throw new TaskCanceledException("Listener task was cancelled.", ex);
        }
        finally
        {
            tcpListener.Stop();
        }
    }
}
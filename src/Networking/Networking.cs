interface IConnectionManager
{

}
interface IListenerManager
{

}
interface IDataSender
{

}
interface IDataReceiver
{

}
interface ICryptography
{
    byte[] Encrypt(byte[] Input);
    byte[] Decrypt(byte[] Input);
}

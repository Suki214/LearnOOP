namespace ChatServer
{
    public interface IClient
    {
        void PaticipantDisconnection(string name);
        void PaticipantReconnection(string name);
        void PaticipantLogin(User client);
        void PaticipantLogout(string name);
        void BroadcastTexMessage(string sender, string message);
        void BroadcastPictureMessage(string sender, byte[] img);
        void UnicastTexMessage(string sender, string message);
        void UnicastPictureMessage(string sender, byte[] img);
        void PaticipantTyping(string sender);
    }
}

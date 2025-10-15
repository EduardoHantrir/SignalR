namespace SignalR_Domains.Interface
{
    public interface ITokenService
    {
        string GenerateToken(User.User user);
        Guid GetUserIdFromToken();
        bool ValidateToken();
    }
}
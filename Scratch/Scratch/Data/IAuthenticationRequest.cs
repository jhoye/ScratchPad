namespace Scratch.Data
{
    public interface IAuthenticationRequest
    {
        string Username { get; set; }

        string Password { get; set; }

        bool IsAuthenticated { get; set; }
    }
}

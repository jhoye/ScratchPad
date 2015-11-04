namespace Scratch.Data
{
    public class Users : IUsers
    {
        public void Authenticate(IAuthenticationRequest authenticationRequest)
        {
            // TODO: Scratch.Data.Users.Authenticate(IAuthenticationRequest authenticationRequest)

            authenticationRequest.IsAuthenticated = true;
        }
    }
}

namespace Chimera.Interaction.Tests.MockSetup.Login
{
    public class LoginService : ILoginService
    {
        public bool Login(string userName, string password)
        {
            if (userName == "" && password == "")
                return true;

            if (userName == "test" && password == "test")
                return true;

            return false;
        }
    }
}
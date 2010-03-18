using Chimera.Default.Listeners;

namespace Chimera.Interaction.Tests.MockSetup.Login
{
    public class LoginListener : Listener
    {
        public bool SuccessLoginCalled { get; set; }

        public void OnSuccessLogin()
        {
            SuccessLoginCalled = true;
        }
    }
}
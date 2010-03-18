using Chimera.Framework.Errors;

namespace Chimera.Default.Errors
{
    public class Error : IError
    {
        public Error(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
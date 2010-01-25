namespace Chimera.Framework.Routing.Default.Tests.TestingHelpers
{
    public class ActionRecorder
    {
        public ActionRecorder()
        {
            _wasExecuted = false;
        }

        bool _wasExecuted;

        public void RecordExecution()
        {
            _wasExecuted = true;
        }

        public bool WasExecuted()
        {
            return _wasExecuted;
        }
    }
}
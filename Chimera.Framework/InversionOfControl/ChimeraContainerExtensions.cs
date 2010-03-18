namespace Chimera.Framework.InversionOfControl
{
    public static class ChimeraContainerExtensions
    {
        public static void Register<I, C>(this IChimeraContainer container) where C : I
        {
            container.Register(typeof (I), typeof (C));
        }

        public static void RegisterSingleton<I, C>(this IChimeraContainer container) where C : I
        {
            container.RegisterSingleton(typeof(I), typeof(C));
        }
    }
}
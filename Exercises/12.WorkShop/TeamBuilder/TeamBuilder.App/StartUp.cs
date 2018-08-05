namespace TeamBuilder.App
{
    using TeamBuilder.App.Core;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine(new CommandDispatcher());
            engine.Run();
        }
    }
}

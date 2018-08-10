namespace Employees.App.Command
{
    internal interface ICommand
    {
        string Excecute(params string[] args);
    }
}

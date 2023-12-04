using System.Reflection;

namespace AdventOfCode.Console.Infra;

public class ProblemsLocator
{
    public static IEnumerable<(byte Day, Func<IProblem> Create)> GetAllProblems()
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(x => x.IsAssignableTo(typeof(IProblem)) && x.IsClass)
            .Select<Type, (byte, Func<IProblem>)>(x => (
                x.GetCustomAttribute<DayNumberAttribute>()!.Day, 
                () => (Activator.CreateInstance(x) as IProblem)!));
    }
}
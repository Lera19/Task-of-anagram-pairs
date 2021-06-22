using TaskSolution.Class;
using TaskSolution.Interface;

namespace TaskSolution
{
    class Program
    {
        static ICustomIO customIO = new CustomIOConsole();
        static Anagram anagram = new Anagram(customIO);

        static void Main(string[] args)
        {
            StartApplication startApplication = new StartApplication(customIO, anagram);
            startApplication.StartApp();
        }
    }
}
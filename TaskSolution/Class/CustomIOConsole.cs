using System;
using TaskSolution.Interface;

namespace TaskSolution.Class
{
    public class CustomIOConsole : ICustomIO
    {
        public string ReadString()
        {
            return Console.ReadLine();
        }

        public void WriteString(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteString(int message)
        {
            Console.WriteLine(message);
        }
    }
}

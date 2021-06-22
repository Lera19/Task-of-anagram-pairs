namespace TaskSolution.Interface
{
    public interface ICustomIO
    {
        string ReadString();

        void WriteString(string message);

        void WriteString(int message);
    }
}

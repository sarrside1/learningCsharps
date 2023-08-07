namespace DelegateBasicExample
{
    class Program
    {
        delegate void LogDel(string text);
        static void Main(String[] args)
        {
            Log log = new Log();
            LogDel logTextToScreenDel, logTextToFileDel;
            logTextToScreenDel = new LogDel(log.LogTextToScreen);
            logTextToFileDel = new LogDel(log.LogTextToFile);
            LogDel multiLogDel = logTextToScreenDel + logTextToFileDel;
            Console.WriteLine("Give your name");
            string name = Console.ReadLine();
            //logTextToFileDel(name);
            //logTextToScreenDel(name);
            //multiLogDel(name);
            LogText(multiLogDel, name);
        }
        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }
    }

    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}=> {text}");
        }

        public void LogTextToFile(string text)
        {
            using (StreamWriter streamWriter = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                streamWriter.WriteLine($"{DateTime.Now}=> {text}");
            }
        }
    }
}
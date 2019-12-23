namespace Task7_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("log.txt")
                .CreateLogger();

            SequenceController sequenceController = new SequenceController();
            sequenceController.Run();
        }
    }
}
